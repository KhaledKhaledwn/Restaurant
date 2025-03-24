using Restaurant.Models.Entities;
using Restaurant.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models.Interfaces
{
    public  interface IRecipe
    {
        public void AddRecipe(string Title, List<string> Components, string Instructions, string ChefName, ClientLayer clientlayer, Action action);
        public void UpdateRecipe(int RecipeId, Recipe recipe, Action action);
        public void DeleteRecipe(int RecipeId, Action action);
        public  void DisplayRecipes( Action action);


    }
}
