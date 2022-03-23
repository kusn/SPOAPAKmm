using Microsoft.EntityFrameworkCore;
using SPOAPAKmmReceiver.Models;

namespace SPOAPAKmmReceiver.Data
{
    public class SPOAPAKmmReceiverDB : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Element> Elements { get; set; }

        public DbSet<MeasPoint> MeasPoints { get; set; }

        public DbSet<Measuring> Measurings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
