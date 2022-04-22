using Entidades.Dominio;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entidades.DataContext.Data
{
    public class ApiMethods
    {
        public JsonElement Drinks { get; set; }
        public JsonElement Ingredients { get; set; }
    }
}
