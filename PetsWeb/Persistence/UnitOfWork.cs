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

        public ICompanyRepo Company { get; set; }
        public IPhysicalExaminationRepo PhysicalExamination { get; set; }
        
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            PhysicalExamination = new PhysicalExaminationRepo(_context);
            Company = new  CompanyRepo(_context);
            UserAccount = new UserAccountRepo(_context);
            Country = new CountryRepo(_context);
            City = new CityRepo(_context);
            AnimalType = new AnimalTypeRepo(_context);
            Breed = new BreedRepo(_context);
            CoatColour = new CoatColourRepo(_context);
            LocationOfMicrochip = new LocationOfMicrochipRepo(_context);
            NativeSql = new NativeSqlRepo(_context);
        }
        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}