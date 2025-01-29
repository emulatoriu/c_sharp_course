namespace DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Restaurants
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Restaurants()
        {
            Tables = new HashSet<Tables>();
        }

        [Key]
        public long ResID { get; set; }

        [StringLength(50)]
        public string CompanyName { get; set; }

        [StringLength(50)]
        public string RestName { get; set; }

        [StringLength(50)]
        public string Reststreet { get; set; }

        public int? AddrHouseNumber { get; set; }

        public long? PLZ { get; set; }

        public int? AddrDoorNumber { get; set; }

        public virtual Postalcode Postalcode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tables> Tables { get; set; }
    }
}
