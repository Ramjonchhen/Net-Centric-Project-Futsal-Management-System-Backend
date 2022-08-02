using Microsoft.EntityFrameworkCore;

namespace Net_Centric_Project__Futsal_Management_System__Backend.Models
{
    public class FutsalManagementDBContext: DbContext
    {
        public FutsalManagementDBContext(DbContextOptions<FutsalManagementDBContext> options): base(options) { }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .HasKey(c => new { c.AdminId, c.Email });
        }
    }
}
