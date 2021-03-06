//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blackgate.DataModel.Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Topic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Topic()
        {
            this.Topic1 = new HashSet<Topic>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ParentId { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime CreationDate { get; set; }
        public System.DateTime ModificationDate { get; set; }
        public byte Progress { get; set; }
        public bool IsEnabled { get; set; }
    
        public virtual Course Course { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Topic> Topic1 { get; set; }
        public virtual Topic Topic2 { get; set; }
    }
}
