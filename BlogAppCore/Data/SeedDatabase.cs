using BlogAppCore.Core.IConfigurations;
using BlogAppCore.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogAppCore.Data
{
    public class SeedDatabase
    {
        public static async Task Seed(IUnitOfWork unitOfWork)
        {
            if (!((await unitOfWork.Blogs.GetAllAsync()).Any()))
            {
                var user = new AppUser()
                {
                    Email = "admin@gmail.com",
                    UserName = "Admin",
                    FullName = "Admin Admin",
                    RegisteredAt = DateTime.Now,
                };
                await unitOfWork.Users.CreateAsync(user, "123456");

                await unitOfWork.Categories.AddAsync(new Category()
                {
                    Name = "Game",
                    Description = "All about games and game development"
                });

                await unitOfWork.Blogs.AddAsync(new Blog()
                {
                    CategoryId = 1,
                    AppUserId = user.Id,
                    Content = "My first blog is awesome.",
                    Title = "My first blog",
                    PublishedAt = DateTime.Now.AddDays(-2),
                });

                await unitOfWork.Blogs.AddAsync(new Blog()
                {
                    CategoryId = 1,
                    AppUserId = user.Id,
                    Content = "My second blog is awesome.",
                    Title = "My second blog",
                    PublishedAt = DateTime.Now,
                });


                await unitOfWork.Comments.AddAsync(new Comment()
                {
                    AppUserId = user.Id,
                    BlogId = 1,
                    AddedAt = DateTime.Now,
                    Content = "Perfect"
                });

                await unitOfWork.Comments.AddAsync(new Comment()
                {
                    AppUserId = user.Id,
                    BlogId = 1,
                    AddedAt = DateTime.Now.AddDays(-2),
                    Content = "Bad"
                });

                await unitOfWork.CompleteAsync();
            }
        }
    }
}
