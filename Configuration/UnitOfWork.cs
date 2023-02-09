using NicaBusMVC.Data;
using NicaBusMVC.Sevices;

namespace NicaBusMVC.Configuration
{
    public class UnitOfWork : IUnidOfWork, IDisposable
    {
        private readonly NicaBusMVCContext _context;
        public IUserRepository UserRepository { get; private set; }

        public IDetalleViajeRepository DetalleViajeRepository { get; private set; }

        public IRutaRepository RutaRepository { get; private set; }

        public UnitOfWork(NicaBusMVCContext context)
        {
            _context = context;

            UserRepository = new UserRepository(_context);
            RutaRepository = new RutaRepository(_context);
            DetalleViajeRepository = new DetalleViajeRepository(_context);

        }

        public void commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }


}
