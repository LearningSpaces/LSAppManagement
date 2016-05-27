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
        public ActionResult Index()
        {
            using (var db = DbFactory.getDb())
            {
                var apps = db.Applications.ToList().Select(entity => (ApplicationModel)entity);
                return View(apps);
            }
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
                using (var db = DbFactory.getDb())
                {
                    var entity = (ApplicationEntity)app;
                    db.Applications.Add(entity);
                    db.SaveChanges();
                    return RedirectToAction("Actions", "Home", new { id = entity.ID });
                }
            }

            return View(app);
        }

        public ActionResult Actions(int id)
        {
            ViewBag.Message = "Actions";
            using (var db = DbFactory.getDb())
            {
                ApplicationModel app = (ApplicationModel)db.Applications.Find(id);

                return View(app);
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Message = "Edit";

            using (var db = DbFactory.getDb())
            {
                ApplicationModel app = (ApplicationModel)db.Applications.Find(id);

                return View(app);
            }
        }

        public ActionResult Delete()
        {
            ViewBag.Message = "Delete";

            using (var db = DbFactory.getDb())
            {
                var apps = db.Applications.Where(app => !app.Deleted).ToList().Select(entity => (ApplicationModel)entity);
                return View(apps);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ApplicationModel app)
        {
            if (ModelState.IsValid)
            {
                using (var db = DbFactory.getDb())
                {
                    //TODO: Delete App From IIS but not the files on the server
                    var entity = db.Applications.Find(app.ID);
                    entity.Deleted = true;
                    db.SaveChanges();

                    return RedirectToAction("Delete", "Home");
                }
            }

            return View(app);
        }

        public ActionResult Restore()
        {
            using (var db = DbFactory.getDb())
            {
                var apps = db.Applications.Where(app => app.Deleted).ToList().Select(entity => (ApplicationModel)entity);
                return View(apps);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Restore(ApplicationModel app)
        {
            if (ModelState.IsValid)
            {
                using (var db = DbFactory.getDb())
                {
                    //TODO: IIS to restore web app at location
                    var entity = db.Applications.Find(app.ID);
                    entity.Deleted = false;
                    db.SaveChanges();

                    return RedirectToAction("Restore", "Home");
                }
            }

            return View(app);
        }

        public ActionResult CodeMove(int id)
        {
            using (var db = DbFactory.getDb())
            {
                ApplicationModel app = (ApplicationModel)db.Applications.Find(id);
                var model = new CodeMoveModel()
                {
                    App = app
                };
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult CodeMove(CodeMoveModel info)
        {
            return Json(info);
        }
    }
}