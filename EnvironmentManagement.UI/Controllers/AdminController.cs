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
        public ActionResult Edit(string AttributeType = null)
        {
            return null;
        }
        [HttpPost]
        public ActionResult Edit(ENVIRONMENTATTRIBUTE environmentAttribute)
        {
            return null;
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
    }
}