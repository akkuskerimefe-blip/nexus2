using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nexus2.Data; // AppDbContext burada
using nexus2.Models; // Modeller burada

namespace nexus2.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Postlarý kullanýcýlarý, beðenileri ve yorumlarýyla birlikte çekiyoruz
            var posts = await _context.Posts
                .Include(p => p.User)
                .Include(p => p.Likes)
                .Include(p => p.Comments)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            return View(posts);
        }
    }
}