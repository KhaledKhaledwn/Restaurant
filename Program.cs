using Restaurant.Models.Entities;
using Restaurant.RecipeRepository;
using Restaurant;
using Restaurant.Models.Interfaces;
using Restaurant.Models.Enums;
using System.Threading.Channels;
using Restaurant.RecipeRepository;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
namespace Restaurant
{
    public class Program
    {




        static void Main(string[] args)
        {
            RecipeRepository.RecipeRepository re = new RecipeRepository.RecipeRepository();

            // CRUD Operation: just choose the first letter of each operation(for example: if you want to add recipe just Enter C..)
            char FirstLetter;
            string ExiteKeyWord = string.Empty;
            List<string> IngredientsList = new List<string>();
            while (ExiteKeyWord !="yes" )
            {
                Console.WriteLine("Choose an Operation");
                    FirstLetter = Convert.ToChar(Console.ReadLine());

                if ((FirstLetter == 'c' || FirstLetter == 'C'))
                {
                    Console.WriteLine("Enter RecipeTitle :");
                    string RecipeTitle = Console.ReadLine();

                    Console.WriteLine("Enter RecipeChefName :");
                    string RecipeChefName = Console.ReadLine();

                    Console.WriteLine("Enter RecipeInstruction :");
                    string RecipeInstruction = Console.ReadLine();
                  
                    Console.WriteLine("EnterRecipeClientLayer :");
                    string clientlevel = Console.ReadLine();

                    Console.WriteLine("Enter RecipeComponenets :");
                    Console.Write("how many components? :");
                    try
                    {
                        int CompCount = int.Parse(Console.ReadLine());
                        for (int i = 0; i < CompCount; i++) IngredientsList.Add(Console.ReadLine());
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("There is an error in Entering processing, Maybe Must add an elements");
                    }
                   

                    // Calling the orederd function 
                    re.AddRecipe(RecipeTitle, new List<string>(IngredientsList), RecipeInstruction, RecipeChefName, ClientLayer.Private, () => Console.WriteLine("We are doing Adding Operation"));
                    IngredientsList.Clear();
                }
                else if (FirstLetter == 'r' || FirstLetter == 'R')
                {
                    re.DisplayRecipes(() => Console.WriteLine("We are doing Displaying Operation"));
                }
                else if (FirstLetter == 'd' || FirstLetter == 'D')
                {
                    Console.Write("Enter RecipeId please :");
                    int RecipeId = int.Parse(Console.ReadLine());
                    re.DeleteRecipe(RecipeId, () => Console.WriteLine("We are doing Deleting Operation"));
                }
                else if (FirstLetter == 'u' || FirstLetter == 'U')
                {
                    Console.WriteLine("Enter RecipeId that you wanna update it please :");
                    int RecipeId = Convert.ToInt16(Console.ReadLine());

                    Console.WriteLine("Enter NewRecipeTitle :");
                    string RecipeTitle = Console.ReadLine();

                    Console.WriteLine("Enter NewRecipeChefName :");
                    string RecipeChefName = Console.ReadLine();

                    Console.WriteLine("Enter NewRecipeInstruction :");
                    string RecipeInstruction = Console.ReadLine();

                    Console.WriteLine("Enter NewRecipeClientLayer :");
                    string clientlevel = Console.ReadLine();

                    Console.WriteLine("Enter NewRecipeComponenets :");
                    Console.Write("how many components? :");
                    int CompCount = int.Parse(Console.ReadLine());
                    // Make nonPremently list => CurrentList;
                    List<string> CurrentList = new List<string>();
                    for (int i = 0; i < CompCount; i++) CurrentList.Add(Console.ReadLine());

                    Recipe RecipeForUpdate = new Recipe()
                    {
                        Id = RecipeId,
                        Title = RecipeTitle,
                        ChefName = RecipeChefName,
                        Ingredients = CurrentList,
                        Instructions = RecipeInstruction,
                        ClientLayer = ClientLayer.Private
                    };

                    re.UpdateRecipe(RecipeId, RecipeForUpdate,() => Console.WriteLine("We are doing Updating Operation"));
                }

               else if(FirstLetter == 'e' || FirstLetter == 'E')
                {
                    Console.WriteLine("Are you sure to exite?");
                    ExiteKeyWord = Console.ReadLine();
                    if (ExiteKeyWord == "yes") Console.WriteLine("You are not allowed you to continue"); 
                }
                else
                {
                    Console.WriteLine($"There is no operation with this {FirstLetter}");

                }

            }



        }
    }
}


//-------------------------------- This code is made by Khaled Al Khaledwn ------------------------------------------------


// ------------------------------- You can call the functions by using these calls but this way is not flexiball or dynamic or visualization

//// RecipeRepository.RecipeRepository re = new RecipeRepository.RecipeRepository();
// re.AddRecipe("food1", new List<string> { "salt", "water", "bread", "potato" }, "cook it with 100 tempreture degree", "Khaled al khaledwn", ClientLayer.Private, () => Console.WriteLine("Adding Operation"));
// re.AddRecipe("food1", new List<string> { "Rice", "water", "salt", "potato" }, "cook it with 23 tempreture degree", "Omar", ClientLayer.Public, () => Console.WriteLine("Adding Operation"));
// re.AddRecipe("food1", new List<string> { "salt", "water", "tomato", "potato" }, "cook it with 12 tempreture degree", "Samer", ClientLayer.Private, () => Console.WriteLine("Adding Operation"));

// re.DisplayRecipes(() => Console.WriteLine("Displaying Operation"));
// //re.DeleteRecipe(2,() => Console.WriteLine("Deleting Operation"));
// //re.DisplayRecipes(() => Console.WriteLine("Displaying Operation"));


// re.UpdateRecipe(1, new Recipe() 
//     { 
//         Id = 43,
//         ChefName = "Nader al abduallh",
//         Title = "mojadarahaha",
//         Instructions = "okokok",
//         Ingredients = new List<string> 
//         {
//             "water", "tomato", "poatato" 
//         },
//         ClientLayer = ClientLayer.Private,
//     },
//         () => Console.WriteLine("Updaing Operation"));

// Console.WriteLine("After updating... operat ");
// Console.WriteLine();
// Console.WriteLine();
// Console.WriteLine();
// Console.WriteLine();

// re.DisplayRecipes(() => Console.WriteLine("Displaying Operation"));


