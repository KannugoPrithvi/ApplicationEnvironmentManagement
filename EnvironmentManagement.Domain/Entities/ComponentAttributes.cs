using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EnvironmentManagement.Domain.Entities
{
    public class ComponentAttributes
    {
        [Key]
        public int ComponentAttributeID { get; set; }
        public int EnvironmentComponentID { get; set; }
        public string AttributeDescription { get; set; }

        public virtual EnvironmentComponents EnvironmentComponents { get; set; }
    }
}
