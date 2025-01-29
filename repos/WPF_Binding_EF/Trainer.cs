namespace WPF_Binding_EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trainer")]
    public partial class Trainer
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Vorname { get; set; }

        [Required]
        [StringLength(20)]
        public string Nachname { get; set; }
    }
}
