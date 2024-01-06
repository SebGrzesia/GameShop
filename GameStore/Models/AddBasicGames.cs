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
                    },
                    new Games
                    {
                        Name = "The Legend of Zelda: Breath of the Wild",
                        ReleaseDate = DateTime.Parse("03-03-2017"),
                        Genre = "Adventure",
                        Price = 150.0M
                    },
                    new Games
                    {
                        Name = "Minecraft",
                        ReleaseDate = DateTime.Parse("17-05-2009"),
                        Genre = "Sandbox",
                        Price = 30.0M
                    },
                    new Games
                    {
                        Name = "Fortnite",
                        ReleaseDate = DateTime.Parse("25-07-2017"),
                        Genre = "Battle Royale",
                        Price = 0.0M
                    },
                    new Games
                    {
                        Name = "The Elder Scrolls V: Skyrim",
                        ReleaseDate = DateTime.Parse("11-11-2011"),
                        Genre = "RPG",
                        Price = 60.0M
                    },
                    new Games
                    {
                        Name = "Overwatch",
                        ReleaseDate = DateTime.Parse("24-05-2016"),
                        Genre = "FPS",
                        Price = 40.0M
                    },
                    new Games
                    {
                        Name = "Red Dead Redemption 2",
                        ReleaseDate = DateTime.Parse("26-10-2018"),
                        Genre = "Action-Adventure",
                        Price = 80.0M
                    },
                    new Games
                    {
                        Name = "League of Legends",
                        ReleaseDate = DateTime.Parse("27-10-2009"),
                        Genre = "MOBA",
                        Price = 0.0M
                    },
                    new Games
                    {
                        Name = "Assassin's Creed: Odyssey",
                        ReleaseDate = DateTime.Parse("05-10-2018"),
                        Genre = "Action-Adventure",
                        Price = 70.0M
                    },
                    new Games
                    {
                        Name = "FIFA 22",
                        ReleaseDate = DateTime.Parse("01-10-2021"),
                        Genre = "Sports",
                        Price = 50.0M
                    },
                    new Games
                    {
                        Name = "World of Warcraft",
                        ReleaseDate = DateTime.Parse("23-11-2004"),
                        Genre = "MMORPG",
                        Price = 15.0M
                    },
                    new Games
                    {
                        Name = "Counter-Strike: Global Offensive",
                        ReleaseDate = DateTime.Parse("21-08-2012"),
                        Genre = "FPS",
                        Price = 15.0M
                    },
                    new Games
                    {
                        Name = "Mortal Kombat 11",
                        ReleaseDate = DateTime.Parse("23-04-2019"),
                        Genre = "Fighting",
                        Price = 45.0M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
