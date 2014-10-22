using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvironmentManagement.UI.Controllers
{
    public class EnvironmentController : Controller
    {
        // GET: Environment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return RedirectToAction("Edit");
        }
        [HttpGet]
        public ActionResult Edit(int environmentID)
        {
            return null;
        }
        [HttpPost]
        public ActionResult Edit()
        {
            return null;
        }

        public ActionResult Details()
        {
            return null;
        }

        public ActionResult Delete()
        {
            return null;
        }
    }
}