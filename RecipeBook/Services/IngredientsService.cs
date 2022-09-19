using System;
using System.Collections.Generic;
using RecipeBook.Models;
using RecipeBook.Repositories;

namespace RecipeBook.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _ingredientsRepository;

        public IngredientsService(IngredientsRepository ingredientsRepository)
        {
            _ingredientsRepository = ingredientsRepository;
        }

        internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
        {
        List<Ingredient> ingredients = _ingredientsRepository.GetIngredientsByRecipeId(recipeId);
        if(ingredients == null){
            throw new Exception("No Ingredients for that recipe");
            }
        return ingredients;
        }
    }
}