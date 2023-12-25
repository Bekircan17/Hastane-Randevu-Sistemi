using HastaneRandevuSau.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HastaneRandevuSau.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
   
        public DbSet<Doktor> Doktor { get; set; }
        public DbSet<Randevu> Randevu { get; set;}
        public DbSet<HastaneRandevuSau.Models.Iletisim>? Iletisim { get; set; }
        public DbSet<HastaneRandevuSau.Models.DoktorCalisma>? DoktorCalisma { get; set; }
      
       
    }
}