using PetsWeb.Repositories;

namespace Pets_Web.Repositories
{
    public interface IUnitOfWork
    {
        ICountryRepo Country { get; }
        ICityRepo City { get; }
        IAnimalTypeRepo AnimalType { get; }
        IBreedRepo Breed { get; }
        ICoatColourRepo CoatColour { get; }
        ILocationOfMicrochipRepo LocationOfMicrochip { get; }
        void Complete();
    }
}