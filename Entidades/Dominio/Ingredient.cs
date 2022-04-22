﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Entidades.Dominio
{
    public class Ingredient
    {
        public Ingredient()
        {
            Drink = new HashSet<Drink>();
        }
        public string StrIngredient1 { get; set; }
        public ICollection<Drink> Drink { get; set; }
    }
}
