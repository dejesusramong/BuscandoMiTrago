using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Dominio
{
    public class Drink
    {
        public int IdDrink { get; set; }
        public string StrDrink { get; set; }
        public string StrDrinkThumb { get; set; }
        public string StrDescription { get; set; }
        public string StrCategory { get; set; }
        public string StrGlass { get; set; }
        public string StrIngredient { get; set; }
        public string StrAlcoholic { get; set; }
        public Category Category { get; set; }
        public Glass Glass { get; set; }
        public Ingredient Ingredient { get; set; }
        public Alcoholic Alcoholic { get; set; }
        public List<Category> Categories { get; set; }
        public List<Glass> Glasses { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Alcoholic> Alcoholics { get; set; }
    }
}
