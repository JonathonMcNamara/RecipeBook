using System.Collections.Generic;
using RecipeBook.Models;
using RecipeBook.Repositories;

namespace RecipeBook.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _recipesRepo;

        public RecipesService(RecipesRepository recipesRepo)
        {
            _recipesRepo = recipesRepo;
        }

        internal List<Recipe> GetAll()
        {
            return _recipesRepo.GetAll();
        }
    }
}