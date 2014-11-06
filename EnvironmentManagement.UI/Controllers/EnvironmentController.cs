using EnvironmentManagement.Domain.Abstract;
using EnvironmentManagement.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvironmentManagement.UI.Controllers
{
    public class EnvironmentController : Controller
    {
        //IEnvironmentRepository repository = new EnvironmentRepository();
        IEnvironmentRepository repository = null;
        public EnvironmentController(IEnvironmentRepository repo)
        {
            repository = repo;
        }
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
        public ActionResult Edit(int environmentID = 0)
        {            
            var environmentName = repository.EnvironmentAttributes.Where(p => p.ATTRIBUTETYPE == "Environment");
            List<SelectListItem> environmentNameSelectListItems = new List<SelectListItem>();
            foreach (var item in environmentName)
            {
                environmentNameSelectListItems.Add(new SelectListItem { Text = item.ATTRIBUTEVALUE, Value = item.ATTRIBUTEID.ToString() });
            }
            ViewBag.EnvironmentName = environmentNameSelectListItems;
            var environmentZone = repository.EnvironmentAttributes.Where(p => p.ATTRIBUTETYPE == "ZONE");
            List<SelectListItem> environmentZoneSelectListItems = new List<SelectListItem>();
            foreach (var item in environmentZone)
            {
                environmentZoneSelectListItems.Add(new SelectListItem { Text = item.ATTRIBUTEVALUE, Value = item.ATTRIBUTEVALUE.ToString() });
            }
            ViewBag.EnvironmentZone = environmentZoneSelectListItems;
            var workingStatus = repository.EnvironmentAttributes.Where(p => p.ATTRIBUTETYPE == "WorkingStatus");
            List<SelectListItem> workingStatusListItems = new List<SelectListItem>();
            foreach (var item in workingStatus)
            {
                workingStatusListItems.Add(new SelectListItem { Text = item.ATTRIBUTEVALUE, Value = item.ATTRIBUTEID.ToString() });
            }
            ViewBag.WorkingStatus = workingStatusListItems;
            return View();
        }

        public PartialViewResult NewComponentRow()
        {
            var componentItems = repository.EnvironmentAttributes.Where(p => p.ATTRIBUTETYPE == "Component");
            List<SelectListItem> componentSelectListItems = new List<SelectListItem>();
            foreach (var item in componentItems)
            {
                componentSelectListItems.Add(new SelectListItem { Text = item.ATTRIBUTEVALUE, Value = item.ATTRIBUTEID.ToString() });
            }
            ViewBag.EnvironmentComponent = componentSelectListItems;
            return PartialView("Partial/_EnvironmentComponentRowInsert");
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