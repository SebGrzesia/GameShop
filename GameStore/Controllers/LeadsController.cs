using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Authorization;

namespace GameStore.Controllers
{
    [Authorize]
    public class LeadsController : Controller
    {
        private readonly GameStoreContext _context;

        public LeadsController(GameStoreContext context)
        {
            _context = context;
        }

        // GET: Leads
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserLead.ToListAsync());
        }

        // GET: Leads/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLeadEntity = await _context.UserLead
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userLeadEntity == null)
            {
                return NotFound();
            }

            return View(userLeadEntity);
        }

        // GET: Leads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Leads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Mobile,Email,Source")] UserLeadEntity userLeadEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userLeadEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userLeadEntity);
        }

        // GET: Leads/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLeadEntity = await _context.UserLead.FindAsync(id);
            if (userLeadEntity == null)
            {
                return NotFound();
            }
            return View(userLeadEntity);
        }

        // POST: Leads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,FirstName,LastName,Mobile,Email,Source")] UserLeadEntity userLeadEntity)
        {
            if (id != userLeadEntity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userLeadEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserLeadEntityExists(userLeadEntity.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userLeadEntity);
        }

        // GET: Leads/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLeadEntity = await _context.UserLead
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userLeadEntity == null)
            {
                return NotFound();
            }

            return View(userLeadEntity);
        }

        // POST: Leads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userLeadEntity = await _context.UserLead.FindAsync(id);
            if (userLeadEntity != null)
            {
                _context.UserLead.Remove(userLeadEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserLeadEntityExists(string id)
        {
            return _context.UserLead.Any(e => e.ID == id);
        }
    }
}
