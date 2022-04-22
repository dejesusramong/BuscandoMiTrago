using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BuscandoMiTrago.Extensiones
{
    public static class TheCocktailDBDbContextOptionsExtensions
    {
        public static DbContextOptionsBuilder UseTheCocktailDB(this DbContextOptionsBuilder optionsBuilder, [NotNullAttribute] string connectionString)
        {
            return optionsBuilder;
        }
    }
}
