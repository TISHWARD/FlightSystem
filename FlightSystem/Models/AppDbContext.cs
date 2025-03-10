using Microsoft.EntityFrameworkCore;

namespace FlightBookingSystemAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<MasterBooking> MasterBookings { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<CheckIn> CheckIns { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships here if needed:

            // One-to-many relationship between User and MasterBooking
            modelBuilder.Entity<MasterBooking>()
                .HasOne(m => m.User)  // MasterBooking has one User
                .WithMany(u => u.MasterBookings)  // User can have many MasterBookings
                .HasForeignKey(m => m.UserId)  // Foreign key is UserId in MasterBooking
                .OnDelete(DeleteBehavior.Cascade);  // Optional: Define behavior on delete

            // One-to-many relationship between Flig
            modelBuilder.Entity<CheckIn>()
       .HasOne(c => c.MasterBooking)
       .WithOne(m => m.CheckIn)
       .HasForeignKey<CheckIn>(c => c.MasterBookingId);
        }
    }
}