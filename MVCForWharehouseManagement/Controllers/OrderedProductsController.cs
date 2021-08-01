using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCForWharehouseManagement.Data;
using MVCForWharehouseManagement.Models;
using MVCForWharehouseManagement.Models.DataViewModels;

namespace MVCForWharehouseManagement.Controllers
{
    public class OrderedProductsController : Controller
    {
        private readonly WharehouseManagementContext _context;

        public OrderedProductsController(WharehouseManagementContext context)
        {
            _context = context;
        }

        // GET: OrderedProducts
        public async Task<IActionResult> Index(string searchString, int? pageNumber)
        {
            ViewData["CurrentFilter"] = searchString;

            var orderedProducts = _context.OrderedProducts.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                orderedProducts = orderedProducts.Where(o => o.Name.Contains(searchString));                                       
            }

            int pageSize = 3;

            var OrderedProductsView = orderedProducts.Select(o => new OrderedProductsViewModel
            {
                OrderedProductID = o.OrderedProductID,
                ProductID = o.ProductID,
                Name = o.Name,
                OrderNumber = o.OrderNumber

            }).AsNoTracking();

            return View(await PaginatedLists<OrderedProductsViewModel>.CreateAsync(OrderedProductsView, pageNumber ?? 1, pageSize)); ;
        }

        // GET: OrderedProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderedProducts = await _context.OrderedProducts
                .FirstOrDefaultAsync(m => m.OrderedProductID == id);

            if (orderedProducts == null)
            {
                return NotFound();
            }

            return View(orderedProducts);
        }

        // GET: OrderedProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderedProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Name,OrderNumber")] OrderedProducts orderedProducts)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(orderedProducts);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(orderedProducts);
        }

        // GET: OrderedProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderedProducts = await _context.OrderedProducts.FindAsync(id);
            if (orderedProducts == null)
            {
                return NotFound();
            }
            return View(orderedProducts);
        }

        // POST: OrderedProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var orderedProductToUpdate = await _context.OrderedProducts.FirstOrDefaultAsync(o => o.OrderedProductID == id);
            if (await TryUpdateModelAsync(
                (OrderedProducts)orderedProductToUpdate,
                "",
                o => o.ProductID, o => o.Name, o => o.OrderNumber))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return base.RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(orderedProductToUpdate);
        }

        // GET: OrderedProducts/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderedProduct = await _context.OrderedProducts
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.OrderedProductID == id);
            if (orderedProduct == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(orderedProduct);
        }

        // POST: OrderedProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderedProduct = await _context.OrderedProducts.FindAsync(id);
            if (orderedProduct == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.OrderedProducts.Remove(orderedProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool OrderedProductsExists(int id)
        {
            return _context.OrderedProducts.Any(e => e.OrderedProductID == id);
        }
    }
}
