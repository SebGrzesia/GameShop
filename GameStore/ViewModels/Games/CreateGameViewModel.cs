namespace GameStore.ViewModels.Games
{
    public class CreateGameViewModel
    {
        public string? Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}
