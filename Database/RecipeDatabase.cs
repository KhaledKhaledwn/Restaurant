using Restaurant.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Database
{
    public class RecipeDatabase
    {
        public static List<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
