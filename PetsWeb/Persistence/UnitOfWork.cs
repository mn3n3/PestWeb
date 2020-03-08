using PetsWeb.Repositories;
 
 

namespace PetsWeb.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserAccountRepo UserAccount { get; private set; }
        public INativeSqlRepo NativeSql { get; set; }
        public ICountryRepo Country { get; set; }
        public ICityRepo City { get; set; }
        public IAnimalTypeRepo AnimalType { get; set; }
        public IBreedRepo Breed { get; set; }
        public ICoatColourRepo CoatColour { get; set; }
        public ILocationOfMicrochipRepo LocationOfMicrochip { get; set; }
        public IDetailsOfOwnershipRepo DetailsOfOwnership { get; set; }
        public IDiscriptionOfAnimalRepo DiscriptionOfAnimal { get; set; }
        public ICompanyRepo  Company { get; set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Company = new  CompanyRepo(context);
            UserAccount = new UserAccountRepo(context);
            Country = new CountryRepo(_context);
            City = new CityRepo(_context);
            AnimalType = new AnimalTypeRepo(_context);
            Breed = new BreedRepo(_context);
            CoatColour = new CoatColourRepo(_context);
            LocationOfMicrochip = new LocationOfMicrochipRepo(_context);
            DetailsOfOwnership = new DetailsOfOwnershipRepo(_context);
            DiscriptionOfAnimal = new DiscriptionOfAnimalRepo(_context);
            NativeSql = new NativeSqlRepo(_context);
        }
        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}