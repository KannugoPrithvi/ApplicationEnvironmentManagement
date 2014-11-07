using EnvironmentManagement.Domain.Abstract;
using EnvironmentManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvironmentManagement.UI.Controllers
{
    public class AdminController : Controller
    {
        private IEnvironmentRepository repository;
        public AdminController(IEnvironmentRepository repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ActionResult Index()
        {
            var uniqueEnvAttributes = repository.EnvironmentAttributes
                .Select(p => p.ATTRIBUTETYPE)
                .Distinct();

            List<string> distinctComAttributes = new List<string>();
            foreach (var item in uniqueEnvAttributes)
            {
                distinctComAttributes.Add(item.ToString());
            }
            return View(distinctComAttributes);
        }

        [HttpGet]
        public ActionResult Edit(int AttributeID = 0,string AttributeType = null)
        {
            ENVIRONMENTATTRIBUTE enviornmentAttribute = repository.EnvironmentAttributes.FirstOrDefault(p => p.ATTRIBUTEID == AttributeID);
            if (enviornmentAttribute != null)
            {
                return View(enviornmentAttribute);
            }
            else
            {                
                return View(new ENVIRONMENTATTRIBUTE { ATTRIBUTETYPE = AttributeType });
            }
        }
        public ActionResult Create(string AttributeType = null)
        {
            return RedirectToAction("Edit");
        }
        [HttpPost]
        public ActionResult Edit(ENVIRONMENTATTRIBUTE environmentAttribute)
        {
            if (environmentAttribute != null && ModelState.IsValid)
            {
                repository.SaveEnvironmentAttribute(environmentAttribute);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Detail(string AttributeType = null)
        {

            if (AttributeType != null)
            {
                var distinctAttribute = repository.EnvironmentAttributes.Where(p => p.ATTRIBUTETYPE.Equals(AttributeType));
                ViewBag.AttributeType = AttributeType;
                List<ENVIRONMENTATTRIBUTE> distinctAttributeList = new List<ENVIRONMENTATTRIBUTE>();
                foreach (var item in distinctAttribute)
                {
                    distinctAttributeList.Add(item);
                }
                return View(distinctAttributeList);
            }
            else
            {
                return View(new List<ENVIRONMENTATTRIBUTE> { new ENVIRONMENTATTRIBUTE() });
            }
        }
        public ActionResult Delete(int AttributeID = 0)
        {
            if(AttributeID != 0)
            {
                ENVIRONMENTATTRIBUTE environmentAttribute = repository.DeleteEnvironmentAttribute(AttributeID);
                TempData["Message"] = "Environment Attribute Deleted Successfully";
                return Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                TempData["Message"] = "Environment Attribute Could not be deleted successfully";
                return RedirectToAction("Index");
            }
        }
    }
}