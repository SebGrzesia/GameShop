using GameStore.Data;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Models
{
    public static class AddBasicGames
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GameStoreContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GameStoreContext>>()))
            {
                if (context.Games.Any())
                {
                    return;
                }
                context.Games.AddRange(
                    new Games
                    {
                        Name = "Cyberpunk",
                        ReleaseDate = DateTime.Parse("10-12-2020"),
                        Genre = "RPG",
                        Price = 120.0M
                    },
                    new Games
                    {
                        Name = "Baldur’s Gate III",
                        ReleaseDate = DateTime.Parse("03-08-2023"),
                        Genre = "Story",
                        Price = 200.0M
                    },
                    new Games
                    {
                        Name = "Super Mario Bros.",
                        ReleaseDate = DateTime.Parse("13-09-1985"),
                        Genre = "Platform",
                        Price = 10.0M
                    },
                    new Games
                    {
                        Name = "Pac-Man",
                        ReleaseDate = DateTime.Parse("22-05-1880"),
                        Genre = "Action",
                        Price = 0.0M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
