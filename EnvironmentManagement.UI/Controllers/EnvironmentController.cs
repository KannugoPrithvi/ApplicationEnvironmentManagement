using EnvironmentManagement.Domain.Abstract;
using EnvironmentManagement.Domain.Concrete;
using EnvironmentManagement.Domain.Entities;
using EnvironmentManagement.UI.Models;
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
            List<EnvironmentListViewModel> listOfEnvironments = (from result in repository.Environments
                                                                 select new EnvironmentListViewModel
                                                                 {
                                                                     ENVIRONMENTID = result.ENVIRONMENTID,
                                                                     ENVIRONMENTNAME = result.ENVIRONMENTNAME,
                                                                     ENVIRONMENTZONE = result.ENVIRONMENTZONE,
                                                                     INTENDEDUSERS = result.INTENDEDUSERS,
                                                                     WORKINGSTATUS = result.WORKINGSTATUS
                                                                 }).ToList<EnvironmentListViewModel>();
            return View(listOfEnvironments);
        }
        public ActionResult Create()
        {
            return RedirectToAction("Edit");
        }
        [HttpGet]
        public ActionResult Edit(int EnvironmentID = 0)
        {
            var environmentName = repository.EnvironmentAttributes.Where(p => p.ATTRIBUTETYPE == "Environment");
            List<SelectListItem> environmentNameSelectListItems = new List<SelectListItem>();
            foreach (var item in environmentName)
            {
                environmentNameSelectListItems.Add(new SelectListItem { Text = item.ATTRIBUTEVALUE, Value = item.ATTRIBUTEVALUE.ToString() });
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
                workingStatusListItems.Add(new SelectListItem { Text = item.ATTRIBUTEVALUE, Value = item.ATTRIBUTEVALUE.ToString() });
            }
            ViewBag.WorkingStatus = workingStatusListItems;
            if (EnvironmentID != 0)
            {
                ENVIRONMENT environment = repository.Environments.FirstOrDefault(p => p.ENVIRONMENTID == EnvironmentID);
                if (environment != null)
                {
                    return View(environment);
                }
                else
                {
                    return View(new ENVIRONMENT());
                }
            }
            else
            {
                return View(new ENVIRONMENT());
            }
        }

        public PartialViewResult NewComponentRow(int Index = 0)
        {
            var componentItems = repository.EnvironmentAttributes.Where(p => p.ATTRIBUTETYPE == "Component");
            List<SelectListItem> componentSelectListItems = new List<SelectListItem>();
            foreach (var item in componentItems)
            {
                componentSelectListItems.Add(new SelectListItem { Text = item.ATTRIBUTEVALUE, Value = item.ATTRIBUTEVALUE.ToString() });
            }
            ViewBag.EnvironmentComponent = componentSelectListItems;
            //ViewBag.Index = Index;
            return PartialView("Partial/_EnvironmentComponentRowInsert", Index);
        }

        [HttpPost]
        public ActionResult Edit(ENVIRONMENT environment)
        {
            if (environment != null && ModelState.IsValid)
            {
                repository.SaveEnvironment(environment);
                TempData["Message"] = "Environment saved successfully";
                return View("Index");
            }
            else
            {
                return View();
            }
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