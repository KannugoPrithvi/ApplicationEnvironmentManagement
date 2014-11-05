using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentManagement.Domain.Entities
{
    public class ENVIRONMENT
    {
        public ENVIRONMENT()
        {
            this.ENVIRONMENTCOMPONENTS = new HashSet<ENVIRONMENTCOMPONENT>();
        }

        public decimal ENVIRONMENTID { get; set; }
        public string USERNAME { get; set; }
        public decimal ENVIRONMENTNAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string INTENDEDUSERS { get; set; }
        public Nullable<decimal> ENVIRONMENTZONE { get; set; }
        public Nullable<decimal> WORKINGSTATUS { get; set; }
        public string JUSTIFICATION { get; set; }

        public virtual ICollection<ENVIRONMENTCOMPONENT> ENVIRONMENTCOMPONENTS { get; set; }
        public virtual ENVIRONMENTATTRIBUTE ENVIRONMENTATTRIBUTE { get; set; }
        public virtual ENVIRONMENTATTRIBUTE ENVIRONMENTATTRIBUTE1 { get; set; }
        public virtual ENVIRONMENTATTRIBUTE ENVIRONMENTATTRIBUTE2 { get; set; }
    }
}
