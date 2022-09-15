using System;
using System.Collections.Generic;
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
            return BadRequest(e);
        }
        }

    }
}