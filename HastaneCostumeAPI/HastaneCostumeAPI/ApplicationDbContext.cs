using HastaneCostumeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HastaneCostumeAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
   
     
        public DbSet<Iletisim>? Iletisim { get; set; }
       
       
    }
}