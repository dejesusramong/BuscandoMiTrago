using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Entidades.Dominio
{
    public class Glass
    {
        public Glass()
        {
            Drink = new HashSet<Drink>();
        }
        public string StrGlass { get; set; }
        public ICollection<Drink> Drink { get; set; }
    }
}
