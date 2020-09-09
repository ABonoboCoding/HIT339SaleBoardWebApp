 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MLSaleBoard.Data;
using MLSaleBoard.Models;

namespace MLSaleBoard
{
    public class CartItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CartItemsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: CartItems
        public IActionResult Index()
        {
            var buyer = _userManager.GetUserName(User);

            if (buyer == null)
            {
                ViewBag.errorMessage = "You are currently not logged in, please log in!";
                return View("Views/Home/Error.cshtml", ViewBag.errorMessage);
            }

            var cartitems = _context.CartItems
                .Where(i => i.Buyer == buyer);
            return View(cartitems);
        }

        // GET: CartItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItems = await _context.CartItems
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cartItems == null)
            {
                return NotFound();
            }

            var items = await _context.Items
                .FirstOrDefaultAsync(i => i.Id == cartItems.Item);

            return View("Views/Items/Details.cshtml", items);
        }

        // GET: CartItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CartItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CartId,Item,ItemQuantity,Buyer")] CartItems cartItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartItems);
        }

        // GET: CartItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItems = await _context.CartItems.FindAsync(id);
            if (cartItems == null)
            {
                return NotFound();
            }
            return View(cartItems);
        }

        // POST: CartItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CartId,Item,ItemQuantity,Buyer")] CartItems cartItems)
        {
            if (id != cartItems.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartItemsExists(cartItems.Id))
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
            return View(cartItems);
        }

        // GET: CartItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItems = await _context.CartItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartItems == null)
            {
                return NotFound();
            }

            return View(cartItems);
        }

        // POST: CartItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartItems = await _context.CartItems.FindAsync(id);
            _context.CartItems.Remove(cartItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Get request to complete payment 
        public async Task <IActionResult> PaymentConfirmed()
        {
            var buyer = _userManager.GetUserName(User);

            //Defining a check for loop
            var check = 1;

            //Defining a check for checking if cart is empty from the beginning
            var emptyCart = 1;

            while (check == 1)
            {
                Sales sales = new Sales();
                sales.Buyer = buyer;

                // make the sale
                _context.Add(sales);

                // find the items
                var cartItems = await _context.CartItems
                    .FirstOrDefaultAsync(c => c.Buyer == buyer);

                //Check if cart is empty
                if (cartItems == null)
                {
                    if (emptyCart==1)
                    {
                        ViewBag.errorMessage = "There are no items in your cart! Please add items to your cart before processing!";
                        return View("Views/Home/Error.cshtml", ViewBag.errorMessage);
                    }
                    check = 0;
                    break;
                }

                emptyCart = 0;

                sales.Item = cartItems.Item;
                sales.ItemQuantity = cartItems.ItemQuantity;
         
                var items = await _context.Items
                    .FirstOrDefaultAsync(i => i.Id == cartItems.Item);

                sales.Total = sales.ItemQuantity * items.ItemPrice;

                sales.Seller = items.Seller;

                //Check if there are any stock for the item
                if (items.ItemQuantity == 0)
                {
                    ViewBag.errorMessage = "This are no stock available for a item at the moment, please check back later.";
                    return View("Views/Home/Error.cshtml", ViewBag.errorMessage);
                }

                //Check if buying quantity is over quantity available
                if (items.ItemQuantity < cartItems.ItemQuantity)
                {
                    ViewBag.errorMessage = "Hi, it seems like the quantity of purchase is higher than the quantity you wish to purchase, please readjust the quantity of purchase then try again! Thank you.";
                    return View("Views/Home/Error.cshtml", ViewBag.errorMessage);
                }

                // update the quantity
                items.ItemQuantity -= sales.ItemQuantity;

                //remove the item from the cart
                _context.CartItems.Remove(cartItems);

                _context.Update(items);

                await _context.SaveChangesAsync();
            }

            return View();
        }

        private bool CartItemsExists(int id)
        {
            return _context.CartItems.Any(e => e.Id == id);
        }
    }
}
