using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EnvironmentManagement.Domain.Entities
{
    public class Components
    {
        [Key]
        public int ComponentID { get; set; }
        public string ComponentName { get; set; }
        public string ComponentDescription { get; set; }

        public virtual ICollection<EnvironmentComponents> EnvironmentComponents { get; set; }
    }
}
