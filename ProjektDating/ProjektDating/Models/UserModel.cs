using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProjektDating.Models
{
    [Bind(Include = "Username, Password,FirstName,LastName,Email,Hidden, Image, Gender,Phone,Country,LookingFor, Files, NewPassword, ConfirmPassword  ")]
    public class UserModel
    {
        [Key]
        public int UserID { get; set; }  // Primary key
        [Required(ErrorMessage = "Skriv in ett användarnamn.")]
        [Display(Name = "Användarnamn:")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = " {0} måste vara minst {2} karaktärer långt .", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord:")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta nytt lösenord")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "Det nya lösenordet och bekräfta lösenordet matchar inte.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Skriv in ditt förnamn.")]
        [Display(Name = "Förnamn:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Skriv in ditt efternamn")]
        [Display(Name = "Efternamn:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Skriv in en mejladress.")]
        [EmailAddress]
        [Display(Name = "Mejladress:")]
        public string Email { get; set; }

        public bool Hidden { get; set; }

        [Display(Name = "Kön:")]
        public bool Gender { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Telefon:")]
        public string Phone { get; set; }

        [Display(Name = "Vad letar du efter?")]
        public char? LookingFor { get; set; }

        //public int? PostId { get; set; }  // Foreign key 
        //public int? FriendId { get; set; } // Foreign entity

        public string PersonalNumber { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}