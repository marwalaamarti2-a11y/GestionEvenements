# GestionEvenements

Application web de gestion d'événements et de leurs organisateurs, développée avec ASP.NET Core MVC.

## Fonctionnalités

- Gestion des événements : création, consultation et modification
- Gestion des organisateurs : création, consultation et modification
- Association d'un événement à un organisateur (relation par clé étrangère)
- Validation des formulaires côté client et côté serveur

## Technologies utilisées

| Domaine | Technologies |
|---|---|
| Langage | C# |
| Framework | ASP.NET Core MVC (.NET 9) |
| Accès aux données | Entity Framework Core, migrations |
| Base de données | SQLite |
| Interface | Razor (vues .cshtml), Bootstrap, jQuery Validation |
| Outils | Git, GitHub, Visual Studio / VS Code |

## Architecture

- `Models/` : entités `Evenement` et `Organisateur`
- `Data/` : contexte de base de données `ApplicationDbContext`
- `Controllers/` : contrôleurs MVC (Evenement, Organisateur, Home)
- `Views/` : vues Razor
- `Migrations/` : historique du schéma de la base de données

## Lancer le projet

Prérequis : .NET 9 SDK.

    git clone https://github.com/marwalaamarti2-a11y/GestionEvenements.git
    cd GestionEvenements
    dotnet ef database update
    dotnet run

Puis ouvrir l'adresse affichée dans le terminal (par exemple https://localhost:5001).

## Auteure

Marwa Laamarti, élève ingénieure en Génie Informatique à l'ENSA Fès
[LinkedIn](https://www.linkedin.com/in/marwa-laamarti-9b384b318)
