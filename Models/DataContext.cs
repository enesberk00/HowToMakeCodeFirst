
using Microsoft.EntityFrameworkCore;

namespace HowToMakeCodeFirst.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        { 
        
        
        }


        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Oda> Odalar { get; set; }
        public DbSet<Otel> Oteller { get; set; }
        public DbSet<Odeme> Odemeler { get; set; }
        public DbSet<Rezervasyon> Rezervasyonlar { get;set; }

        
    }
}
