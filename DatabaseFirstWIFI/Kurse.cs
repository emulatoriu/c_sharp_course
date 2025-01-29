namespace DatabaseFirstWIFI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kurse")]
    public partial class Kurse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kurse()
        {
            Studenten = new HashSet<Studenten>();
        }

        [Key]
        public long KursID { get; set; }

        [Required]
        [StringLength(10)]
        public string Kursbezeichnung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Studenten> Studenten { get; set; }
    }
}
