using PetsWeb.Repositories;

namespace PetsWeb.Repositories
{
    public interface IUnitOfWork
    {
        ICompanyRepo Company { get; }
        ICountryRepo Country { get; }
        ICityRepo City { get; }
        IAnimalTypeRepo AnimalType { get; }
        IBreedRepo Breed { get; }
        ICoatColourRepo CoatColour { get; }
        ILocationOfMicrochipRepo LocationOfMicrochip { get; }

        IUserAccountRepo UserAccount { get; }
        void Complete();
    }
}