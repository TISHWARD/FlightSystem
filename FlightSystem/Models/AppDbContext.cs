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

            // Configure relationships here if needed, for example:
            modelBuilder.Entity<MasterBooking>()
                .HasOne(m => m.User)
                .WithMany(u => u.MasterBookings)
                .HasForeignKey(m => m.UserId);

            modelBuilder.Entity<MasterBooking>()
                .HasOne(m => m.Flight)
                .WithMany(f => f.MasterBookings)
                .HasForeignKey(m => m.FlightId);
           
            modelBuilder.Entity<CheckIn>()
                .HasOne(c => c.MasterBooking)
                .WithOne(m => m.CheckIn)
                .HasForeignKey<CheckIn>(static c => c.MasterBookingId);
            modelBuilder.Entity<MasterBooking>().HasKey(m => m.BookingId);

            modelBuilder.Entity<MasterBooking>().Property(m => m.TotalAmount).HasColumnType("decimal(18,2)"); 
            modelBuilder.Entity<Payment>().Property(p => p.AmountPaid).HasColumnType("decimal(18,2)");
        }
    }
}
