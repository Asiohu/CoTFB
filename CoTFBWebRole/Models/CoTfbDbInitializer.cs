using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.WindowsAzure.Diagnostics.Management;

namespace CoTFBWebRole.Models
{
    public class CoTfbDbInitializer : DropCreateDatabaseIfModelChanges<CoTfbDbContext>
    {
        protected override void Seed(CoTfbDbContext context)
        {
            var admin = new IdentityRole { Name = "Admin", Id = Guid.NewGuid().ToString() };
            var user = new IdentityRole { Name = "User", Id = Guid.NewGuid().ToString() };
            var newAdmin = new CoTFbUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "AndreasAdmin@test2.com",
                Email = "AndreasAdmin@test2.com",
                PasswordHash = "ANgwBdpQon5+Jp4d2/6HiWutOoDwEVDo3OghvU3cH0lsPUQNUUyqRAP70sb/zZRMgA==",
                SecurityStamp = "a4a45109-d97f-4f74-9f71-1ff60fd90dca",
                Roles = { new IdentityUserRole { RoleId = admin.Id, UserId = user.Id }},
            };
            context.Roles.Add(admin);
            context.Roles.Add(user);
            context.Users.Add(newAdmin);
            base.Seed(context);
        }
    }
}