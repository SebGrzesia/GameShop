using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.ViewModels.Games
{
    public class GamesGenreViewModel
    {
        public List<GamesViewModel> GamesViewModels { get; set; }
        public SelectList? Genres { get; set; }
        public string? GameGenre { get; set; }
        public string? SearchString { get; set; }

    }
}
