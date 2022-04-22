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
        public int? IdDrink { get; set; }
        public Drink IdDrinkNavigation { get; set; }
        public string M { get; set; }
        public string C { get; set; }
        public string G { get; set; }
        public string I { get; set; }
        public string A { get; set; }
        public string S { get; set; }
        public string F { get; set; }
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
                case "s":
                    await DbInicializador.GetDrinksByNameAsync(_serviceProvider, S);
                    break;
                case "f":
                    await DbInicializador.GetDrinksByFirstLetterAsync(_serviceProvider, F.Substring(0,1));
                    break;
                default:
                    break;
            }

            Drinks = await _context.Drink.ToListAsync();
        }
        internal async Task GetDrink(BuscandoMiTragoDbContext _context, IServiceProvider _serviceProvider)
        {
            await DbInicializador.GetDrinkDetailsAsync(_serviceProvider, IdDrink.Value);
            IdDrinkNavigation = await _context.Drink.FirstAsync(a=>a.IdDrink == IdDrink);
        }
    }
}
