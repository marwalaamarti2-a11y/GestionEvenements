using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionEvenements.Data;
using GestionEvenements.Models;

namespace GestionEvenements.Controllers
{
    public class EvenementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EvenementController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var evenements = _context.Evenements
                .Include(e => e.Organisateur)
                .ToList();
            return View(evenements);
        }

        // Affichage formulaire Create
        public IActionResult Create()
        {
            ViewBag.Organisateurs = _context.Organisateurs.ToList();
            return View();
        }

        // Traitement formulaire Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Evenement evenement)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Organisateurs = _context.Organisateurs.ToList();
                return View(evenement);
            }

            _context.Evenements.Add(evenement);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Affichage formulaire Edit
        public IActionResult Edit(int id)
        {
            var evenement = _context.Evenements.Find(id);

            if (evenement == null)
            {
                return NotFound();
            }

            ViewBag.Organisateurs = _context.Organisateurs.ToList();
            return View(evenement);
        }

        // Traitement Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Evenement evenement)
        {
            if (id != evenement.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Organisateurs = _context.Organisateurs.ToList();
                return View(evenement);
            }

            var evenementExistant = _context.Evenements.Find(id);

            if (evenementExistant != null)
            {
                evenementExistant.Titre = evenement.Titre;
                evenementExistant.Description = evenement.Description;
                evenementExistant.Date = evenement.Date;
                evenementExistant.Lieu = evenement.Lieu;
                evenementExistant.OrganisateurId = evenement.OrganisateurId;

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // Suppression
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var evenement = _context.Evenements.Find(id);

            if (evenement != null)
            {
                _context.Evenements.Remove(evenement);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
