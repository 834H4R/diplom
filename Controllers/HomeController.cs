using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using App.Domain;
using Microsoft.AspNetCore.Identity;
using App.Service;
using System.Security.Claims;
using App.Areas.Admin.Models.ViewModels;

namespace App.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
      private readonly UserManager<AppUser> userManager;
      public HomeController(UserManager<AppUser> userMgr)
        {
            userManager = userMgr;
        }

        private AppUser CurrentUser;

        public async Task<IActionResult> Index()
        {
          CurrentUser = await userManager.GetUserAsync(User);

          if (userManager.IsInRoleAsync(CurrentUser,"Admin").Result)
          {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
          }
          
          DoctorProfileViewModel CurrentModelData = new DoctorProfileViewModel
          {
            FullName = CurrentUser.UserName,
            Email = CurrentUser.Email,
            PhoneNumber = CurrentUser.PhoneNumber,
            ImagePath = CurrentUser.ImgPath,
            Speciality = CurrentUser.Speciality
          };
          return View(CurrentModelData);
            
        }
    }
}
