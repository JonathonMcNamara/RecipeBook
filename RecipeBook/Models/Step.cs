namespace RecipeBook.Models
{
    public class Step
    {
        public int id { get; set; }
        public int Position { get; set; }
        public string Body { get; set; }
        public int RecipeId { get; set; }
    }
}