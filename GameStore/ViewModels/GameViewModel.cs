using System.ComponentModel.DataAnnotations;

namespace GameStore.ViewModels
{
    public class GameViewModel
    {
        public string? Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}
