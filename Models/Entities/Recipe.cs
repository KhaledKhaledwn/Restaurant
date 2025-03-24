using Restaurant.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models.Entities
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        // Components
        public List<string> Ingredients = new List<string>();

        public string Instructions { get; set; } = string.Empty;
        public string ChefName { get; set; } = string.Empty;

        public ClientLayer ClientLayer { get; set; } 
 
    }
}
