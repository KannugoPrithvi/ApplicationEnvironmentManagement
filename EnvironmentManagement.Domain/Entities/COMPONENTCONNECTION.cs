using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentManagement.Domain.Entities
{
    public class COMPONENTCONNECTION
    {
        public decimal COMPONENTCONNECTIONID { get; set; }
        public decimal ENVIRONMENTCOMPONENTID1 { get; set; }
        public decimal ENVIRONMENTCOMPONENTID2 { get; set; }

        public virtual ENVIRONMENTCOMPONENT ENVIRONMENTCOMPONENT { get; set; }
        public virtual ENVIRONMENTCOMPONENT ENVIRONMENTCOMPONENT1 { get; set; }
    }
}
