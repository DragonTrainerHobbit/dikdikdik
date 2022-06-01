using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WpfEFKutyak
{
    public partial class KutyaModel : DbContext
    {
        public KutyaModel()
            : base("name=KutyaModel")
        {
        }

        public virtual DbSet<Kutyafajtak> Kutyafajtak { get; set; }
        public virtual DbSet<Kutyak> Kutyak { get; set; }
        public virtual DbSet<Kutyanevek> Kutyanevek { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kutyafajtak>()
                .HasMany(e => e.Kutyak)
                .WithRequired(e => e.Kutyafajtak)
                .HasForeignKey(e => e.fajtaid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kutyanevek>()
                .HasMany(e => e.Kutyak)
                .WithRequired(e => e.Kutyanevek)
                .HasForeignKey(e => e.nevid)
                .WillCascadeOnDelete(false);
        }
    }
}
