using System.Collections.Generic;
using System.Linq;

namespace RecipeManagerApp.Data
{
    public class RecipeService
    {
        private readonly List<Recipe> recipes;

        public RecipeService()
        {
            // Initialize the shared recipe list
            recipes = new List<Recipe>
            {
                new Recipe { Id = 1, Name = "Spaghetti Bolognese", Description = "A classic Italian pasta dish with rich meat sauce." },
                new Recipe { Id = 2, Name = "Chicken Curry", Description = "A flavorful curry dish with tender chicken pieces." },
                new Recipe { Id = 3, Name = "Vegetable Stir Fry", Description = "A quick and healthy stir fry with fresh vegetables." },
                new Recipe { Id = 4, Name = "Beef Tacos", Description = "Tasty tacos filled with seasoned beef and fresh toppings." },
                new Recipe { Id = 5, Name = "Caesar Salad", Description = "A crisp salad with romaine lettuce, croutons, and Caesar dressing." }
            };
        }

        // Get all recipes
        public List<Recipe> GetAllRecipes() => recipes;

        // Get a single recipe by Id
        public Recipe? GetRecipeById(int id) => recipes.FirstOrDefault(r => r.Id == id);

        // Add a new recipe
        public void AddRecipe(Recipe recipe)
        {
            // Assign an Id automatically
            recipe.Id = recipes.Count > 0 ? recipes.Max(r => r.Id) + 1 : 1;
            recipes.Add(recipe);
        }
    }
}
