namespace DatabaseFirstWIFI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Studenten")]
    public partial class Studenten
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Studenten()
        {
            Kurse = new HashSet<Kurse>();
        }

        public long StudentenID { get; set; }

        [Required]
        [StringLength(10)]
        public string Vorname { get; set; }

        [Required]
        [StringLength(10)]
        public string Nachname { get; set; }

        [Required]
        [StringLength(10)]
        public string Matrikelnummer { get; set; }

        [Column(TypeName = "date")]
        public DateTime Geburtsdatum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kurse> Kurse { get; set; }
    }
}
