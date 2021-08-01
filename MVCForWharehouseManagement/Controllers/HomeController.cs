using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVCForWharehouseManagement.Data;
using MVCForWharehouseManagement.Models;
using MVCForWharehouseManagement.Models.WharehouseManagementViewModels;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
 
namespace MVCForWharehouseManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WharehouseManagementContext _context;


        public HomeController(ILogger<HomeController> logger, WharehouseManagementContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<ActionResult> About()
        {
            IQueryable<OrderDateGroup> data =
                from order in _context.Orders
                group order by order.DateTime into dateGroup
                select new OrderDateGroup()
                {
                    DateTime = dateGroup.Key,
                    OrderCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        public IActionResult Index()
        {
            return View();
        }
     
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
