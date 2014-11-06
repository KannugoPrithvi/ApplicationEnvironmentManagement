using EnvironmentManagement.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvironmentManagement.UI.Controllers
{
    public class ComponentController : Controller
    {
        private IEnvironmentRepository repository;

        public ComponentController(IEnvironmentRepository repo)
        {
            repository = repo;
        }
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
        public ActionResult Edit(int componentID = 0)
        {
            return View("Edit");
        }

        //Edit Post
        [HttpPost]
        public ActionResult Edit()
        {
            return View("Edit");
        }

        public PartialViewResult NewComponentAttributeRow()
        {
            var componentAttribute = repository.EnvironmentAttributes.Where(p => p.ATTRIBUTETYPE == "ComponentAttribute");
            List<SelectListItem> componentAttributeList = new List<SelectListItem>();
            foreach (var item in componentAttribute)
            {
                componentAttributeList.Add(new SelectListItem { Text = item.ATTRIBUTEVALUE, Value = item.ATTRIBUTEVALUE });
            }
            ViewBag.componentDropDownList = componentAttributeList;
            return PartialView("Partial/_ComponentAttributeRowInsert");
        }
        //Details Get
        public ActionResult Details(int componentID)
        {
            return View("Details");
        }

    }
}