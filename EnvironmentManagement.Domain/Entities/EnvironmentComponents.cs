using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentManagement.Domain.Entities
{
    public class EnvironmentComponents
    {
        public int EnvironmentComponentID { get; set; }
        public int EnvironmentUserID { get; set; }
        public int ComponentID { get; set; }
        public int ComponentOrder { get; set; }
        public int ComponentQuantity { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ComponentAttributes> ComponentAttributes { get; set; }
        public virtual Components Components { get; set; }
        public virtual EnvironmentUsers EnvironmentUser { get; set; }
    }
}
