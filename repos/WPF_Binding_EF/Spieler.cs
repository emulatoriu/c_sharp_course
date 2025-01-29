namespace WPF_Binding_EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Spieler")]
    public partial class Spieler
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Vorname { get; set; }

        public int? TrainerID { get; set; }
    }
}
