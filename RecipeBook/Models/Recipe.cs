namespace RecipeBook.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string picture { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string category { get; set; }
        public string creatorId { get; set; }
        public Account Creator { get; set; }
    }
}