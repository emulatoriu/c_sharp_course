namespace DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Postalcode")]
    public partial class Postalcode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Postalcode()
        {
            Restaurants = new HashSet<Restaurants>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long PLZ { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Restaurants> Restaurants { get; set; }
    }
}
