using Microsoft.EntityFrameworkCore;
using Oculus_Clinic_Server.Data.Models;

namespace Oculus_Clinic_Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employeer> Employeers { get; set; }

    } 
}
