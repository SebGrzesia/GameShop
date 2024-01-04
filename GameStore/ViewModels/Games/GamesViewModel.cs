using System.ComponentModel.DataAnnotations;

namespace GameStore.ViewModels.Games
{
    public class GamesViewModel
    {
        public string ID { get; set; }
        public string? Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}
