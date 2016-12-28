using ProjektDating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using ProjektDating.CustomLibraries;

namespace ProjektDating.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {
            var db = new MainDbContext();
            return View(db.Lists.Where(x => x.Public == "YES").ToList());
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            if (!ModelState.IsValid) //Checks if input fields have the correct format
            {
                return View(model); //Returns the view with the input values so that the user doesn't have to retype again
            }

            using (var db = new MainDbContext())
            {
                var emailCheck = db.userModel.FirstOrDefault(u => u.Email == model.Email);
                var getPassword = db.userModel.Where(u => u.Email == model.Email).Select(u => u.NewPassword);
                var materializePassword = getPassword.ToList();
                var password = materializePassword[0];
                var decryptedPassword = CustomDecrypt.Decrypt(password);

                if (model.Email != null && model.Password == decryptedPassword)
                {
                    var getName = db.Users.Where(u => u.Email == model.Email).Select(u => u.Name);
                    var materializeName = getName.ToList();
                    var name = materializeName[0];

                    var getCountry = db.Users.Where(u => u.Email == model.Email).Select(u => u.Country);
                    var materializeCountry = getCountry.ToList();
                    var country = materializeCountry[0];

                    var getEmail = db.Users.Where(u => u.Email == model.Email).Select(u => u.Email);
                    var materializeEmail = getEmail.ToList();
                    var email = materializeEmail[0];

                    var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Country, country)
                },
                        "ApplicationCookie");

                    var ctx = Request.GetOwinContext();
                    var accountManager = ctx.Authentication;

                    accountManager.SignIn(identity);

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid email or password");
            return View(model);
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var accountManager = ctx.Authentication;

            accountManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserModel account, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
               
                using (var db = new MainDbContext())
                {
                    var queryUser = db.userModel.FirstOrDefault(u => u.Username == account.Username);
                    if (queryUser == null)
                    {
                        var encryptedNewPassword = CustomEnrypt.Encrypt(account.NewPassword);
                        var encryptedConfirmPassword = CustomEnrypt.Encrypt(account.ConfirmPassword);
                        var user = db.userModel.Create();
                        if (upload != null && upload.ContentLength > 0)
                        {
                            var avatar = new File
                            {
                                FileName = System.IO.Path.GetFileName(upload.FileName),
                                FileType = FileType.Avatar,
                                ContentType = upload.ContentType
                            };
                            using (var reader = new System.IO.BinaryReader(upload.InputStream))
                            {
                                avatar.Content = reader.ReadBytes(upload.ContentLength);
                            }
                            user.Files = new List<File> { avatar };
                        }
                        user.Username = account.Username;
                        user.Email = account.Email;
                        user.NewPassword = encryptedNewPassword;
                        user.ConfirmPassword = encryptedConfirmPassword;
                        user.FirstName = account.FirstName;
                        user.LastName = account.LastName;
                        user.Hidden = account.Hidden;
                        user.Gender = account.Gender;
                        user.LookingFor = account.LookingFor;
                        user.PersonalNumber = account.PersonalNumber;
                        db.userModel.Add(user);
                        db.SaveChanges();
                    }
                    else
                    {
                        return RedirectToAction("Registration");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "One or more fields have been");
            }
            return View();
        }
    }
}