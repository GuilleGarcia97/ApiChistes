using ApiChistes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiChistes.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        
        }


        public DbSet<Chiste> Chistes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
