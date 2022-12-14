using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Models;
using RecipeBook.Services;

namespace RecipeBook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;

        public RecipesController(RecipesService recipesService)
        {
            _recipesService = recipesService;
        }

        [HttpGet]
        public ActionResult<List<Recipe>> GetAllRecipes(){
        try
        {
            List<Recipe> recipes = _recipesService.GetAll();
            return Ok(recipes);
        }
            catch (Exception e)
        {

            return BadRequest(e.Message);
        }
        }


        [HttpGet("{id}")]
        public ActionResult<Recipe> GetRecipeById(int id){
            try
        {
            Recipe recipe = _recipesService.GetById(id);
            return recipe;
        }
            catch (Exception e)
        {

            return BadRequest(e.Message);
        }
        }

        [HttpGet("{id}/ingredients")]
        public ActionResult<List<Ingredient>> GetRecipeIngredients(int id){
            try
        {
            List<Ingredient> ingredients = _recipesService.GetIngredientsByRecipeId(id);
            return Ok(ingredients);
        }
            catch (Exception e)
        {

            return BadRequest(e.Message);
        }
        }


        [HttpGet("{id}/steps")]
        public ActionResult<List<Step>> GetRecipeSteps(int id){
            try
        {
            List<Step> steps = _recipesService.GetRecipeSteps(id);
            return Ok(steps);
        }
            catch (Exception e)
        {

            return BadRequest(e.Message);
        }
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Recipe>> Create([FromBody] Recipe newRecipe){
        try
        {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                newRecipe.creatorId = userInfo.Id;
                Recipe recipe = _recipesService.Create(newRecipe);
                recipe.Creator = userInfo;
                return Ok(recipe);

        }
            catch (Exception e)
        {

            return BadRequest(e.Message);
        }
        }
    }
}