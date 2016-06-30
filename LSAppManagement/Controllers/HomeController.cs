using LSAppManagement.Helpers;
using LSAppManagement.Models;
using LSAppManagement.Models.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
                var model = new CodeMoveModel();
                model.AppId = app.ID;
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult CodeMove(CodeMoveModel info)
        {
            var request = WebRequest.CreateHttp("http://localhost/AppManagementWebservice/Build/Install?id=" + info.AppId + "&sha1=" + info.SHA1 + "&DeployEnv=" + info.Environment);
            request.Headers.Add("Authorization", "Basic " + Settings.WebserviceCredentials);
            request.Timeout = Timeout.Infinite;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return Content(reader.ReadToEnd(), "application/json");
                }
            }
            catch (Exception e)
            {
                return Json(new { error = e.ToString(), stack = e.StackTrace }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}