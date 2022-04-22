using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Entidades.Dominio
{
    public class Category
    {
        public Category()
        {
            Drink = new HashSet<Drink>();
        }
        public string StrCategory { get; set; }
        public ICollection<Drink> Drink { get; set; }
    }
}
