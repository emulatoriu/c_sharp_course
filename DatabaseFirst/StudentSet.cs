namespace DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentSet")]
    public partial class StudentSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentSet()
        {
            KursStudent = new HashSet<KursStudent>();
        }

        public long Id { get; set; }

        [Required]
        public string Vorname { get; set; }

        [Required]
        public string Nachname { get; set; }

        public short Alter { get; set; }

        [Required]
        public string Matrikelnummer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KursStudent> KursStudent { get; set; }
    }
}
