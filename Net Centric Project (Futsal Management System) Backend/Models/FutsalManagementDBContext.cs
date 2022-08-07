using Microsoft.EntityFrameworkCore;
using Net_Centric_Project__Futsal_Management_System__Backend.Converters;

namespace Net_Centric_Project__Futsal_Management_System__Backend.Models
{
    public class FutsalManagementDBContext: DbContext
    {
        public FutsalManagementDBContext(DbContextOptions<FutsalManagementDBContext> options): base(options) { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Futsal> Futsals { get; set; }


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           

            modelBuilder.Entity<Admin>()
                .HasIndex(x => x.Email)
                .IsUnique(true);
             
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<DateOnly>()
                                .HaveConversion<DateOnlyEFConverter>()
                                .HaveColumnType("date");

            configurationBuilder.Properties<TimeOnly>()
                      .HaveConversion<TimeOnlyEFConverter>()
                      .HaveColumnType("time");
        }



    }
}
