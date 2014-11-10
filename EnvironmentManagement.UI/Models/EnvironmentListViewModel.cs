using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnvironmentManagement.UI.Models
{
    public class EnvironmentListViewModel
    {
        public decimal ENVIRONMENTID { get; set; }
        public string ENVIRONMENTNAME { get; set; }
        public string INTENDEDUSERS { get; set; }
        public string ENVIRONMENTZONE { get; set; }
        public string WORKINGSTATUS { get; set; }
    }
}