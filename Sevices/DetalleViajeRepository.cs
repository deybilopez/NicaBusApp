using NicaBusMVC.Data;
using NicaBusMVC.Models;

namespace NicaBusMVC.Sevices
{
    public class DetalleViajeRepository : GenericRepository<DetallesViaje>, IDetalleViajeRepository
    {
        public DetalleViajeRepository(NicaBusMVCContext context) : base(context)
        {
            _context = context
        }
    }
}
