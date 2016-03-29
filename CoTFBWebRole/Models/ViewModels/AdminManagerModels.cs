using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoTFBWebRole.Models
{
      public class UserViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }


    public class EditUserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public void MapToEntity(CoTFbUser user)
        {
            user.UserName = this.Username;
            user.FirstName = this.FirstName;
            user.City = this.City;
            user.Country = this.Country;
        }
    }
        
}