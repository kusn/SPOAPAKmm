using Microsoft.EntityFrameworkCore;
using SPOAPAKmmReceiver.Entities;

namespace SPOAPAKmmReceiver.Data
{
    class SPOAPAKmmDB : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Element> Elements { get; set; }

        public DbSet<MeasPoint> MeasPoints { get; set; }

        public DbSet<MeasureItem> Measurings { get; set; }

        public DbSet<Device> Devices { get; set; }

        public DbSet<Levels> Levels { get; set; }

        public DbSet<DeviceType> DeviceTypes { get; set; }

        public SPOAPAKmmDB(DbContextOptions<SPOAPAKmmDB> opt) : base(opt) { }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }*/
    }
}
