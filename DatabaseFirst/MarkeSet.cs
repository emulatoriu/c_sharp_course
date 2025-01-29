namespace DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MarkeSet")]
    public partial class MarkeSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MarkeSet()
        {
            FahrzeugeSet = new HashSet<FahrzeugeSet>();
        }

        public int Id { get; set; }

        [Required]
        public string FMarke { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FahrzeugeSet> FahrzeugeSet { get; set; }
    }
}
