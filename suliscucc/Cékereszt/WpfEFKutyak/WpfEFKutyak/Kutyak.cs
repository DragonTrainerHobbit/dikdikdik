namespace WpfEFKutyak
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kutyak")]
    public partial class Kutyak
    {
        public int id { get; set; }

        public int fajtaid { get; set; }

        public int nevid { get; set; }

        public int eletkor { get; set; }

        [Column(TypeName = "date")]
        public DateTime utolsoellenorzes { get; set; }

        public virtual Kutyafajtak Kutyafajtak { get; set; }

        public virtual Kutyanevek Kutyanevek { get; set; }
    }
}
