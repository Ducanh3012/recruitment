using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using recruitment.Data;
using recruitment.Models;

namespace recruitment.Controllers
{
    public class UserApplicationsController : Controller
    {
        private readonly recruitmentContext _context;

        public UserApplicationsController(recruitmentContext context)
        {
            _context = context;
        }

        // GET: UserApplications
        public async Task<IActionResult> Index()
        {
            var recruitmentContext = _context.UserApplication.Include(u => u.ApplicationStatus).Include(u => u.JobListing).Include(u => u.User);
            return View(await recruitmentContext.ToListAsync());
        }

        // GET: UserApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserApplication == null)
            {
                return NotFound();
            }

            var userApplication = await _context.UserApplication
                .Include(u => u.ApplicationStatus)
                .Include(u => u.JobListing)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserApplicationId == id);
            if (userApplication == null)
            {
                return NotFound();
            }

            return View(userApplication);
        }

        // GET: UserApplications/Create
        public IActionResult Create()
        {
            ViewData["ApplicationStatusId"] = new SelectList(_context.Set<ApplicationStatus>(), "ApplicationStatusId", "ApplicationStatusId");
            ViewData["JobListingId"] = new SelectList(_context.Set<JobListing>(), "JobListingId", "JobListingId");
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId");
            return View();
        }

        // POST: UserApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserApplicationId,UserId,JobListingId,ApplicationStatusId")] UserApplication userApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationStatusId"] = new SelectList(_context.Set<ApplicationStatus>(), "ApplicationStatusId", "ApplicationStatusId", userApplication.ApplicationStatusId);
            ViewData["JobListingId"] = new SelectList(_context.Set<JobListing>(), "JobListingId", "JobListingId", userApplication.JobListingId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId", userApplication.UserId);
            return View(userApplication);
        }

        // GET: UserApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserApplication == null)
            {
                return NotFound();
            }

            var userApplication = await _context.UserApplication.FindAsync(id);
            if (userApplication == null)
            {
                return NotFound();
            }
            ViewData["ApplicationStatusId"] = new SelectList(_context.Set<ApplicationStatus>(), "ApplicationStatusId", "ApplicationStatusId", userApplication.ApplicationStatusId);
            ViewData["JobListingId"] = new SelectList(_context.Set<JobListing>(), "JobListingId", "JobListingId", userApplication.JobListingId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId", userApplication.UserId);
            return View(userApplication);
        }

        // POST: UserApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserApplicationId,UserId,JobListingId,ApplicationStatusId")] UserApplication userApplication)
        {
            if (id != userApplication.UserApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserApplicationExists(userApplication.UserApplicationId))
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
            ViewData["ApplicationStatusId"] = new SelectList(_context.Set<ApplicationStatus>(), "ApplicationStatusId", "ApplicationStatusId", userApplication.ApplicationStatusId);
            ViewData["JobListingId"] = new SelectList(_context.Set<JobListing>(), "JobListingId", "JobListingId", userApplication.JobListingId);
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "UserId", "UserId", userApplication.UserId);
            return View(userApplication);
        }

        // GET: UserApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserApplication == null)
            {
                return NotFound();
            }

            var userApplication = await _context.UserApplication
                .Include(u => u.ApplicationStatus)
                .Include(u => u.JobListing)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserApplicationId == id);
            if (userApplication == null)
            {
                return NotFound();
            }

            return View(userApplication);
        }

        // POST: UserApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserApplication == null)
            {
                return Problem("Entity set 'recruitmentContext.UserApplication'  is null.");
            }
            var userApplication = await _context.UserApplication.FindAsync(id);
            if (userApplication != null)
            {
                _context.UserApplication.Remove(userApplication);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserApplicationExists(int id)
        {
          return (_context.UserApplication?.Any(e => e.UserApplicationId == id)).GetValueOrDefault();
        }
    }
}
