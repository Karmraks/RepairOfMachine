using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepairOfMachine.Abstractions.Interfaces;
using RepairOfMachine.Models.Entities;

namespace RepairOfMachine.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController(IUserRepository userRepository, INewsRepository newsRepository)
        : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var users = await userRepository.GetAllAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> News()
        {
            var news = await newsRepository.GetAllAsync();
            return View(news);
        }

        [HttpGet]
        public async Task<IActionResult> AddNews()
        {
            return View();
        }

        [HttpGet]
        [Route("/[controller]/DeleteNewsCheck/{id}")]
        public async Task<IActionResult> DeleteNewsCheck(int id)
        {
            var news = await newsRepository.GetAsync(id);
            return View(news);
        }

        [HttpPost]
        [Route("/[controller]/DeleteNews")]
        public async Task<IActionResult> DeleteNews(int id)
        {
            await newsRepository.DeleteAsync(id);
            return RedirectToAction(nameof(News));
        }

        [HttpPost]
        public async Task<IActionResult> AddNews(News news)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.Identity.Name;
            if (!string.IsNullOrEmpty(userId))
            {
                news.UserId = userId;
                news.UserName = userName;

                news.CreatedDate = DateTime.SpecifyKind(news.CreatedDate, DateTimeKind.Utc);

                await newsRepository.CreateAsync(news);
            }
            return RedirectToAction(nameof(News));
        }

        [HttpGet]
        [Route("/[controller]/UpdateNews/{id}")]
        public async Task<IActionResult> UpdateNews(int id)
        {
            var news = await newsRepository.GetAsync(id);
            return View(news);
        }

        [HttpPost]
        [Route("/[controller]/UpdateNews/{id}")]
        public async Task<IActionResult> UpdateNews(News news)
        {
            news.CreatedDate = DateTime.SpecifyKind(news.CreatedDate, DateTimeKind.Utc);
            await newsRepository.UpdateAsync(news);

            return RedirectToAction(nameof(News));
        }
    }
}
