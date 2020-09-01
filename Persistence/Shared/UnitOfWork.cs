using Application.Interfaces.Persistence;

namespace Persistence.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;

        public UnitOfWork(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Save()
        {
            _databaseContext.Save();
        }
    }
}