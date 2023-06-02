using Microsoft.EntityFrameworkCore;
using SPOAPAKmmReceiver.Entities;

namespace SPOAPAKmmReceiver.Data
{
    internal class SPOAPAKmmDB : DbContext
    {
        public SPOAPAKmmDB(DbContextOptions<SPOAPAKmmDB> opt) : base(opt)
        {
        }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Element> Elements { get; set; }

        public DbSet<MeasPoint> MeasPoints { get; set; }

        public DbSet<MeasureItem> Measurings { get; set; }

        public DbSet<Device> Devices { get; set; }

        public DbSet<Levels> Levels { get; set; }

        public DbSet<DeviceType> DeviceTypes { get; set; }

        public DbSet<MeasSettings> MeasSettings { get; set; }

        public DbSet<Frequency> Frequencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeviceType>()
                .HasIndex(t => t.Name).IsUnique();
        }
    }
}