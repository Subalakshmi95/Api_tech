using Api_tech.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_tech.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>opt):base(opt)
        {
            
        }
        public DbSet<Product> ProductDetails {  get; set; }
    }
}
