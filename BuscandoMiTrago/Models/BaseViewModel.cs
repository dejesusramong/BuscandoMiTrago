namespace BuscandoMiTrago.Models
{
    public abstract class BaseVieModel
    {
        /// <summary>
        /// Mode: Filters and Searches
        /// </summary>
        public string M { get; set; }
        /// <summary>
        /// Category
        /// </summary>
        public string C { get; set; }
        /// <summary>
        /// Glass
        /// </summary>
        public string G { get; set; }
        /// <summary>
        /// Ingredient
        /// </summary>
        public string I { get; set; }
        /// <summary>
        /// Alcoholic
        /// </summary>
        public string A { get; set; }
        /// <summary>
        /// Drink's Name
        /// </summary>
        public string S { get; set; }
        /// <summary>
        /// Drink's First Letter
        /// </summary>
        public string F { get; set; }
    }
}
