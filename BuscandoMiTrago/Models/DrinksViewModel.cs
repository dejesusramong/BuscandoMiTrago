using Entidades.DataContext;
using Entidades.DataContext.Data;
using Entidades.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuscandoMiTrago.Models
{
    public class DrinksViewModel
    {
        public string M { get; set; }
        public string C { get; set; }
        public string G { get; set; }
        public string I { get; set; }
        public string A { get; set; }
        public List<Drink> Drinks { get; set; }

        internal async Task GetDrinks(BuscandoMiTragoDbContext _context, IServiceProvider _serviceProvider)
        {
            switch (M.ToLower())
            {
                case "c":
                    await DbInicializador.GetDrinksByCategoryAsync(_serviceProvider, C);
                    break;
                case "g":
                    await DbInicializador.GetDrinksByGlassAsync(_serviceProvider, G);
                    break;
                case "i":
                    await DbInicializador.GetDrinksByIngredientAsync(_serviceProvider, I);
                    break;
                case "a":
                    await DbInicializador.GetDrinksByAlcoholicAsync(_serviceProvider, A);
                    break;
                default:
                    break;
            }

            Drinks = await _context.Drink.ToListAsync();
        }
    }
}
