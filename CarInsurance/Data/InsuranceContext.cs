using CarInsurance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarInsurance.Data
{
    // This class connects the app to the database
    public class InsuranceContext : DbContext
    {
        // Constructor receives database options
        public InsuranceContext(DbContextOptions<InsuranceContext> options)
            : base(options)
        {
        }

        // This creates the Insurees table
        public DbSet<Insuree> Insurees { get; set; }
    }
}