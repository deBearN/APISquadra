using APISquadra.Models;
using Microsoft.EntityFrameworkCore;

namespace APISquadra.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions) 
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Produto> Produto { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasKey(x => x.userId);
            modelBuilder.Entity<Produto>()
                .HasKey(x => x.ProdutoID);
        }
    }
}
