using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hoviedo.Ecommerce.Api.Data;
using Hoviedo.Ecommerce.Api.Models;

namespace Hoviedo.Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly EcomDbContext _context;

        public CartController(EcomDbContext context)
        {
            _context = context;
        }

        // GET: api/Cart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCart()
        {
            return await _context.Cart.Include(c => c.Product).ToListAsync();
        }

        // GET: api/Cart/5
        [HttpGet("{email}")]
        public async Task<ActionResult<Cart>> GetCart(String email)
        {
            var cart = await _context.Cart.FindAsync(email);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // PUT: api/Cart/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{email}")]
        public async Task<IActionResult> PutCart(String email, Cart cart)
        {
            if (email != cart.Email)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(email))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool CartExists(string email)
        {
            throw new NotImplementedException();
        }

        // POST: api/Cart
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cart>> PostCart(Cart cart)
        {
            _context.Cart.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCart", new { String = cart  }, cart);
        }

        // DELETE: api/Cart/5
        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteCart(String email)
        {
            var cart = _context.Cart.FirstOrDefault(per=>per.Email==email);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

      
    }
}
