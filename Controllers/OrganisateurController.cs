using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionEvenements.Data;
using GestionEvenements.Models;

namespace GestionEvenements.Controllers
{
    public class OrganisateurController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrganisateurController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Organisateur
        public async Task<IActionResult> Index()
        {
            var organisateurs = await _context.Organisateurs.ToListAsync();
            return View(organisateurs);
        }

        // GET: Organisateur/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organisateur/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Organisateur organisateur)
        {
            if (ModelState.IsValid)
            {
                _context.Organisateurs.Add(organisateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organisateur);
        }

        // POST: Organisateur/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var organisateur = await _context.Organisateurs.FindAsync(id);
            if (organisateur != null)
            {
                _context.Organisateurs.Remove(organisateur);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}