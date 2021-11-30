using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace findabeer.Models
{
    public class FindABeerContext : DbContext
    {
        public FindABeerContext(DbContextOptions<FindABeerContext> options)
            : base(options)
        {
        }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<VenueTag> VenueTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: do the data import here in a hacky way
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VenueTag>()
                .HasKey(vt => new { vt.TagId, vt.VenueId });

            builder.Entity<Venue>()
                .HasIndex(v => v.Url)
                .IsUnique();

            builder.Entity<Tag>()
                .HasIndex(t => t.Name)
                .IsUnique();
        }

    }
}