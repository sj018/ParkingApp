using Microsoft.EntityFrameworkCore;

namespace ParkingApp.Models
{
    public class ParkingContext : DbContext
    {
        public ParkingContext(DbContextOptions<ParkingContext> options)
            : base(options)
        {
        }

        public DbSet<Parking> ParkingItems { get; set; }

    }
}