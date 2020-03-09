using PetsWeb.Repositories;

namespace PetsWeb.Repositories
{
    public interface IUnitOfWork
    {
        INativeSqlRepo NativeSql { get; }
        ICompanyRepo Company { get; }
        ICountryRepo Country { get; }
        ICityRepo City { get; }
        IAnimalTypeRepo AnimalType { get; }
        IBreedRepo Breed { get; }
        ICoatColourRepo CoatColour { get; }
        ILocationOfMicrochipRepo LocationOfMicrochip { get; }
        IUserAccountRepo UserAccount { get; }
        IDetailsOfOwnershipRepo DetailsOfOwnership { get; }
        IDiscriptionOfAnimalRepo DiscriptionOfAnimal { get; }
        IPhysicalExaminationRepo PhysicalExamination { get; }
        void Complete();
    }
}