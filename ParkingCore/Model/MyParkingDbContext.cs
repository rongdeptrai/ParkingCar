
using ParkingCore.Models;
using System.Data.Entity;

namespace ParkingCore.Models
{
    public class MyParkingDbContext : DbContext
    {

        public MyParkingDbContext() : base("MyParkingDbContext")
        {

        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<ParkingType> ParkingTypes { get; set; }
        public virtual DbSet<Parking> Parkings { get; set; }
        public virtual DbSet<ParkingSlot> ParkingSlots { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<OrderInvoid> OrderInvoids { get; set; }
        public virtual DbSet<Adminstrator> Adminstrator { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
