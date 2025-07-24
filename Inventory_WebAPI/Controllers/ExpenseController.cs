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
    public class ExpenseController : ControllerBase
    {
        private InventoryDbContext _context;
 
        public ExpenseController(InventoryDbContext context)
        {
            _context = context;
        }
 
        [HttpGet]
        public List<Expense> GetVendors()
        {
            return _context.Expenses.ToList();
        }
 
        [HttpPost]
        public async Task<IActionResult> AddExpense(Expense newExpenseType)
        {
            try
            {
                _context.Expenses.Add(newExpenseType);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException.Message);
            }
 
        }
 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(Guid id)
        {
            try
            {
                var expense = await _context.Expenses.FindAsync(id);
                Debug.Write(expense);
                if (expense == null)
                {
                    return NotFound();
                }
 
                _context.Expenses.Remove(expense);
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