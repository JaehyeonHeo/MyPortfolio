using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioHeo.Data;
using PortfolioHeo.Models;

namespace PortfolioHeo.Controllers
{
    public class ProfileSettingController : Controller
    {
        private readonly PortfolioHeoContext _context;

        public ProfileSettingController(PortfolioHeoContext context)
        {
            _context = context;
        }

        // GET: ProfileSetting
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProfileSetting.ToListAsync());
        }

        // GET: ProfileSetting/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileSetting = await _context.ProfileSetting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profileSetting == null)
            {
                return NotFound();
            }

            return View(profileSetting);
        }

        // GET: ProfileSetting/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfileSetting/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subject,Contents,RegDate")] ProfileSetting profileSetting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profileSetting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profileSetting);
        }

        // GET: ProfileSetting/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileSetting = await _context.ProfileSetting.FindAsync(id);
            if (profileSetting == null)
            {
                return NotFound();
            }
            return View(profileSetting);
        }

        // POST: ProfileSetting/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subject,Contents,RegDate")] ProfileSetting profileSetting)
        {
            if (id != profileSetting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profileSetting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileSettingExists(profileSetting.Id))
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
            return View(profileSetting);
        }

        // GET: ProfileSetting/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileSetting = await _context.ProfileSetting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profileSetting == null)
            {
                return NotFound();
            }

            return View(profileSetting);
        }

        // POST: ProfileSetting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profileSetting = await _context.ProfileSetting.FindAsync(id);
            _context.ProfileSetting.Remove(profileSetting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileSettingExists(int id)
        {
            return _context.ProfileSetting.Any(e => e.Id == id);
        }
    }
}
