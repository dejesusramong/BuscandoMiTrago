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
        public string StrInstructions { get; set; }
        public string StrCategory { get; set; }
        public string StrGlass { get; set; }
        public string StrIngredient1 { get; set; }
        public string StrIngredient2 { get; set; }
        public string StrIngredient3 { get; set; }
        public string StrIngredient4 { get; set; }
        public string StrIngredient5 { get; set; }
        public string StrIngredient6 { get; set; }
        public string StrIngredient7 { get; set; }
        public string StrIngredient8 { get; set; }
        public string StrIngredient9 { get; set; }
        public string StrIngredient10 { get; set; }
        public string StrIngredient11 { get; set; }
        public string StrIngredient12 { get; set; }
        public string StrIngredient13 { get; set; }
        public string StrIngredient14 { get; set; }
        public string StrIngredient15 { get; set; }
        public string StrAlcoholic { get; set; }
        public string StrMeasure1 { get; set; }
        public string StrMeasure2 { get; set; }
        public string StrMeasure3 { get; set; }
        public string StrMeasure4 { get; set; }
        public Category Category { get; set; }
        public Glass Glass { get; set; }
        public Ingredient Ingredient1 { get; set; }
        public Ingredient Ingredient2 { get; set; }
        public Ingredient Ingredient3 { get; set; }
        public Ingredient Ingredient4 { get; set; }
        public Ingredient Ingredient5 { get; set; }
        public Ingredient Ingredient6 { get; set; }
        public Ingredient Ingredient7 { get; set; }
        public Ingredient Ingredient8 { get; set; }
        public Ingredient Ingredient9 { get; set; }
        public Ingredient Ingredient10 { get; set; }
        public Ingredient Ingredient11 { get; set; }
        public Ingredient Ingredient12 { get; set; }
        public Ingredient Ingredient13 { get; set; }
        public Ingredient Ingredient14 { get; set; }
        public Ingredient Ingredient15 { get; set; }
        public Alcoholic Alcoholic { get; set; }
        public List<Category> Categories { get; set; }
        public List<Glass> Glasses { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Alcoholic> Alcoholics { get; set; }
    }
}
