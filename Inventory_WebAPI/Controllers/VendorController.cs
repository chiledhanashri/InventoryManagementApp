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
    public class VendorController : ControllerBase
    {
        private InventoryDbContext _context;
 
        public VendorController(InventoryDbContext context)
        {
            _context = context;
        }
 
        [HttpGet]
        public List<Vendor> GetVendors()
        {
            return _context.Vendors.ToList();
        }
 
        [HttpPost]
        public async Task<IActionResult> AddVendors(Vendor vendor)
        {
            try
            {
                _context.Vendors.Add(vendor);
                await _context.SaveChangesAsync(); // ✅ Use async version
                return Ok();
 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException.Message);
            }
 
        }
 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor(Guid id)
        {
 
            try
            {
                var vendor = await _context.Vendors.FindAsync(id);
                Debug.Write(vendor);
                if (vendor == null)
                {
                    return NotFound();
                }
 
                _context.Vendors.Remove(vendor);
               
                await _context.SaveChangesAsync();
 
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException.Message);
            }
        }  
 
    }
 
}
