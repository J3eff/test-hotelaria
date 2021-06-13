using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestHotelaria.Data.Context;
using TestHotelaria.Models;

namespace TestHotelaria.Controllers
{ 
    [Route("")]
    public class HotelsController : Controller
    {
        private readonly MeuDbContext _context;

        public HotelsController(MeuDbContext context)
        {
            _context = context;
        }

        [Route("lista-de-hoteis")]
        public async Task<IActionResult> Index(string buscaPorNome )
        {
            var nome = from n in _context.Hoteis select n;

            if (!String.IsNullOrEmpty(buscaPorNome))
            {
                nome = nome
                    .Where(b => b.Nome.Contains(buscaPorNome));
            }

            return View(await nome.ToListAsync());
        }

        [Route("detalhes-de-hoteis/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {   
            var hotel = await _context.Hoteis.FirstOrDefaultAsync(m => m.Id == id);

            if (hotel == null) return NotFound();            

            return View(hotel);
        }

        [Route("novo-hotel")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-hotel")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Hotel hotel)
        {
            if (!ModelState.IsValid) return View(hotel);

            _context.Add(hotel);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [Route("editar-hotel/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var hotel = await _context.Hoteis.FindAsync(id);

            if (hotel == null) return NotFound();
            
            return View(hotel);
        }

        [Route("editar-hotel/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Hotel hotel)
        {
            if (id != hotel.Id) return NotFound();

            if (!ModelState.IsValid) return View(hotel);

            _context.Update(hotel);            
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");            
        }

        [Route("excluir-hotel/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var hotel = await _context.Hoteis.FirstOrDefaultAsync(m => m.Id == id);

            if (hotel == null) return NotFound();
            
            return View(hotel);
        }

        [Route("excluir-hotel/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var hotel = await _context.Hoteis.FindAsync(id);
            if (hotel == null) return NotFound();

            _context.Hoteis.Remove(hotel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool HotelExists(Guid id)
        {
            return _context.Hoteis.Any(e => e.Id == id);
        }
    }
}
