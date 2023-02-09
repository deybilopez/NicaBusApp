using Microsoft.EntityFrameworkCore;
using NicaBusMVC.Data;
using NicaBusMVC.Models;

namespace NicaBusMVC.Sevices
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        private readonly NicaBusMVCContext _context;
        public UserRepository(NicaBusMVCContext context): base(context)
        {
            _context = context;
           
        }
        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            var nicaBusMVCContext = _context.User.Include(u => u.DetallesViaje).Include(u => u.Ruta);
            return await nicaBusMVCContext.ToListAsync();
        }

        public virtual async Task<User> GetByIdAsync(int id)
        {
            return await _dbSet.Include(u => u.DetallesViaje)
            .Include(u => u.Ruta)
            .FirstOrDefaultAsync(m => m.Id == id);
        }

    }
}
