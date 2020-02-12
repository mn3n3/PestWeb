using PetsWeb.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
 

namespace PetsWeb.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
 
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<DetailsOfOwnership> DetailsOfOwnerships { get; set; }
        public DbSet<DiscriptionOfAnimal> DiscriptionOfAnimals { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<CoatColour> CoatColours { get; set; }
        public DbSet<IdentificationOfAnimal> IdentificationOfAnimals { get; set; }
        public DbSet<LocationOfMicrochip> LocationOfMicrochips { get; set; }
        public DbSet<Company> Companies { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}