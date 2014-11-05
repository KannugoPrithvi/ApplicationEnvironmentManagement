using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentManagement.Domain.Entities
{
    public class ENVIRONMENTCOMPONENT
    {
        public ENVIRONMENTCOMPONENT()
        {
            this.COMPONENTATTRIBUTES = new HashSet<COMPONENTATTRIBUTE>();
            this.COMPONENTCONNECTIONS = new HashSet<COMPONENTCONNECTION>();
            this.COMPONENTCONNECTIONS1 = new HashSet<COMPONENTCONNECTION>();
        }

        public decimal ENVIRONMENTCOMPONENTID { get; set; }
        public Nullable<decimal> ENVIRONMENTID { get; set; }
        public Nullable<decimal> ENVIRONMENTATTRIBUTEID { get; set; }
        public string COMPONENTNAME { get; set; }

        public virtual ICollection<COMPONENTATTRIBUTE> COMPONENTATTRIBUTES { get; set; }
        public virtual ICollection<COMPONENTCONNECTION> COMPONENTCONNECTIONS { get; set; }
        public virtual ICollection<COMPONENTCONNECTION> COMPONENTCONNECTIONS1 { get; set; }
        public virtual ENVIRONMENT ENVIRONMENT { get; set; }
        public virtual ENVIRONMENTATTRIBUTE ENVIRONMENTATTRIBUTE { get; set; }
    }
}
