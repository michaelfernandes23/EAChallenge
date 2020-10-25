using System;
using Microsoft.EntityFrameworkCore;
using EAChallenge.Domain.Entities;

namespace EAChallenge.Infrastructure
{
    public class EAChallengeDBContext : DbContext
    {
        public EAChallengeDBContext(DbContextOptions<EAChallengeDBContext> options) : base(options)
        {

        }

        public DbSet<Culture> Cultures { get; set; }
        public DbSet<LocalizationSet> LocalizationSets { get; set; }
        public DbSet<Localization> Localization { get; set; }
        public DbSet<CarDetails> CarDetails { get; set; }
        public DbSet<AuctionDetails> AuctionDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Culture>(etb =>
            {
                etb.HasKey(e => e.Code);
                etb.Property(e => e.Name).IsRequired().HasMaxLength(64);
                etb.ToTable("Cultures");
            }
            );

            modelBuilder.Entity<LocalizationSet>(etb =>
            {
                etb.HasKey(e => e.Id);
                etb.ToTable("LocalizationSets");
            }
            );

            modelBuilder.Entity<Localization>(etb =>
            {
                etb.HasKey(e => new { e.LocalizationSetId, e.CultureCode });
                etb.ToTable("Localization");
            }
            );

            modelBuilder.Entity<CarDetails>(etb =>
            {
                etb.HasKey(e => e.Id);
                etb.ToTable("CarDetails");
            }
            );

            modelBuilder.Entity<AuctionDetails>(etb =>
            {
                etb.HasKey(e => e.Id);
                etb.ToTable("AuctionDetails");
            }
            );
        }
    }
}
