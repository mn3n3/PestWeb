using Pets_Web.Repositories;

namespace Pets_Web.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserAccountRepo UserAccount { get; private set; }


        public UnitOfWork(ApplicationDbContext context)
        {

            _context = context;

            UserAccount = new UserAccountRepo(context);


        }
        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}