﻿using ProjektDating.Models;
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
        public DbSet<Users> Users { get; set; }

        public DbSet<Lists> Lists { get; set; }

      
    }
}