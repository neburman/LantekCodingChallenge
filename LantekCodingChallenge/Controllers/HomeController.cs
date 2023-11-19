using LantekCodingChallenge.Helpers;
using LantekCodingChallenge.Models;
using LantekCodingChallenge.Models.Responses;
using LantekCodingChallenge.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LantekCodingChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [Route("{technologyFilter?}")]
        public async Task<IActionResult> IndexAsync(int? technologyFilter = null)
        {
            if (technologyFilter.HasValue && technologyFilter != 2 && technologyFilter != 3) { technologyFilter = null; }
            string apiCredentials = $"{_configuration["LantekApiCrendentials:Username"]}:{_configuration["LantekApiCrendentials:Password"]}";
            List<CuttingMachine>? lantekMachinesResponse = await new LantekCallRest<dynamic, List<CuttingMachine>?>().CallRestAsync(
                        $"https://app-academy-neu-codechallenge.azurewebsites.net/api/cut{(technologyFilter != null ? $"/{technologyFilter}" : "")}",
                        "GET",
                        Helper.EncodeToBase64(apiCredentials));
            return View(new HomeViewModel { CuttingMachines = lantekMachinesResponse });
        }

        public IActionResult PageNotFound() => RedirectToAction("Index");

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
