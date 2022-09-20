using System;
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

        internal Recipe GetById(int id){
            Recipe recipe = _recipesRepo.GetById(id);
            if(recipe == null){
                throw new Exception("No recipe by that id");
            }
            return recipe;
        }

        internal Recipe Create(Recipe newRecipe){
            return _recipesRepo.Create(newRecipe);
        }

        internal List<Ingredient> GetIngredientsByRecipeId(int id)
        {
            return _recipesRepo.GetRecipeIngredients(id);
        }
    }
}