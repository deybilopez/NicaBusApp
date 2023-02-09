using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NicaBusMVC.Data;
using NicaBusMVC.Models;

namespace NicaBusMVC.Sevices
{
    public class RutaRepository: GenericRepository<Ruta>, IRutaRepository
    {
        private readonly NicaBusMVCContext _context;
        private int id;

        public RutaRepository(NicaBusMVCContext context) : base(context)
        {
            _context = context;
        }
    }
}
