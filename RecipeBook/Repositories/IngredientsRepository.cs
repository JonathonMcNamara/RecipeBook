using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using RecipeBook.Models;

namespace RecipeBook.Repositories
{
    public class IngredientsRepository
    {
        private readonly IDbConnection _db;

        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
        {
            string sql = @"
            SELECT i.*,
            FROM ingredients i
            WHERE i.recipeId = @recipeId;
            ";
            List<Ingredient> ingredients= _db.Query<Ingredient>(sql, new {recipeId}).ToList();
            return ingredients;
        }
    }
}