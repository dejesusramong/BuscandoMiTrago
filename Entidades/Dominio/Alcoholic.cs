using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Entidades.Dominio
{
    public class Alcoholic
    {
        public Alcoholic()
        {
            Drink = new HashSet<Drink>();
        }
        public string StrAlcoholic { get; set; }
        public ICollection<Drink> Drink { get; set; }
    }
}
