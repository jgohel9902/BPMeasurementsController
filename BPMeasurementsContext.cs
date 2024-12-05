using Microsoft.EntityFrameworkCore;
namespace mswebtechAssignment1.Models
{
    public class BPMeasurementsContext : DbContext
    {
        public BPMeasurementsContext(DbContextOptions<BPMeasurementsContext> options) : base(options) { }

        public DbSet<BPMeasurement> BPMeasurements { get; set; }
    }
}
