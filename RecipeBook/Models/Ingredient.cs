namespace RecipeBook.Models
{
    public class Ingredient
    {
        public int id {get; set;}
        public string Name { get; set; }
        public string Quantity { get; set; }
        public int RecipeId { get; set; }
    }
}