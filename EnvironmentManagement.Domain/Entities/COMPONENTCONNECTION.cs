//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnvironmentManagement.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class COMPONENTCONNECTION
    {
        public decimal COMPONENTCONNECTIONID { get; set; }
        public decimal ENVIRONMENTCOMPONENTID1 { get; set; }
        public decimal ENVIRONMENTCOMPONENTID2 { get; set; }
    
        public virtual ENVIRONMENTCOMPONENT ENVIRONMENTCOMPONENT { get; set; }
        public virtual ENVIRONMENTCOMPONENT ENVIRONMENTCOMPONENT1 { get; set; }
    }
}
