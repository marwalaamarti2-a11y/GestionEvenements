using System.ComponentModel.DataAnnotations;

namespace GestionEvenements.Models
{
    public class Evenement
    {
        public int Id { get; set; }  // Identifiant unique

        [Required(ErrorMessage = "Le titre est obligatoire")]
        [StringLength(150, ErrorMessage = "Le titre ne doit pas dépasser 150 caractères")]
        public string Titre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La description est obligatoire")]
        [StringLength(500, ErrorMessage = "La description ne doit pas dépasser 500 caractères")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "La date est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Le lieu est obligatoire")]
        [StringLength(200, ErrorMessage = "Le lieu ne doit pas dépasser 200 caractères")]
        public string Lieu { get; set; } = string.Empty;

        // Relation vers l'organisateur
        [Required(ErrorMessage = "L'organisateur est obligatoire")]
        public int OrganisateurId { get; set; }
        public Organisateur? Organisateur { get; set; }
    }
}