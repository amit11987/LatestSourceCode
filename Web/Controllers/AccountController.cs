using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ViewModel;
using Service;
using System.Web.Security;
using Web.Helper;
namespace Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        IUserService UserService;
        public AccountController(IUserService UserService)
        {
            this.UserService = UserService;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            Model.User user = UserService.FindBy(p => p.LoginID == model.LoginID && p.Password == model.Password).FirstOrDefault();
            if (ModelState.IsValid && user != null)
            {
                WebUtility.CurrentUser = user;
                FormsAuthentication.SetAuthCookie(model.LoginID, model.RememberMe);
                return RedirectToAction("Create", "Product");
            }
            else
            {
                ModelState.AddModelError("", "The login id or password provided is incorrect.");
                return View(model);
            }
  
        }

        //
        // POST: /Account/LogOff
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            WebUtility.ClearAllSession();
            return RedirectToAction("Login", "Account");
        }

    }
}
