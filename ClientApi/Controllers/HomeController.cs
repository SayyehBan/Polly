using ClientApi.Models;
using ClientApi.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClientApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiService apiService;

        public HomeController(ILogger<HomeController> logger, IApiService apiService)
        {
            _logger = logger;
            this.apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await apiService.GetValues();
            return View(result);
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
