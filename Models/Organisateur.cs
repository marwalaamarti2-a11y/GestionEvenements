using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionEvenements.Models
{
    public class Organisateur
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(100, ErrorMessage = "Le nom ne doit pas dépasser 100 caractères")]
        public string Nom { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'email est obligatoire")]
        [EmailAddress(ErrorMessage = "L'adresse email n'est pas valide")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le téléphone est obligatoire")]
        [Phone(ErrorMessage = "Le numéro de téléphone n'est pas valide")]
        public string Telephone { get; set; } = string.Empty;

        // Relation vers les événements
        public ICollection<Evenement> Evenements { get; set; } = new List<Evenement>();
    }
}