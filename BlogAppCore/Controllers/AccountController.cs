using BlogAppCore.Core.IConfigurations;
using BlogAppCore.Data.Entities;
using BlogAppCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace BlogAppCore.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AccountController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _unitOfWork.Users.FindByClaimsAsync(User);
            var blogs = await _unitOfWork.Blogs.GetByUserIdAsync(user.Id);
            var comments = await _unitOfWork.Comments.GetByUserIdAsync(user.Id);
            return View(new AccountViewModel()
            {
                User = user,
                Blogs = blogs,
                Comments = comments
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.Blogs.DeleteByIdAsync(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _unitOfWork.Users.FindByClaimsAsync(User);
            var blog = await _unitOfWork.Blogs.GetByIdAsync(id);
            if (blog.AppUserId != user.Id)
                return RedirectToAction("Index");
            var model = new UpdateBlogViewModel()
            {
                Id = id,
                CategoryId = blog.CategoryId,
                Content = blog.Content,
                Title = blog.Title,
            };
            ViewBag.categories = await _unitOfWork.Categories.GetAllAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogViewModel model)
        {
            if (ModelState.IsValid)
            {
                var oldBlog = await _unitOfWork.Blogs.GetByIdAsync(model.Id);
                var user = await _unitOfWork.Users.FindByClaimsAsync(User);
                var blog = new Blog();
                if (model.Banner != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string filename = Path.GetFileNameWithoutExtension(model.Banner.FileName);
                    string extension = Path.GetExtension(model.Banner.FileName);
                    string path = filename + Guid.NewGuid() + extension;
                    string filepath = Path.Combine(wwwRootPath + "/images", path);
                    var oldPath = Path.Combine(wwwRootPath + "/images", oldBlog.ImageName);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                    using (var fs = new FileStream(filepath, FileMode.Create))
                    {
                        await model.Banner.CopyToAsync(fs);
                    }
                    blog.ImageName = path;
                }
                else
                {
                    blog.ImageName = oldBlog.ImageName;
                }
                blog.Title = model.Title;
                blog.Content = model.Content;
                blog.AppUserId = user.Id;
                blog.CategoryId = model.CategoryId;
                blog.UpdatedAt = DateTime.Now;
                blog.Id = model.Id;
                await _unitOfWork.Blogs.UpdateAsync(blog);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction("Index");


            }
            ViewBag.categories = await _unitOfWork.Categories.GetAllAsync();
            return View(model);
        }
    }
}
