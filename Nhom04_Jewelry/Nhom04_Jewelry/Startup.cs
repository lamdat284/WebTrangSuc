using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using Nhom04_Jewelry.Identity;

[assembly: OwinStartup(typeof(Nhom04_Jewelry.Startup))]

namespace Nhom04_Jewelry
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/DangNhap")
            });
            this.CreateRolesAndUsers();
        }
        public void CreateRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppDbContext()));
            var appDbContext = new AppDbContext();
            var appUserStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(appUserStore);
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            if (userManager.FindByName("HuynhHuuDuc") == null)
            {
                var user = new AppUser();
                user.UserName = "HuynhHuuDuc";
                user.Email = "HuynhHuuDuc@gmail.com";
                string userPwd = "duc123";
                var checkUser = userManager.Create(user, userPwd);
                if (checkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }


            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
        }
    }
}
