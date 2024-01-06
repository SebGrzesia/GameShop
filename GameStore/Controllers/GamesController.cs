using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameStore.Data;
using GameStore.Models;
using GameStore.ViewModels.Games;
using NuGet.Frameworks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using System.Collections;

namespace GameStore.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        private readonly GameStoreContext _context;
        private readonly IMemoryCache _cache;
        private readonly string cacheKey = "gamesCacheKey";

        public GamesController(GameStoreContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        // GET: Games
        public async Task<IActionResult> Index(string searchString, string gameGenre)
        {
            if (_context.Games == null)
            {
                return Problem("GameContext is null");
            }
            
            if(_cache.TryGetValue(cacheKey, out IEnumerable<Games> games))
            {

            }
            else
            {
                games = _context.Games.ToList();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(40))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                    .SetPriority(CacheItemPriority.Normal);

                _cache.Set(cacheKey, games, cacheEntryOptions);
            }

            IQueryable<string?> genreQuery = _context.Games.Select(g => g.Genre).Distinct();

            var gameQuery = from m in _context.Games select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                gameQuery = gameQuery.Where(s => s.Name!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(gameGenre))
            {
                gameQuery = gameQuery.Where(z => z.Genre == gameGenre);
            }

            var gamesFromDatabase = await gameQuery.ToListAsync();
            var gamesList = gamesFromDatabase.Select(gamesFromDatabase => new GamesViewModel()
            {
                ID = gamesFromDatabase.ID,
                Name = gamesFromDatabase.Name,
                ReleaseDate = gamesFromDatabase.ReleaseDate,
                Genre = gamesFromDatabase.Genre,
                Price = gamesFromDatabase.Price
            });
            gamesList = gamesList.OrderByDescending(t => t.ReleaseDate);

            var gamesGenreViewModel = new GamesGenreViewModel
            {
                Genres = new SelectList(await genreQuery.ToListAsync()),
                GamesViewModels = gamesList.ToList()
            };

            return View(gamesGenreViewModel);
        }

        // GET: Games/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            DetailsGameViewModel vm = new DetailsGameViewModel();
            vm.ID = id;
            vm.Name = game.Name;
            vm.ReleaseDate = game.ReleaseDate;
            vm.Genre = game.Genre;
            vm.Price = game.Price;

            return View(vm);
        }

        // GET: Games/Create
        public IActionResult Create()
        {
            CreateGameViewModel vm = new CreateGameViewModel();
            return View(vm);
        }

        // POST: Games/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameViewModel vm)
        {
            Games game = new Games();
            game.Name = vm.Name;
            game.ReleaseDate = vm.ReleaseDate;
            game.Genre = vm.Genre;
            game.Price = vm.Price;

            _context.Add(game);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);
            if( game == null )
            {
                return NotFound();
            }
            
            EditGameViewModel vm = new EditGameViewModel();
            vm.Name = game.Name;
            vm.ReleaseDate = game.ReleaseDate;
            vm.Genre = game.Genre;
            vm.Price = game.Price;
            return View(vm);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditGameViewModel vm)
        {
            var game = await _context.Games.FindAsync(vm.ID);
            if ( game == null)
            {
                return View(vm);
            }
            game.Name = vm.Name;
            game.ReleaseDate = vm.ReleaseDate;
            game.Genre = vm.Genre;
            game.Price = vm.Price;
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Games == null)
            {
                return NotFound();
            }

            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            DeleteGameViewModel vm = new DeleteGameViewModel();
            vm.Name = game.Name;
            vm.ReleaseDate = game.ReleaseDate;
            vm.Genre = game.Genre;
            vm.Price = game.Price;

            return View(vm);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Games == null)
            {
                return Problem("Context is null");
            }
            var game = await _context.Games.FindAsync(id);
            if( game != null)
            {
                _context.Games.Remove(game);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ClearCache()
        {
            _cache.Remove(cacheKey);
            return RedirectToAction("Index");
        }
    }
}
