using _050_MUHAMMAD_SAQLAIN.Data;
using _050_MUHAMMAD_SAQLAIN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _050_MUHAMMAD_SAQLAIN.Controllers
{
    public class OrderM : Controller
    {
        private readonly DbStore _context;


        public OrderM(DbStore context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Order o)

        {
            _context.Orders.Add(o);
            _context.SaveChanges();
            return View(o);
        }
        public IActionResult show()
        {
            var save = _context.Orders.ToList();
            return View(save);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();
            var orderModelInDb = await _context.Orders.FirstOrDefaultAsync(os => os.Id == id);
            if (orderModelInDb == null)
                return NotFound();
            _context.Orders.Remove(orderModelInDb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = _context.Orders.FirstOrDefault(os => os.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);

        }
    }
}
