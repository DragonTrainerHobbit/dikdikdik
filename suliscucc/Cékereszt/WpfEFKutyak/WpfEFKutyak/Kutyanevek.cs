namespace WpfEFKutyak
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kutyanevek")]
    public partial class Kutyanevek
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kutyanevek()
        {
            Kutyak = new HashSet<Kutyak>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string kutyanev { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kutyak> Kutyak { get; set; }
    }
}
