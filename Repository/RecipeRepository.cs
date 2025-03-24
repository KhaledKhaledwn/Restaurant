using Restaurant.Database;
using Restaurant.Models.Entities;
using Restaurant.Models.Enums;
using Restaurant.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Restaurant.RecipeRepository
{
    // Implementation of RecipeInterface
    public class RecipeRepository : IRecipe
    {
        // Getting Recipes List form Database.RecipeDatabase
        public  List<Recipe> Recipes = RecipeDatabase.Recipes;

        public static int RecipeId = 0;
        public  void AddRecipe(string Title, List<string> Components, string Instructions, string ChefName, ClientLayer clientlayer, Action action)
        {
            action();
            // Checking Section
            if (string.IsNullOrWhiteSpace(Title) || Title.Length>10)
            {
                Console.WriteLine("Title maybe is null or has spaces between letters or lenger than 10 Characters");
                return;
            } 
            if (string.IsNullOrWhiteSpace(ChefName))
            {
                Console.WriteLine("ChefName maybe is null or has spaces between letters");
                return;
            } 
            if (Instructions.Length>1000)
            {
                Console.WriteLine("Instrution maybe has lenth bigger than 1000 Characters");
                return;
            }
            if (Components is null)
            {
                Console.WriteLine("Ingredients list is null");
                return;
            }

            // set values ( making object of Recipe class )
            Recipe recipe = new Recipe();
            recipe.Title = Title;
            recipe.Ingredients = Components;
            recipe.Instructions = Instructions;
            recipe.ChefName = ChefName;
            recipe.ClientLayer = clientlayer;

            // Check if Recipes List is null => make Id = 1
                recipe.Id = ++RecipeId;
          

            Recipes.Add(recipe);
            Console.WriteLine("Adding a Recipe to Database done!!\n");
        }

        public  void DeleteRecipe(int RecipeId, Action action)
        {
            action();
            var isFind = Recipes.Where(i => i.Id == RecipeId);
            if (Recipes.Count == 0 || isFind == null)
            {
                Console.WriteLine("False Deleting Operation : Recipes list is null or Recipe is not found!");
            }
            else
            {
                Recipes.RemoveAll(r => r.Id == RecipeId);
                Console.WriteLine("Deleting a Recipe is done!!\n");

                // Another way to do that:
                /* foreach (var recipe in Recipes.ToList())
                {

                   if(recipe.Id == RecipeId) Recipes.Remove(recipe);
                    Console.WriteLine("Deleting a Recipe from Database done!!!");

                }
                */

            }
        }


        public  void UpdateRecipe(int RecipeId, Recipe recipe , Action action)
        {
            action();

            foreach(var recipeItem in Recipes)
            {
                if (recipeItem.Id == RecipeId)
                {
                    recipeItem.Id = recipe.Id;
                    recipeItem.ChefName = recipe.ChefName;
                    recipeItem.Ingredients = recipe.Ingredients;
                    recipeItem.ClientLayer = recipe.ClientLayer;
                    recipeItem.Title = recipe.Title;
                    recipeItem.Instructions = recipe.Instructions;
                }
               
            }
            Console.WriteLine("Updating a Recipe is done!!\n");


        }


        public  void DisplayRecipes(Action action)
        {
            int number = 0;
            action();
            if (Recipes.Count == 0)
            {
                Console.WriteLine("False Displaying operation : Recipes list is null!");
            }
            else
            {

                foreach (var recipe in Recipes)
                {
                    Console.Write($"\nDetails Of Recipe [{number++}]\n");
                    Console.WriteLine($"  RecipeId       :  {recipe.Id}\n" +
                        $"  RecipeTitle    :  {recipe.Title}\n" +
                        $"  ChefName       :  {recipe.ChefName}\n" +
                        $"  RecipeInstruct :  {recipe.Instructions}\n" +
                        $"  ClientLayer    :  {recipe.ClientLayer}\n" +
                        $"  Ingredients    :  {string.Join(" - ",recipe.Ingredients)}\n\n");
                }
            }
           
        }

       
    }
}
