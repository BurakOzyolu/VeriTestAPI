using Microsoft.EntityFrameworkCore;

namespace VeriTestAPI.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Harcama> Harcamalar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
    }
}
