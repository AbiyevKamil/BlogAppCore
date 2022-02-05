using BlogAppCore.Core.IConfigurations;
using BlogAppCore.Data.Entities;
using BlogAppCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppCore.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index(long? id)
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            if (id == null)
            {
                var blogs = await _unitOfWork.Blogs.GetAllAsync();
                var model = new BlogsIndexViewModel()
                {
                    Blogs = blogs,
                    Categories = categories,
                };
                return View(model);
            }

            var blogsByCategory = await _unitOfWork.Blogs.GetByCategoryIdAsync((long)id);
            var modelByCategory = new BlogsIndexViewModel()
            {
                Blogs = blogsByCategory,
                Categories = categories,
            };
            return View(modelByCategory);
        }

        [HttpGet]
        public async Task<IActionResult> Blog(long? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var blog = await _unitOfWork.Blogs.GetByIdAsync((long)id);
            if (blog == null)
                return RedirectToAction("Index");
            var model = new BlogViewModel()
            {
                AppUser = blog.AppUser,
                AppUserId = blog.AppUserId,
                Category = blog.Category,
                CategoryId = blog.CategoryId,
                Comments = blog.Comments,
                Content = blog.Content,
                Id = blog.Id,
                ImagePath = string.Empty,
                PublishedAt = blog.PublishedAt,
                UpdatedAt = blog.UpdatedAt,
                Title = blog.Title,
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment(int blogId,string commentText)
        {
            var user = await _unitOfWork.Users.FindByClaimsAsync(User);
            var comment = new Comment()
            {
                BlogId = blogId,
                AppUserId = user.Id,
                AddedAt = DateTime.Now,
                Content = commentText,
            };
            await _unitOfWork.Comments.AddAsync(comment);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("Blog", new {id = blogId});
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddBlog()
        {
            return View();
        }
    }
}
