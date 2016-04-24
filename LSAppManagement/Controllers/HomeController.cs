using LSAppManagement.Helpers;
using LSAppManagement.Models;
using LSAppManagement.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LSAppManagement.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = DbFactory.getDb();

        public ActionResult Index()
        {
            var models = db.Applications.ToList().Select(entity => (ApplicationModel) entity);
            return View(models);
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Create";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicationModel app)
        {
            ViewBag.Message = "Create";

            if (ModelState.IsValid)
            {
                var entity = (ApplicationEntity)app;

                return RedirectToAction("Actions", "Home", new { id = app.ID });
            }

            return View(app);
        }

        public ActionResult Actions(int id)
        {
            ViewBag.Message = "Actions";

            ApplicationModel app = (ApplicationModel)db.Applications.Find(id);

            return View(app);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Message = "Edit";

            ApplicationModel app = (ApplicationModel) db.Applications.Find(id);

            return View(app);
        }

        public ActionResult Delete()
        {
            ViewBag.Message = "Delete";

            var apps = db.Applications.Where(app => !app.Deleted).ToList().Select(entity => (ApplicationModel) entity);

            return View(apps);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ApplicationModel app)
        {
            if (ModelState.IsValid)
            {
                //TODO: Delete App From IIS but not the files on the server
                var entity = db.Applications.Find(app.ID);
                entity.Deleted = true;
                db.SaveChanges();

                return RedirectToAction("Delete", "Home");
            }

            return View(app);
        }

        public ActionResult Restore()
        {
            var apps = db.Applications.Where(app => app.Deleted).ToList().Select(entity => (ApplicationModel) entity);

            return View(apps);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Restore(ApplicationModel app)
        {
            if (ModelState.IsValid)
            {
                //TODO: IIS to restore web app at location
                var entity = db.Applications.Find(app.ID);
                entity.Deleted = false;
                db.SaveChanges();

                return RedirectToAction("Restore", "Home");
            }

            return View(app);
        }
    }
}