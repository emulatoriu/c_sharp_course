namespace DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FahrzeugeSet")]
    public partial class FahrzeugeSet
    {
        public int Id { get; set; }

        public int Marke { get; set; }

        public DateTime Erstzulassung { get; set; }

        public short PS { get; set; }

        [Required]
        public string Farbe { get; set; }

        public int Marke1_Id { get; set; }

        public virtual MarkeSet MarkeSet { get; set; }
    }
}
