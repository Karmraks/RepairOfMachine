using Microsoft.AspNetCore.Mvc;
using RepairOfMachine.Models;
using System.Diagnostics;
using RepairOfMachine.Abstractions.Interfaces;
using RepairOfMachine.Repositories;

namespace RepairOfMachine.Controllers
{
    public class HomeController(ILogger<HomeController> logger, INewsRepository newsRepository)
        : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> News()
        {
            var users = await newsRepository.GetAllAsync();
            return View(users);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
