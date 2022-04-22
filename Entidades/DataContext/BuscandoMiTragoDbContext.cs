using Entidades.Dominio;
using Microsoft.EntityFrameworkCore;
namespace Entidades.DataContext
{
    public class BuscandoMiTragoDbContext : DbContext
    {
        public BuscandoMiTragoDbContext()
        {
        }
        public BuscandoMiTragoDbContext(DbContextOptions<BuscandoMiTragoDbContext> options)
            : base(options)
        {
        }
        public DbSet<Drink> Drink { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Glass> Glass { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Alcoholic> Alcoholic { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseInMemoryDatabase("Patterns_DB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drink>(entity =>
            {
                entity.HasKey(a=>a.IdDrink);
                entity.Property(a => a.StrDrink);
                entity.Property(a => a.StrDescription);
                entity.Property(a => a.StrCategory);
                entity.Property(a => a.StrGlass);
                entity.Property(a => a.StrIngredient);
                entity.Property(a => a.StrAlcoholic);
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Drink)
                    .HasForeignKey(d => d.StrCategory);
                entity.HasOne(d => d.Glass)
                    .WithMany(p => p.Drink)
                    .HasForeignKey(d => d.StrGlass);
                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.Drink)
                    .HasForeignKey(d => d.StrIngredient);
                entity.HasOne(d => d.Alcoholic)
                    .WithMany(p => p.Drink)
                    .HasForeignKey(d => d.StrAlcoholic);
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(a=>a.StrCategory);
                entity.Property(a => a.StrCategory);
            });
            modelBuilder.Entity<Glass>(entity =>
            {
                entity.HasKey(a => a.StrGlass);
                entity.Property(a=>a.StrGlass);
            });
            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(a => a.StrIngredient1);
                entity.Property(a => a.StrIngredient1);
            });
            modelBuilder.Entity<Alcoholic>(entity =>
            {
                entity.HasKey(a => a.StrAlcoholic);
                entity.Property(a => a.StrAlcoholic);
            });
        }
    }
}
