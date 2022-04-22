using Entidades.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json;
using System.Text.Json;

namespace Entidades.DataContext.Data
{
    public static class DbInicializador
    {
        static readonly HttpClient cliente = new HttpClient {
            BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/")
        };
        static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new BuscandoMiTragoDbContext(serviceProvider.GetRequiredService<DbContextOptions<BuscandoMiTragoDbContext>>()))
            {
                if (_context.Category.Any())
                {
                    return;
                }
                //CancellationToken ct = default;
                //using var HttpResponse = await cliente.GetAsync("list.php?c=list", ct);//categorias list.php?c=list //latest latest.php
                //if (!HttpResponse.IsSuccessStatusCode)
                //{
                //    throw new Exception("ERROR: Algo salió mal.");
                //}
                //var l = await HttpResponse.Content.ReadFromJsonAsync<ApiMethods>();
                
                var ct = await cliente.GetFromJsonAsync<ApiMethods>("list.php?c=list");
                if (ct.Drinks.ValueKind == System.Text.Json.JsonValueKind.Array)
                {
                    List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(ct.Drinks.ToString());
                    foreach (var c in categories)
                    {
                        _context.Category.Add(c);
                    }
                    _context.SaveChanges();
                }

                var gl = await cliente.GetFromJsonAsync<ApiMethods>("list.php?g=list");
                if (gl.Drinks.ValueKind == System.Text.Json.JsonValueKind.Array)
                {
                    List<Glass> glasses = JsonConvert.DeserializeObject<List<Glass>>(gl.Drinks.ToString());
                    foreach (var g in glasses)
                    {
                        _context.Glass.Add(g);
                    }
                    _context.SaveChanges();
                }

                var ng = await cliente.GetFromJsonAsync<ApiMethods>("list.php?i=list");
                if (ng.Drinks.ValueKind == System.Text.Json.JsonValueKind.Array)
                {
                    List<Ingredient> ingredient = JsonConvert.DeserializeObject<List<Ingredient>>(ng.Drinks.ToString());
                    foreach (var i in ingredient)
                    {
                        _context.Ingredient.Add(i);
                    }
                    _context.SaveChanges();
                }

                var lc = await cliente.GetFromJsonAsync<ApiMethods>("list.php?a=list");
                if (lc.Drinks.ValueKind == System.Text.Json.JsonValueKind.Array)
                {
                    List<Alcoholic> alcoholic = JsonConvert.DeserializeObject<List<Alcoholic>>(lc.Drinks.ToString());
                    foreach (var a in alcoholic)
                    {
                        _context.Alcoholic.Add(a);
                    }
                    _context.SaveChanges();
                }

                //var dr = await cliente.GetFromJsonAsync<ApiMethods>("filter.php?c=x");
                //if (dr.Drinks.ValueKind == System.Text.Json.JsonValueKind.Array)
                //{
                //    List<Drink> drinks = JsonConvert.DeserializeObject<List<Drink>>(dr.Drinks.ToString());
                //    foreach (var d in drinks)
                //    {
                //        _context.Drink.Add(d);
                //    }
                //    _context.SaveChanges();
                //}
            }
        }
        public static async Task GetDrinksByCategoryAsync(IServiceProvider serviceProvider, string strCategory)
        {
            List<Drink> result = new List<Drink>();
            using (var _context = new BuscandoMiTragoDbContext(serviceProvider.GetRequiredService<DbContextOptions<BuscandoMiTragoDbContext>>()))
            {
                var dr = await cliente.GetFromJsonAsync<ApiMethods>("filter.php?c=" + strCategory);
                
                if (dr.Drinks.ValueKind == System.Text.Json.JsonValueKind.Array)
                {
                    result = JsonConvert.DeserializeObject<List<Drink>>(dr.Drinks.ToString());

                    List<Drink> l = _context.Drink.ToList();
                    _context.Drink.RemoveRange(l);
                    foreach (var d in result)
                    {
                        if (!_context.Drink.Any(a=>a.IdDrink == d.IdDrink))
                        {
                            _context.Drink.Add(d);
                        }
                    }
                    await _context.SaveChangesAsync();
                }
            }
        }
        public static async Task GetDrinksByGlassAsync(IServiceProvider serviceProvider, string strGlass)
        {
            List<Drink> result = new List<Drink>();
            using (var _context = new BuscandoMiTragoDbContext(serviceProvider.GetRequiredService<DbContextOptions<BuscandoMiTragoDbContext>>()))
            {
                var dr = await cliente.GetFromJsonAsync<ApiMethods>("filter.php?g=" + strGlass);

                if (dr.Drinks.ValueKind == System.Text.Json.JsonValueKind.Array)
                {
                    result = JsonConvert.DeserializeObject<List<Drink>>(dr.Drinks.ToString());

                    List<Drink> l = _context.Drink.ToList();
                    _context.Drink.RemoveRange(l);
                    foreach (var d in result)
                    {
                        if (!_context.Drink.Any(a => a.IdDrink == d.IdDrink))
                        {
                            _context.Drink.Add(d);
                        }
                    }
                    await _context.SaveChangesAsync();
                }
            }
        }
        public static async Task GetDrinksByIngredientAsync(IServiceProvider serviceProvider, string strIngredient)
        {
            List<Drink> result = new List<Drink>();
            using (var _context = new BuscandoMiTragoDbContext(serviceProvider.GetRequiredService<DbContextOptions<BuscandoMiTragoDbContext>>()))
            {
                var dr = await cliente.GetFromJsonAsync<ApiMethods>("filter.php?i=" + strIngredient);

                if (dr.Drinks.ValueKind == System.Text.Json.JsonValueKind.Array)
                {
                    result = JsonConvert.DeserializeObject<List<Drink>>(dr.Drinks.ToString());

                    List<Drink> l = _context.Drink.ToList();
                    _context.Drink.RemoveRange(l);
                    foreach (var d in result)
                    {
                        if (!_context.Drink.Any(a => a.IdDrink == d.IdDrink))
                        {
                            _context.Drink.Add(d);
                        }
                    }
                    await _context.SaveChangesAsync();
                }
            }
        }
        public static async Task GetDrinksByAlcoholicAsync(IServiceProvider serviceProvider, string strAlcoholic)
        {
            List<Drink> result = new List<Drink>();
            using (var _context = new BuscandoMiTragoDbContext(serviceProvider.GetRequiredService<DbContextOptions<BuscandoMiTragoDbContext>>()))
            {
                var dr = await cliente.GetFromJsonAsync<ApiMethods>("filter.php?a=" + strAlcoholic);

                if (dr.Drinks.ValueKind == System.Text.Json.JsonValueKind.Array)
                {
                    result = JsonConvert.DeserializeObject<List<Drink>>(dr.Drinks.ToString());

                    List<Drink> l = _context.Drink.ToList();
                    _context.Drink.RemoveRange(l);
                    foreach (var d in result)
                    {
                        if (!_context.Drink.Any(a => a.IdDrink == d.IdDrink))
                        {
                            _context.Drink.Add(d);
                        }
                    }
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
