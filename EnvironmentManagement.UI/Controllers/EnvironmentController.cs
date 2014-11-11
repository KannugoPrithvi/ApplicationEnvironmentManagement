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
        public ActionResult Index(string UserName = null)
        {
            List<EnvironmentListViewModel> listOfEnvironments = null;
            if(UserName == null)
            {
                listOfEnvironments = (from result in repository.Environments
                                                                     select new EnvironmentListViewModel
                                                                     {
                                                                         ENVIRONMENTID = result.ENVIRONMENTID,
                                                                         ENVIRONMENTNAME = result.ENVIRONMENTNAME,
                                                                         ENVIRONMENTZONE = result.ENVIRONMENTZONE,
                                                                         INTENDEDUSERS = result.INTENDEDUSERS,
                                                                         WORKINGSTATUS = result.WORKINGSTATUS
                                                                     }).ToList<EnvironmentListViewModel>();
            }
            else
            {
                listOfEnvironments = (from result in repository.Environments.Where(c => c.USERNAME.Contains(UserName))
                                      select new EnvironmentListViewModel
                                      {
                                          ENVIRONMENTID = result.ENVIRONMENTID,
                                          ENVIRONMENTNAME = result.ENVIRONMENTNAME,
                                          ENVIRONMENTZONE = result.ENVIRONMENTZONE,
                                          INTENDEDUSERS = result.INTENDEDUSERS,
                                          WORKINGSTATUS = result.WORKINGSTATUS
                                      }).ToList<EnvironmentListViewModel>();
            }
            
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

            var environmentZone = repository.EnvironmentAttributes.Where(p => p.ATTRIBUTETYPE == "ZONE");
            List<SelectListItem> environmentZoneSelectListItems = new List<SelectListItem>();

            var workingStatus = repository.EnvironmentAttributes.Where(p => p.ATTRIBUTETYPE == "WorkingStatus");
            List<SelectListItem> workingStatusListItems = new List<SelectListItem>();
            if (EnvironmentID == 0)
            {
                foreach (var item in environmentName)
                {
                    environmentNameSelectListItems.Add(new SelectListItem { Text = item.ATTRIBUTEVALUE, Value = item.ATTRIBUTEVALUE.ToString() });
                }
                foreach (var item in environmentZone)
                {
                    environmentZoneSelectListItems.Add(new SelectListItem { Text = item.ATTRIBUTEVALUE, Value = item.ATTRIBUTEVALUE.ToString() });
                }
                foreach (var item in workingStatus)
                {
                    workingStatusListItems.Add(new SelectListItem { Text = item.ATTRIBUTEVALUE, Value = item.ATTRIBUTEVALUE.ToString() });
                }
                ViewBag.EnvironmentNameItems = environmentNameSelectListItems;
                ViewBag.EnvironmentZoneItems = environmentZoneSelectListItems;
                ViewBag.WorkingStatusItems = workingStatusListItems;
                return View(new ENVIRONMENT());
            }
            else
            {
                ENVIRONMENT environment = repository.Environments.FirstOrDefault(p => p.ENVIRONMENTID == EnvironmentID);
                foreach (var item in environmentName)
                {
                    if (environment.ENVIRONMENTNAME == item.ATTRIBUTEVALUE)
                    {
                        environmentNameSelectListItems.Add(new SelectListItem { Text = item.ATTRIBUTEVALUE, Value = item.ATTRIBUTEVALUE.ToString(), Selected = true });
                    }
                    else
                    {
                        environmentNameSelectListItems.Add(new SelectListItem { Text = item.ATTRIBUTEVALUE, Value = item.ATTRIBUTEVALUE.ToString() });
                    }

                }
                foreach (var item in environmentZone)
                {
                    if (environment.ENVIRONMENTZONE == item.ATTRIBUTEVALUE)
                    {
                        environmentZoneSelectListItems.Add(new SelectListItem { Text = item.ATTRIBUTEVALUE, Value = item.ATTRIBUTEVALUE.ToString(), Selected = true });
                    }
                    else
                    {
                        environmentZoneSelectListItems.Add(new SelectListItem { Text = item.ATTRIBUTEVALUE, Value = item.ATTRIBUTEVALUE.ToString() });
                    }
                }
                foreach (var item in workingStatus)
                {
                    if (environment.WORKINGSTATUS == item.ATTRIBUTEVALUE)
                    {
                        workingStatusListItems.Add(new SelectListItem { Text = item.ATTRIBUTEVALUE, Value = item.ATTRIBUTEVALUE.ToString(), Selected = true });
                    }
                    else
                    {
                        workingStatusListItems.Add(new SelectListItem { Text = item.ATTRIBUTEVALUE, Value = item.ATTRIBUTEVALUE.ToString() });
                    }
                }
                ViewBag.EnvironmentNameItems = environmentNameSelectListItems;
                ViewBag.EnvironmentZoneItems = environmentZoneSelectListItems;
                ViewBag.WorkingStatusItems = workingStatusListItems;
                return View(environment);
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
        public PartialViewResult ExistingComponentRow(ENVIRONMENTCOMPONENT EnvironmentComponent,int index = 0)
        {
            var componentItems = repository.EnvironmentAttributes.Where(p => p.ATTRIBUTETYPE == "Component");
            List<SelectListItem> componentSelectListItems = new List<SelectListItem>();
            foreach (var item in componentItems)
            {
                if(item.ATTRIBUTEVALUE.Equals(EnvironmentComponent.ENVIRONMENTATTRIBUTE))
                {
                    componentSelectListItems.Add(new SelectListItem { Text = item.ATTRIBUTEVALUE, Value = item.ATTRIBUTEVALUE.ToString(),Selected=true });
                }
                else
                {
                    componentSelectListItems.Add(new SelectListItem { Text = item.ATTRIBUTEVALUE, Value = item.ATTRIBUTEVALUE.ToString(),Selected=false });
                }
            }
            ExistingRowViewModel existingRowViewModel = new ExistingRowViewModel
            {
                EnvironmentAttributeList=componentSelectListItems,
                EnvironmentAttributeValue=EnvironmentComponent.COMPONENTNAME,
                RowIndex=index,
                EnvironmentComponentID=EnvironmentComponent.ENVIRONMENTCOMPONENTID
            };
            return PartialView("Partial/_EnvironmentExistingRowComponentAttributes",existingRowViewModel);
        }
        [HttpPost]
        public ActionResult Edit(ENVIRONMENT environment)
        {
            if (environment != null && ModelState.IsValid)
            {
                repository.SaveEnvironment(environment);
                TempData["Message"] = "Environment \"" + environment.ENVIRONMENTNAME + "\" saved successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"] = "Environment \"" + environment.ENVIRONMENTNAME + "\" could not be saved successfully";
                return View();
            }
        }        
        public ActionResult Details(int EnvironmentID = 0)
        {
            ViewBag.EnvironmentID = EnvironmentID;
            return View();
        }

        public ActionResult Delete()
        {
            return null;
        }
    }
}