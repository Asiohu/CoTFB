
using System.Web;

namespace CoTFBWebRole.Models
{
    public class UserAccountViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public byte[] Picture { get; set; }
        public string PictureUri { get; set; }

        public void MapToEntity(CoTFbUser user)
        {
            user.UserName = this.Username;
            user.FirstName = this.FirstName;
            user.City = this.City;
            user.Country = this.Country;
            user.Picture = this.Picture;
            user.PictureUri = this.PictureUri; 
        }
    }

}
