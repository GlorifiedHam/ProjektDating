using ProjektDating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektDating
{
    public class OurDbInitializer : System.Data.Entity.DropCreateDatabaseAlways<MainDbContext>
    {
        protected override void Seed(MainDbContext context)
        {
            context.userModel.Add(new UserModel
            {
                Username = "DonaldTrump",
                NewPassword = "trump1",
                ConfirmPassword = "trump1",
                FirstName = "Donald",
                LastName = "Trump",
                Email = "Trump@hotmail.com",
                Phone = "123456789",
                Hidden = false,
                Gender = false,
                LookingFor = '2'
            });

            context.userModel.Add(new UserModel
            {
                Username = "VladimirPutin",
                NewPassword = "putin1",
                ConfirmPassword = "putin1",
                FirstName = "Vladimir",
                LastName = "Putin",
                Email = "Putin@hotmail.com",
                Phone = "987654321",
                Hidden = false,
                Gender = false,
                LookingFor = '1'
            });

            context.userModel.Add(new UserModel
            {
                Username = "StefanLofven",
                NewPassword = "lofven1",
                ConfirmPassword = "lofven1",
                FirstName = "Stefan",
                LastName = "Lofven",
                Email = "Lofven@hotmail.com",
                Phone = "555555555",
                Hidden = false,
                Gender = false,
                LookingFor = '3'
            });

            context.userModel.Add(new UserModel
            {
                Username = "AngelaMerkel",
                NewPassword = "merkel1",
                ConfirmPassword = "merkel1",
                FirstName = "Angela",
                LastName = "Merkel",
                Email = "Merkel@hotmail.com",
                Phone = "333333333",
                Hidden = false,
                Gender = false,
                LookingFor = '1'
            });

            base.Seed(context);



            /* context.Files.Add(new File
             {
                 FileName = "trump.png",
                 ContentType = "image/png",
                 Content =  0x89504E470D0A1A0A0000000D49484452000000F0000000F00802000000B1377EC5000000017352474200AECE1CE90000000467414D410000B18F0BFC6105000000097048597300000EC300000EC301C76FA8640000FFA549444154785E74FD657424679AAE8DFACF396B9FD93DD3DDA662103333670A1294CCCCCC2CA532A554
                 FileType = (FileType)1,
                 UserId = 1

             });

             context.Files.Add(new File
             {
                 FileName = "putin.png",
                 ContentType = "image/png",
                 Content = 0x89504E470D0A1A0A0000000D494844520000019E0000022508020000006AFB0973000000017352474200AECE1CE90000000467414D410000B18F0BFC6105000000097048597300000EC300000EC301C76FA8640000FFA549444154785E7CFDF7971457BEED8B964BEFBDF7DEDBC8309919E9BD2B9FE53D557810C80B100204C2,
                 FileType = (FileType)1,
                 UserId = 2

             });

             context.Files.Add(new File
             {
                 FileName = "lofven.png",
                 ContentType = "image/png",
                 Content = 0x89504E470D0A1A0A0000000D4948445200000104000001450802000000856E0494000000017352474200AECE1CE90000000467414D410000B18F0BFC6105000000097048597300000EC300000EC301C76FA8640000FFA549444154785EECFD77B024497A1F086668953AF36951BABABB5ACFF4E801663083D118689030E3AE2D,
                 FileType = (FileType)1,
                 UserId = 3

             }); */
        }


    }
}