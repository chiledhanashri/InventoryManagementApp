using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Inventory_WebAPI.Context;
using Inventory_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SparePartsController : ControllerBase
    {
        private InventoryDbContext _context;
 
        public SparePartsController(InventoryDbContext context)
        {
            _context = context;
        }
 
        [HttpGet]
        public List<Sparepart> GetSpareParts()
        {
            return _context.Spareparts.ToList();
        }
 
        [HttpPost]
        public async Task<IActionResult> AddSparePart(Sparepart sparePart)
        {
            try
            {
                _context.Spareparts.Add(sparePart);
                await _context.SaveChangesAsync(); // ✅ Use async version
                return Ok();
 
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
 
        }
 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSparePart(Guid id)
        {
 
            try
            {
                var sparePart = await _context.Spareparts.FindAsync(id);
                Debug.Write(sparePart);
                if (sparePart == null)
                {
                    return NotFound();
                }
 
                _context.Spareparts.Remove(sparePart);
                await _context.SaveChangesAsync();
 
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
 
            }
 
 
            }
           
           
 
    }
}