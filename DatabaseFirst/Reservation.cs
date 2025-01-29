namespace DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reservation")]
    public partial class Reservation
    {
        [Key]
        public long ReserveID { get; set; }

        public long? Tid { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        [StringLength(20)]
        public string PersonFirst { get; set; }

        [StringLength(20)]
        public string PersonLast { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public virtual Tables Tables { get; set; }
    }
}
