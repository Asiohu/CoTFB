using CoTFBWebRole.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace CoTFBWebRole.Controllers
{
    public class UserManagerController : Controller
    {

        private CoTfbDbContext db = new CoTfbDbContext();
        protected override void Dispose(bool disposing)
        {
            if (db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Authorize(Roles = "User")]
        public ActionResult UserProfile(string id )
        {
            id = User.Identity.GetUserId(); 
            UserAccountViewModel model = null;
            using (var context = CoTfbDbContext.Create())
            {
                model = db.Users.Where(u => u.Id.Equals(id)).Select(o => new UserAccountViewModel
                {
                    Username = o.UserName,
                    FirstName = o.FirstName,
                    City = o.City,
                    Country = o.Country,
                    PictureUri = o.PictureUri,
                    Id = o.Id                  
                }).First();
            }
           
            return View(model);
        }

        public ActionResult Instruction()
        {
            return View();
        }

        public ActionResult Game()
        {
            return View();
        }

    }
}