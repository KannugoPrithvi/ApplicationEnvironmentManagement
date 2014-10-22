using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EnvironmentManagement.Domain.Entities
{
    public class EnvironmentUsers
    {
        [Key]
        public int EnvironmentUserID { get; set; }
        public string UserName { get; set; }
        public string EnvironmentName { get; set; }
        public string EnvironmentDescription { get; set; }
        public string IntendedUsers { get; set; }
        public string Justification { get; set; }

        public virtual ICollection<EnvironmentComponents> EnvironmentComponents { get; set; }
    }
}
