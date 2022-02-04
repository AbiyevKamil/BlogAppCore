using BlogAppCore.Core.IConfigurations;
using BlogAppCore.Models;
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
    }
}
