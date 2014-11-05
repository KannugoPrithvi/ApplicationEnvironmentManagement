using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentManagement.Domain.Entities
{
    public class ENVIRONMENTATTRIBUTE
    {
        public ENVIRONMENTATTRIBUTE()
        {
            this.ENVIRONMENTs = new HashSet<ENVIRONMENT>();
            this.ENVIRONMENTs1 = new HashSet<ENVIRONMENT>();
            this.ENVIRONMENTs2 = new HashSet<ENVIRONMENT>();
            this.ENVIRONMENTCOMPONENTS = new HashSet<ENVIRONMENTCOMPONENT>();
        }

        public decimal ATTRIBUTEID { get; set; }
        public string ATTRIBUTETYPE { get; set; }
        public string ATTRIBUTEVALUE { get; set; }
        public string ATTRIBUTEDESCRIPTION { get; set; }

        public virtual ICollection<ENVIRONMENT> ENVIRONMENTs { get; set; }
        public virtual ICollection<ENVIRONMENT> ENVIRONMENTs1 { get; set; }
        public virtual ICollection<ENVIRONMENT> ENVIRONMENTs2 { get; set; }
        public virtual ICollection<ENVIRONMENTCOMPONENT> ENVIRONMENTCOMPONENTS { get; set; }
    }
}
