using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleMvcWebWithUi.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SampleMvcWebWithUi.Controllers
{
    [Authorize]
    public class ProdutoController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public ProdutoController(ILogger<HomeController> logger, RoleManager<ApplicationRole> roleManager)
        {
            _logger = logger;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            //var role = new ApplicationRole { Name = "Test1" };
            //var result = await _roleManager.CreateAsync(role);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public async Task<IActionResult> Batata()
        {
            return Ok("batata");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}