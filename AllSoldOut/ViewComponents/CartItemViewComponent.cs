using AllSoldOut.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllSoldOut.ViewComponents
{
    public class CartItemViewComponent : ViewComponent
    {
        private readonly CartContext _context;

        public CartItemViewComponent(CartContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cartItems = await GetItemsAsync();
            ViewBag.sumOfTotal = await _context.carts.Select(y => y.total).SumAsync();

            return View(cartItems);
        }
        private Task<List<Cart>> GetItemsAsync()
        {
            return _context.carts.ToListAsync();
        }
    }
}
