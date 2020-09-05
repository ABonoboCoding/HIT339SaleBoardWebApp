using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using MinxuanLinSaleBoardSite.Data;
using MinxuanLinSaleBoardSite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MinxuanLinSaleBoardSite
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ItemsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        // GET: ItemsController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }

        // GET: Items/myItems
        public ActionResult MyItems()
        {   
            var seller = _userManager.GetUserName(User);
            
            if (seller == null)
            {
                ViewBag.errorMessage = "You are currently not logged in, please log in!";
                return View("Views/Home/Error.cshtml", ViewBag.errorMessage);
            }

            var items = _context.Items
                .Where(i => i.Seller == seller);
            return View("MyItems", items);
        }

        // GET: ItemsController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var items = await _context.Items
                .FirstOrDefaultAsync(i => i.Id == id);

            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // GET: ItemsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ItemName,ItemImg,ItemDesc,ItemPrice,ItemCategory,ItemQuantity,Posted,LastUpdated")] Items items)
        {
            if (ModelState.IsValid)
            {
                // get the seller
                var seller = _userManager.GetUserName(User);

                //if not logged in, cannot creaate item
                if (seller == null)
                {
                    ViewBag.errorMessage = "You are not logged in! Please log in!";
                    return View("Views/Home/Error.cshtml", ViewBag.errorMessage);
                }
                items.Seller = seller;
                _context.Add(items);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(items);
        }

        // GET: ItemsController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var items = await _context.Items.FindAsync(id);
            if (items == null)
            {
                return NotFound();
            }
            return View(items);
        }

        // POST: ItemsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ItemName,ItemImg,ItemDesc,ItemPrice,ItemCategory,ItemQuantity,Posted,LastUpdated,Seller")] Items items)
        {
            if (id != items.Id)
            {
                return NotFound();
            }

            var seller = _userManager.GetUserName(User);
            if (seller != items.Seller)
            {
                ViewBag.errorMessage = "You cannot edit this item as you are not logged in as the user who create the item.";
                return View("Views/Home/Error.cshtml", ViewBag.errorMessage);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(items);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemsExists(items.Id))
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
            return View(items);
        }

        // GET: ItemsController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var items = await _context.Items
                .FirstOrDefaultAsync(i => i.Id == id);

            if (items == null)
            {
                return NotFound();
            }

            var loggedInUser = _userManager.GetUserName(User);
            if (items.Seller != loggedInUser)
            {
                ViewBag.errorMessage = "You can not delete the item as you are not logged in as the user who create the item. Please log in!";
                return View("Views/Home/Error.cshtml", ViewBag.errorMessage);
            }

            return View(items);
        }

        // POST: ItemsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var items = await _context.Items.FindAsync(id);
            _context.Items.Remove(items);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: ItemsController/Purchase/5
        public async Task<IActionResult> Purchase(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var items = await _context.Items
                .FirstOrDefaultAsync(i => i.Id == id);
            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // POST: ItemsController/Purchase/5
        [HttpPost, ActionName("Purchase")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PurchaseConfirmed([Bind("Item,ItemQuantity")] Sales sales)
        {

            // get the buyer
            var buyer = _userManager.GetUserName(User);
            sales.Buyer = buyer;

            // make the sale
            _context.Add(sales);

            // find the item
            var items = await _context.Items
                .FirstOrDefaultAsync(i => i.Id == sales.Item);

            if (items == null)
            {
                return NotFound();
            }

            //Check if buying quantity is over quantity available
                if (items.ItemQuantity < sales.ItemQuantity)
            {
                ViewBag.errorMessage = "Hi, it seems like the quantity of purchase is higher than the quantity you wish to purchase, please readjust the quantity of purchase then try again! Thank you.";
                return View("Views/Home/Error.cshtml", ViewBag.errorMessage);
            }

            // update the quantity
            items.ItemQuantity -= sales.ItemQuantity;
            _context.Update(items);

            // Save the changes
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ItemsExists(int id)
        {
            return _context.Items.Any(i => i.Id == id);
        }
    }
}
