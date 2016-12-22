namespace MassDeffect.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MassDeffectContext : DbContext
    {
        public MassDeffectContext()
            : base("name=MassDeffectContext")
        {
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Star> Stars { get; set; }

        public DbSet<Planet> Planets { get; set; }

        public DbSet<Anomaly> Anomalies { get; set; }

        public DbSet<SolarSystem> SolarSystems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Anomaly>()
            //    .HasOptional(anom => anom.OriginPlanet)
            //    .WithMany(planet => planet.OriginAnomalies)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Anomaly>()
            //    .HasOptional(anom => anom.TeleportPlanet)
            //    .WithMany(planet => planet.TeleportAnomalies)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Anomaly>()
                .HasMany(anom => anom.Victims)
                .WithMany(person => person.Anomalies)
                .Map(configuration =>
                    {
                        configuration.MapLeftKey("AnomalyId");
                        configuration.MapRightKey("PersonId");
                        configuration.ToTable("AnomalyVictims");
                    });

            base.OnModelCreating(modelBuilder);
        }
    }
}