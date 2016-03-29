using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace CoTFBWebRole.Models
{
    public class CoTfbDbContext : IdentityDbContext<CoTFbUser>
    {
        public CoTfbDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder) //
        {
            if (modelBuilder == null)
            {
                throw new ArgumentException("ModelBuilder is null");
            } //Check if modelBuilder is null
            base.OnModelCreating(modelBuilder); //creating my model

            modelBuilder.Entity<CoTFbUser>().ToTable("Users");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }


        public static CoTfbDbContext Create()
        {
            return new CoTfbDbContext();
        }

        public static void Initialize()
        {
            Create().Database.Initialize(false);
        }
    }
}
    