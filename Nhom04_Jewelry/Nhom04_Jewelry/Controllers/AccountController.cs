using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom04_Jewelry.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Nhom04_Jewelry.Models;
using Nhom04_Jewelry.ViewModel;
using System.Web.Helpers;



namespace Nhom04_Jewelry.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(DangKyVM dangKy)
        {
            if (ModelState.IsValid)
            {
                
                var appDbContext = new AppDbContext();
                var userStore = new AppUserStore(appDbContext);
                var userManager = new AppUserManager(userStore);
                var passHash = Crypto.HashPassword(dangKy.Password);
                var user = new AppUser()
                {
                    UserName = dangKy.Username,
                    HoTen=dangKy.Hoten,
                    PasswordHash = passHash,
                    Email = dangKy.Email,
                    GioiTinh = dangKy.GioiTinh,
                    NgaySinh = dangKy.NgaySinh,
                    DiaChi = dangKy.DiaChi
                };
                var Ckuser = userManager.FindByName(dangKy.Username);
                if (Ckuser!=null)
                {
                    ModelState.AddModelError("NEW ERROR", "Tài khoản tồn tại");
                    return View();
                }
                IdentityResult identityResult = userManager.Create(user);
                if (identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("NEW ERROR", "Tài khoản tồn tại");
                return View();
            }

        }

        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(DangNhapVM dangNhapVM)
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.Find(dangNhapVM.Username, dangNhapVM.Password);
            if (user != null)
            {
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("myError", "Mật khẩu không đúng!");
                return View();
            }
        }
        public ActionResult DangXuat()
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Profile()
        {
            var appDbContext = new AppDbContext();
            var userStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(userStore);
            AppUser appUser = userManager.FindById(User.Identity.GetUserId());
            return View(appUser);
        }
    }
}