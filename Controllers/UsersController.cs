using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using NicaBusMVC.Configuration;
using NicaBusMVC.Data;
using NicaBusMVC.Models;

namespace NicaBusMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUnidOfWork _unitOfWork;

        private readonly NicaBusMVCContext _context;

        public UsersController(NicaBusMVCContext context, IUnidOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.UserRepository.GetAllAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["DetallesViajeId"] = new SelectList(_context.DetallesViaje, "Id", "Id");
            ViewData["RutaId"] = new SelectList(_context.Ruta, "Id", "Id");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,DetallesViajeId,RutaId")] User user)
        {

            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.commit();
            return RedirectToAction(nameof(Index));

        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["DetallesViajeId"] = new SelectList(_context.DetallesViaje, "Id", "Id", user.DetallesViajeId);
            ViewData["RutaId"] = new SelectList(_context.Ruta, "Id", "Id", user.RutaId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password,DetallesViajeId,RutaId")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            try
            {
                _unitOfWork.UserRepository.Update(user);
                _unitOfWork.commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'NicaBusMVCContext.User'  is null.");
            }

            _unitOfWork.UserRepository.Delete(id);

            _unitOfWork.commit();

            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _unitOfWork.UserRepository.GetByIdAsync(id) != null;
        }
    }
}
