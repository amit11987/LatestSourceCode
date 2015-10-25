using Web;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Web.ViewModel;
using Model;
namespace Web.Controllers
{
    public class TestController : Controller
    {

        //
        // GET: /Test/
        ITestService TestService;
        IFieldTypeService FieldTypeService;
        ITestParameterService TestParameterService;
        public TestController(ITestService TestService, IFieldTypeService FieldTypeService, ITestParameterService TestParameterService)
        {
            this.TestService = TestService;
            this.FieldTypeService = FieldTypeService;
            this.TestParameterService = TestParameterService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.NumberOfParametersRequired = Convert.ToInt32(ConfigurationManager.AppSettings["DefaultSelectedNoOfTestParameter"]);
            fillDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Test test)
        {
            ViewBag.NumberOfParametersRequired = Convert.ToInt32(ConfigurationManager.AppSettings["DefaultSelectedNoOfTestParameter"]);
            fillDropdown();
            try
            {
                if (ModelState.IsValid)
                {
                    List<string> errorMessage = new List<string>();
                    if (TestService.FindBy(p => p.TestName.Trim() == test.TestName.Trim()).Count() > 0)
                    {
                        errorMessage.Add("Test alreary exists with same name");
                    }
                    if (TestService.FindBy(p => p.TID.Trim() == test.TID.Trim()).Count() > 0)
                    {
                        errorMessage.Add("Test alreary exists with same test ID");
                    }
                    if (errorMessage.Count > 0)
                    {
                        return Json(new { errorMessage });
                    }
                    else
                    {
                        TestService.Create(test);
                    }
                }
                return View();
            }
            catch
            {
                return View(test);
            }
           
        }

        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(TestViewModel testViewModel)
        {
            IEnumerable<Test> lstProduct = null;
            if (!string.IsNullOrEmpty(testViewModel.TID))
            {
                lstProduct = TestService.FindBy(p => p.TID == testViewModel.TID);
            }
            else
            {
                testViewModel.ToDate = new DateTime(testViewModel.ToDate.Year, testViewModel.ToDate.Month, testViewModel.ToDate.Day, 23, 59, 59);
                if (testViewModel.ToDate.Year >= 1900 && testViewModel.FromDate.Year >= 1900)
                {
                    lstProduct = TestService.FindBy(p => p.CreatedDate >= testViewModel.FromDate && p.CreatedDate <= testViewModel.ToDate);
                }
                else if (testViewModel.ToDate.Year >= 1900 && testViewModel.FromDate.Year <= 1900)
                {
                    lstProduct = TestService.FindBy(p => p.CreatedDate >= DateTime.MinValue && p.CreatedDate <= testViewModel.ToDate);
                }
                else if (testViewModel.ToDate.Year <= 1900 && testViewModel.FromDate.Year >= 1900)
                {
                    lstProduct = TestService.FindBy(p => p.CreatedDate >= testViewModel.FromDate && p.CreatedDate <= DateTime.MaxValue);
                }
                else
                {
                    lstProduct = TestService.FindBy(p => p.CreatedDate >= DateTime.MinValue && p.CreatedDate <= DateTime.MaxValue);
                }
            }
            testViewModel.lstTest = lstProduct;
            ViewBag.ResultMessage = lstProduct.Count() == 0 ? "No Record Found" : "";
            return View(testViewModel);
        }


        [HttpGet]
        public ActionResult Edit(long id)
        {
            Test test = TestService.GetById(id);
            ViewBag.NumberOfParametersRequired = test.TestParameters == null ? 0 : test.TestParameters.Count;
            fillDropdown();
            if (test != null)
            {
                return View(test);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(Test test)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //TestService.InsertORUpdateORDelete(test);
                    TestService.Update(test);
                    List<TestParameter> lstTestParameter = TestService.GetById(test.TestID).TestParameters;
                    List<TestParameter> deletedTestParameters = lstTestParameter.Where(y => !test.TestParameters.Any(z => z.TestParameterID == y.TestParameterID)).ToList();
                    foreach (var item in deletedTestParameters)
                    {
                        TestParameterService.Delete(item);  
                    }
                    for (int i = 0; i < test.TestParameters.Count; i++)
                    {
                        if (test.TestParameters[i].TestParameterID == 0)
                        {
                            TestParameterService.Create(test.TestParameters[i]);
                        }
                        else if (test.TestParameters[i].TestParameterID > 0)
                        {
                            TestParameterService.Update(test.TestParameters[i]);
                        }
                    }
                    ViewBag.ResultMessage = "Record updated successfully !";
                }
            }
            catch
            {
                ViewBag.ResultMessage = "Error occured";
            }
            ViewBag.NumberOfParametersRequired = test.TestParameters == null ? 0 : test.TestParameters.Count;
            fillDropdown();
            return View(test);
        }

        [HttpGet]
        public ActionResult Renderview(int? id)
        {
            ViewBag.NumberOfParametersRequired = id.HasValue ? id.Value : Convert.ToInt32(ConfigurationManager.AppSettings["DefaultSelectedNoOfTestParameter"]);
            fillDropdown();
            return PartialView("~/Views/PartialView/testParameter.cshtml");
        }

        [HttpPost]
        public ActionResult EditRenderview(int? noOfTestParameter, long testID)
        {
            Test test = TestService.GetById(testID);
            ViewBag.NumberOfParametersRequired = noOfTestParameter.HasValue ? noOfTestParameter.Value : Convert.ToInt32(ConfigurationManager.AppSettings["DefaultSelectedNoOfTestParameter"]);
            if (test != null && test.TestParameters != null && noOfTestParameter.Value > test.TestParameters.Count)
            {
                int addNoofTestParameter =  noOfTestParameter.Value - test.TestParameters.Count;
                for (int i = 0; i < addNoofTestParameter; i++)
                {
                    test.TestParameters.Add(new TestParameter());
                }
            }
            fillDropdown();
            return PartialView("~/Views/PartialView/testParameter.cshtml", test);
        }

        [HttpGet]
        public JsonResult GetById(long? testID)
        {
            long id = testID.HasValue ? testID.Value : 0;
            Test test = TestService.GetById(id);
            return Json(test, JsonRequestBehavior.AllowGet);
        }
            

        private void fillDropdown()
        {
            ViewBag.MaxNoOfTestParameter = Convert.ToInt32(ConfigurationManager.AppSettings["MaxNoOfTestParameter"]);
            ViewBag.FieldTypes = new SelectList(FieldTypeService.GetAllByIsActive(true), "FieldTypeID", "FieldTypeName");
        }
    }
}
