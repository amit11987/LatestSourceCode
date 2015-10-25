using Web;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        #region Constroctor
        IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        #endregion

        public ActionResult Index()
        {
            return View(userService.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (userService.FindBy(p => p.EmployeeID.Trim() == user.EmployeeID.Trim()).Count() > 0)
                    {
                        ModelState.AddModelError("", "Employee alreary exists with same employee ID");
                        return View(user);
                    }
                    if (!user.UseEmployeeIDAsLoginID)
                    {
                        if (userService.FindBy(p => p.LoginID.Trim() == user.LoginID.Trim()).Count() > 0)
                        {
                            ModelState.AddModelError("", "Login ID alreary exists");
                            return View(user);
                        }
                    }
                    if (userService.FindBy(p => p.EmailID.Trim() == user.EmailID.Trim()).Count() > 0)
                    {
                        ModelState.AddModelError("", "Email alreary exists");
                        return View(user);
                    }
                    userService.Create(user);
                   
                    ViewBag.ResultMessage = "Record inserted successfully !";
                }
            }
            catch
            {
                ViewBag.ResultMessage = "Error occured";
            }
            return View();
        }

    }
}
