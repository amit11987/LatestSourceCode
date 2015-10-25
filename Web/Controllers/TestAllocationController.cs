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
    public class TestAllocationController : Controller
    {
         //
        // GET: /Product/
        #region Constroctor
        ISampleReceivingService SampleReceivingService;
        ITestAllocationService TestAllocationService;
        IDropDownListService DropDownListService;
        IUOMService UOMService;
        IUserService UserService;
        IUserGroupService userGroupService;
        public TestAllocationController(ISampleReceivingService SampleReceivingService, ITestAllocationService TestAllocationService, IDropDownListService DropDownListService, IUOMService UOMService, IUserService UserService, IUserGroupService UserGroupService)
        {
            this.SampleReceivingService = SampleReceivingService;
            this.TestAllocationService = TestAllocationService;
            this.DropDownListService = DropDownListService;
            this.UOMService = UOMService;
            this.UserService = UserService;
            this.userGroupService = UserGroupService;
        }

        #endregion
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(List<TestAllocation> lstTestAllocations)
        {

            fillDropDownList();
            try
            {

                List<string> errorMessage = new List<string>();
                foreach (var item in lstTestAllocations)
                {
                    //if (TestAllocationService.FindBy(p => p.SRID.Trim() == item.SRID.Trim()).Count() > 0)
                    //{
                    //    errorMessage.Add("Tests already allocated to this sample");
                    //}
                    if (item.testAllocationUserGroup == null)
                    {
                        errorMessage.Add("Please allocate atleast(1) user group to test");
                    }
                    if (errorMessage.Count() != 0)
                    {
                        return Json(new { errorMessage });
                    }
                    else
                    {
                        TestAllocationService.Create(item);
                    }

                }
                return View();
            }
            catch
            {
                TestAllocationViewModel objTestAllocationViewModel = new TestAllocationViewModel();
                objTestAllocationViewModel.lstTestAllocation = lstTestAllocations;
                return PartialView("~/Views/PartialView/testAllocation.cshtml", objTestAllocationViewModel);
            }
        }

        public ActionResult RenderView(string SRID)
        {
            fillDropDownList();
            List<TestAllocation> lstTestAllocation = new List<TestAllocation>();
            SampleReceive sampleReceive = SampleReceivingService.GetBySRID(SRID);
            ViewBag.NoOfTestRequired = sampleReceive.NoOfTestRequired;
            for (int i = 0; i < sampleReceive.NoOfTestRequired; i++)
            {
                lstTestAllocation.Add(new TestAllocation() { TestName = sampleReceive.lstSampleTest[i].test.TestName, TargetDate = DateTime.Now, TestID = sampleReceive.lstSampleTest[i].test.TestID, SampleReceiveID = sampleReceive.SampleReceiveID ,SRID= sampleReceive.SRID});
            }
            TestAllocationViewModel objTestAllocationViewModel = new TestAllocationViewModel();
            objTestAllocationViewModel.lstTestAllocation = lstTestAllocation;
            return PartialView("~/Views/PartialView/testAllocation.cshtml", objTestAllocationViewModel);
        }

        private void fillDropDownList()
        {
            ViewBag.TestAllocationStatus = new SelectList(DropDownListService.GetAllByGroupNameANDIsActive("TestAllocationStatus", true), "ItemValue", "ItemName");
            ViewBag.UOMS = new SelectList(UOMService.GetAll(), "UOMID", "UOMName");
            ViewBag.Users = new SelectList(UserService.GetAll(), "UserID", "FirstName");
        }

        [HttpPost]
        public JsonResult Details(SampleReceivingModel sampleReceivingModel)
        {
            IEnumerable<SampleReceive> lstSampleReceive = null;

            sampleReceivingModel.ToDate = new DateTime(sampleReceivingModel.ToDate.Year, sampleReceivingModel.ToDate.Month, sampleReceivingModel.ToDate.Day, 23, 59, 59);
            if (sampleReceivingModel.ToDate.Year >= 1900 && sampleReceivingModel.FromDate.Year >= 1900)
            {
                lstSampleReceive = SampleReceivingService.FindBy(p => p.CreatedDate >= sampleReceivingModel.FromDate && p.CreatedDate <= sampleReceivingModel.ToDate);
            }
            else if (sampleReceivingModel.ToDate.Year >= 1900 && sampleReceivingModel.FromDate.Year <= 1900)
            {
                lstSampleReceive = SampleReceivingService.FindBy(p => p.CreatedDate >= DateTime.MinValue && p.CreatedDate <= sampleReceivingModel.ToDate);
            }
            else if (sampleReceivingModel.ToDate.Year <= 1900 && sampleReceivingModel.FromDate.Year >= 1900)
            {
                lstSampleReceive = SampleReceivingService.FindBy(p => p.CreatedDate >= sampleReceivingModel.FromDate && p.CreatedDate <= DateTime.MaxValue);
            }
            else
            {
                lstSampleReceive = SampleReceivingService.FindBy(p => p.CreatedDate >= DateTime.MinValue && p.CreatedDate <= DateTime.MaxValue);
            }
            ViewBag.ResultMessage = lstSampleReceive.Count() == 0 ? "No Record Found" : "";
            return Json(lstSampleReceive.Select(x => new
            {
                SRID = x.SRID
            }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult RenderUserGroup()
        {
            UserGroupViewModel objUserGroupViewModel = new UserGroupViewModel();
            objUserGroupViewModel.lstUserGroups = userGroupService.GetAll().ToList();
            return PartialView("~/Views/TestAllocation/UserGroup.cshtml", objUserGroupViewModel);
        }

        [HttpPost]
        public JsonResult StartSearch(string term)
        {

            if (string.IsNullOrEmpty(term))
            {
                var result = userGroupService.GetAll().Where(p => p.IsActive == true).Select(x => new { x.UserGroupID, x.UserGroupName }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = userGroupService.GetAll().Where(p => p.UserGroupName.ToLower().Contains(term.ToLower()) && p.IsActive == true).Select(x => new { x.UserGroupID, x.UserGroupName });
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            
        }
       
    }
}
