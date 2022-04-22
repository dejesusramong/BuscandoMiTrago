using System.Collections.Generic;

namespace BuscandoMiTrago.Models
{
    public class UsersFavorites
    {
        /// <summary>
        /// User Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Drink's IDs
        /// </summary>
        public List<int> Favorites { get; set; }
    }
}
