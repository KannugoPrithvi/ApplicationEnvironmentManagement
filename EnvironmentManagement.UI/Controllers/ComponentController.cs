using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvironmentManagement.UI.Controllers
{
    public class ComponentController : Controller
    {
        // GET: Component
        public ActionResult Index()
        {
            return View();
        }

        //Create Attribute
        public ActionResult Create()
        {
            return RedirectToAction("Edit");
        }

        //Edit Get
        [HttpGet]
        public ActionResult Edit(int componentID=0)
        {
            return View("Edit");
        }

        //Edit Post
        [HttpPost]
        public ActionResult Edit()
        {
            return View("Edit");
        }

        //Details Get
        public ActionResult Details(int componentID)
        {
            return View("Details");
        }

    }
}