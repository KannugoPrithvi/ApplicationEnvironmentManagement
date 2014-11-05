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
            var componentItems = repository.EnvironmentAttributes.Where(p => p.ATTRIBUTETYPE == "Component");
            List<SelectListItem> componentSelectListItems = new List<SelectListItem>();
            foreach (var item in componentItems)
            {
                componentSelectListItems.Add(new SelectListItem { Text=item.ATTRIBUTEVALUE,Value=item.ATTRIBUTEID.ToString()});
            }
            ViewBag.ListItems = componentSelectListItems;
            return View();
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