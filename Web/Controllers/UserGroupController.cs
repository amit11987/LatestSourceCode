using Web;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ViewModel;
using Model;
namespace Web.Controllers
{
    [Authorize]
    public class UserGroupController : Controller
    {
        //
        // GET: /UserGroup/
         IUserService userService;
         IUserGroupService userGroupService;
         public UserGroupController(IUserService userService,IUserGroupService  userGroupService)
         {
             this.userService = userService;
             this.userGroupService = userGroupService;
         }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            UserGroupViewModel objUserGroupViewModel = new UserGroupViewModel();
            objUserGroupViewModel.lstUsers = userService.GetByISActive(true).ToList();
            return View(objUserGroupViewModel);
        }


        [HttpPost]
        public ActionResult Create(UserGroupViewModel userGroupViewModel)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    List<string> errorMessage = new List<string>();
                    if (userGroupService.FindBy(p => p.UserGroupName.Trim() == userGroupViewModel.userGroup.UserGroupName.Trim()).Count() > 0)
                    {
                        errorMessage.Add("Group alreary exists with same name");
                    }
                    if (errorMessage.Count > 0)
                    {
                        return Json(new { errorMessage });
                    }
                    else
                    {
                        userGroupService.Create(userGroupViewModel.userGroup);
                    }
                }
                return View();
            }
            catch
            {
                return View(userGroupViewModel);
            }

        }

        [HttpPost]
        public JsonResult StartSearch(string term)
        {
            var result = userService.GetAll().Where(p => p.EmployeeID.Contains(term) && p.IsActive == true);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
       

        public JsonResult LoadUser()
        {
            var result = userService.GetAll().Where(p => p.IsActive == true);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
    }
}
