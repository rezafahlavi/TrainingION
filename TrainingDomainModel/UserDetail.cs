//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainingDomainModel
{
    using System;
    using DomainModelFramework;using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    
    public partial class UserDetail : BaseEntity
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        
        
        
        
    
        public virtual User User { get; set; }
    }
}
