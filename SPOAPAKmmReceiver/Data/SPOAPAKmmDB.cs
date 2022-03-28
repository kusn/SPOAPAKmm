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

        public DbSet<Measuring> Measurings { get; set; }

        public DbSet<Device> Devices { get; set; }

        public SPOAPAKmmDB(DbContextOptions<SPOAPAKmmDB> opt) : base(opt) { }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }*/
    }
}
