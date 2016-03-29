using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using System.Web;

namespace CoTFBWebRole.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class CoTFbUser : IdentityUser
    {
        public ICollection<IdentityRole> UserRoles { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public byte[] Picture { get; set; }
        public string PictureUri { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<CoTFbUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }     
    }
}