using ProjektDating.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;


namespace ProjektDating
{
    public class MainDbContext : DbContext
    {
     

        public MainDbContext() : base("name=DefaultConnection")
        {

        }
        public DbSet<UserModel> userModel { get; set; }
        public DbSet<File> Files { get; set; }

        public DbSet<Lists> Lists { get; set; }

      
    }
}