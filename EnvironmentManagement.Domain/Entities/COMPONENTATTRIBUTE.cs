using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EnvironmentManagement.Domain.Entities
{
    public class COMPONENTATTRIBUTE
    {
        public decimal COMPONENTATTRIBUTEID { get; set; }
        public Nullable<decimal> ENVIRONMENTCOMPONENTID { get; set; }
        public string ATTRIBUTEKEY { get; set; }
        public string ATTRIBUTEVALUE { get; set; }

        public virtual ENVIRONMENTCOMPONENT ENVIRONMENTCOMPONENT { get; set; }
    }
}
