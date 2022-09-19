using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Models;
using RecipeBook.Services;

namespace RecipeBook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _ingredientsService;

        public IngredientsController(IngredientsService ingredientsService)
        {
            _ingredientsService = ingredientsService;
        }

        [HttpGet]
        public ActionResult<List<Ingredient>> GetIngredientsByRecipeId(){
            try
        {
            List<Ingredient> ingredients = _ingredientsService.GetIngredientsByRecipeId();
            return Ok(ingredients);
        }
            catch (Exception e)
        {

            return BadRequest(e.Message);
        }
        }



    }
}