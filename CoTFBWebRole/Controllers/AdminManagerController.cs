using CoTFBWebRole.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CoTFBWebRole.Controllers
{
    public class AdminManagerController : Controller
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
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var model = db.Users.Select(u => new UserViewModel
            {
                UserId = u.Id, 
                FirstName = u.FirstName,
                Username = u.UserName,
                City = u.City,
                Country = u.Country
            }).ToList();
           
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            EditUserViewModel model = null;
            using (var context = CoTfbDbContext.Create())
            {
                model = db.Users.Where(u => u.Id.Equals(id)).Select(o => new EditUserViewModel
                {
                    Username = o.UserName,
                    FirstName = o.FirstName,
                    City = o.City,
                    Country = o.Country,
                    Id = o.Id
                }).First();
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var context = CoTfbDbContext.Create())
                {
                    var user = context.Users.Where(u => u.Id.Equals(model.Id)).First();
                    model.MapToEntity(user);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();

        }

        [Authorize(Roles="Admin")] 
        public ActionResult Delete(string id)
        {
            if(id == null) { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
            var user = db.Users.Find(id); 
            if(user == null) { HttpNotFound(); }
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}