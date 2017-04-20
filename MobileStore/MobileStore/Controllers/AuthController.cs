using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MobileStore.App_Start;
using MobileStore.Identity;
using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MobileStore.Controllers {
    [AllowAnonymous]
    public class AuthController : Controller {

        private readonly UserManager<IdentityUser, int> _userManager;
        private readonly SignInManager<IdentityUser, int> _signInManager;
        //private readonly RoleManager<IdentityRole, int> _roleManager;

        public AuthController(UserManager<IdentityUser, int> UserManager,
            SignInManager<IdentityUser, int> SignInManager) {
            _userManager = UserManager;
            _signInManager = SignInManager;
            //_roleManager = RoleManager;
        }

        // GET: Auth
        [HttpGet]
        public ActionResult Login(string returnUrl) {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl = null) {
            if (!ModelState.IsValid) {
                return View();
            }

            var user = _userManager.Find(model.Email, model.Password);
            if (user != null) {
                var identity = new ClaimsIdentity(
                    new[]{
                        new Claim(ClaimTypes.Email, model.Email)
                    },
                    "Applicationcookie"
                );
                _signInManager.SignIn(user, false, false);
                return Redirect(GetRedirectUrl(returnUrl));
            }
            return View();
        }

        public ActionResult Register(string returnURL = null) {
            ViewData["returnURL"] = returnURL;
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model, string returnURL = null) {
            if (ModelState.IsValid) {
                var user = new IdentityUser() { UserName = model.Email, Email = model.Email };
                var result = _userManager.Create(user, model.Password);
                if (result.Succeeded) {
                    var appUser = _userManager.Find(model.Email, model.Password);
                    _signInManager.SignIn(appUser, false, false);
                    return Redirect(GetRedirectUrl(returnURL));
                }
            }

            return View();
        }

        public string GetRedirectUrl(string returnUrl) {
            if(string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl)) {
                return "/Home/Index";
            }
            return returnUrl;
        }

        public ActionResult Logout() {
            var authmanager = Request.GetOwinContext().Authentication;
            authmanager.SignOut("ApplicationCookie");
            return Redirect(GetRedirectUrl(""));
        }

    }
}