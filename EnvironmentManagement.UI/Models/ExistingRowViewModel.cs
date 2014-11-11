using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvironmentManagement.UI.Models
{
    public class ExistingRowViewModel
    {
        public List<SelectListItem> EnvironmentAttributeList { get; set; }
        public string EnvironmentAttributeValue { get; set; }
        public int RowIndex { get; set; }
        public decimal EnvironmentComponentID { get; set; }
    }
}