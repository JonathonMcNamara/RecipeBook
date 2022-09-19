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

        [HttpGet]
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