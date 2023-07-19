using Microsoft.EntityFrameworkCore;

namespace dotNet_api_service.Models.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
        }
       
        public DbSet<Villa> Villas { get; set; }
    }
}
