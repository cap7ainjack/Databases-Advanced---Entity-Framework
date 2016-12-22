namespace PhotographyWorkshops.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class PhotographyWorkshopsContext : DbContext
    {
        public PhotographyWorkshopsContext()
            : base("name=PhotographyWorkshopsContext")
        {
        }

        public DbSet<Accessory> Accessories { get; set; }

        public DbSet<Camera> Cameras { get; set; }

        public DbSet<Len> Lens { get; set; }

        public DbSet<Photographer> Photographers { get; set; }

        public DbSet<Workshop> Workshops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photographer>()
                .HasRequired(pht => pht.PrimaryCamera)
                .WithMany(camera => camera.PrimaryOwners)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Photographer>()
                .HasRequired(pht => pht.SecondaryCamera)
                .WithMany(camera => camera.SecondaryOwners)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Photographer>()
                .HasMany(pht => pht.WorkshopsParticipatedIn)
                .WithMany(wokrsh => wokrsh.Participants)
                .Map(configuration =>
                {
                    configuration.MapLeftKey("PhotographerId");
                    configuration.MapRightKey("WorkshopId");
                    configuration.ToTable("PhotographerWorkshops");
                });

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

    }
}