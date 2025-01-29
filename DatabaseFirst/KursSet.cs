namespace DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KursSet")]
    public partial class KursSet
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
