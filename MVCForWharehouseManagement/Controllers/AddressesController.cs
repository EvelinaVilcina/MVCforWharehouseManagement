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
    public class AddressesController : Controller
    {
        private readonly WharehouseManagementContext _context;

        public AddressesController(WharehouseManagementContext context)
        {
            _context = context;
        }

        // GET: Addresses
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "country_desc" : "";
            
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var addresses = _context.Addreses.AsQueryable();
                           
            if (!String.IsNullOrEmpty(searchString))
            {
                addresses = addresses.Where(a => a.StreetName.Contains(searchString)
                                       || a.Country.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "country_desc":
                    addresses = addresses.OrderByDescending(a => a.Country);
                    break;
                default:
                    addresses = addresses.OrderBy(a => a.StreetName);
                    break;
            }
            int pageSize = 3;

            var addresesView = addresses.Select(a => new AddressesViewModel
            {
                AddressId = a.AddressId,
                StreetName = a.StreetName,
                HouseName = a.HouseName,
                City = a.City,
                Country = a.Country,
                Zip = a.Zip

            }).AsNoTracking();

            return View(await PaginatedLists<AddressesViewModel>.CreateAsync(addresesView, pageNumber ?? 1, pageSize));
        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addreses                
                .FirstOrDefaultAsync(m => m.AddressId == id);

            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StreetName,HouseName,City,Country,Zip")] Address address)
        {
            try
            {
                if (ModelState.IsValid)
            {
                _context.Add(address);
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
            return View(address);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addreses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        // POST: Addresses/Edit/5
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

            var addressToUpdate = await _context.Addreses.FirstOrDefaultAsync(a => a.AddressId == id);

            if (await TryUpdateModelAsync<Address>(
                addressToUpdate,
                "",
                a => a.StreetName, a => a.HouseName, a => a.City, a => a.Country, a => a.Zip))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(addressToUpdate);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addreses
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.AddressId == id);
            if (address == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(address);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _context.Addreses.FindAsync(id);
            if (address == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Addreses.Remove(address);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool AddressExists(int id)
        {
            return _context.Addreses.Any(e => e.AddressId == id);
        }
    }
}
