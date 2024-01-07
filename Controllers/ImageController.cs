using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication10332.DAL.Entities;

namespace WebApplication10332.Controllers
{
    public class ImageController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        IWebHostEnvironment _env;
        public ImageController(UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }
        public async Task<FileResult> GetAvatar()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.AvatarImage != null)
                return File(user.AvatarImage, "images/...");
            else
            {
                var avatarPath = "/images/anonymous.jpg";
                return File(_env.WebRootFileProvider
                .GetFileInfo(avatarPath)
                .CreateReadStream(), "images/...");
            }
        }
    }
}
