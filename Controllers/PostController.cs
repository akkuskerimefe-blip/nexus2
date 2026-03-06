using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nexus2.Data;
using nexus2.Models;

namespace nexus2.Controllers
{
    public class PostController : Controller
    {
        private readonly AppDbContext _context;

        public PostController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post, IFormFile? MediaFile)
        {
            post.Slug = Guid.NewGuid().ToString().Substring(0, 8);
            post.UserId = 1;
            post.CreatedAt = DateTime.Now;

            if (MediaFile != null)
            {
                if (MediaFile.ContentType.Contains("image")) post.Type = PostType.Image;
                else if (MediaFile.ContentType.Contains("video")) post.Type = PostType.Video;

                post.MediaUrl = "/uploads/default.jpg";
            }

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Like(int id)
        {
            // Task.Yield() ekleyerek await uyarısını gideriyoruz
            await Task.Yield();
            return Json(new { success = true });
        }
    }
}