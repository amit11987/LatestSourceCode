using Web;
using Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ViewModel;
using Model;

namespace Web.Controllers
{
    public class SampleReceivingController : Controller
    {
        //
        // GET: /SampleReceiving/
        ISampleReceivingService SampleReceivingService;
        IUOMService UOMService;
        IProductService ProductService;
        ITestService TestService;
        IProductReceivedService ProductReceivedService;
        ISampleTestService SampleTestService;
        public SampleReceivingController(ISampleReceivingService SampleReceivingService, IUOMService UOMService, IProductService ProductService, ITestService TestService, IProductReceivedService ProductReceivedService, ISampleTestService SampleTestService)
        {
            this.SampleReceivingService = SampleReceivingService;
            this.UOMService = UOMService;
            this.ProductService = ProductService;
            this.TestService = TestService;
            this.ProductReceivedService = ProductReceivedService;
            this.SampleTestService = SampleTestService;
        }

        [HttpGet]
        public ActionResult Create()
        {
          
            ViewBag.NoOfProductReceived = Convert.ToInt32(ConfigurationManager.AppSettings["NoOfProductReceived"]);
            ViewBag.NoofTestRequired = Convert.ToInt32(ConfigurationManager.AppSettings["NoofTestRequired"]);
            fillDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Create(SampleReceive sampleReceive)
        {
            ViewBag.NoOfProductReceived = Convert.ToInt32(ConfigurationManager.AppSettings["NoOfProductReceived"]);
            ViewBag.NoofTestRequired = Convert.ToInt32(ConfigurationManager.AppSettings["NoofTestRequired"]);
            fillDropdown();
            try
            {
                if (ModelState.IsValid)
                {
                    List<string> errorMessage = new List<string>();
                    if (SampleReceivingService.FindBy(p => p.SRID.Trim() == sampleReceive.SRID.Trim()).Count() > 0)
                    {
                        errorMessage.Add("Sample Receiving alreary exists with same Sample ID");
                    }
                    if (errorMessage.Count > 0)
                    {
                        return Json(new { errorMessage });
                    }
                    else
                    {
                        SampleReceivingService.Create(sampleReceive);
                    }
                }
                return View();
            }
            catch
            {
                return View(sampleReceive);
            }
        }

        [HttpGet]
        public ActionResult RenderProductReceivedView(int? id)
        {
            ViewBag.NoOfProductReceived = id.HasValue ? id.Value : Convert.ToInt32(ConfigurationManager.AppSettings["NoOfProductReceived"]);
            fillDropdown();
            return PartialView("~/Views/PartialView/ProductReceived.cshtml");
        }

        [HttpGet]
        public ActionResult RenderSampleTestView(int? id)
        {
            ViewBag.NoofTestRequired = id.HasValue ? id.Value : Convert.ToInt32(ConfigurationManager.AppSettings["NoofTestRequired"]);
            fillDropdown();
            return PartialView("~/Views/PartialView/SampleTest.cshtml");
        }

        [HttpPost]
        public ActionResult EditProductReceivedview(int? noOfProductReceived, long sampleReceiveId)
        {
            SampleReceive sampleReceive = SampleReceivingService.GetById(sampleReceiveId);
            ViewBag.NoOfProductReceived = noOfProductReceived.HasValue ? noOfProductReceived.Value : Convert.ToInt32(ConfigurationManager.AppSettings["NoOfProductReceived"]);
            if (sampleReceive != null && sampleReceive.lstProductRecieved != null && noOfProductReceived.HasValue && noOfProductReceived.Value > sampleReceive.lstProductRecieved.Count)
            {
                int addNoofTestParameter = noOfProductReceived.Value - sampleReceive.lstProductRecieved.Count;
                for (int i = 0; i < addNoofTestParameter; i++)
                {
                    sampleReceive.lstProductRecieved.Add(new ProductRecieved());
                }
            }
            fillDropdown();
            return PartialView("~/Views/PartialView/ProductReceived.cshtml", sampleReceive);
        }

        [HttpPost]
        public ActionResult EditSampleTestview(int? noOfTestParameter, long sampleReceiveId)
        {
            SampleReceive sampleReceive = SampleReceivingService.GetById(sampleReceiveId);
            ViewBag.NoofTestRequired = noOfTestParameter.HasValue ? noOfTestParameter.Value : Convert.ToInt32(ConfigurationManager.AppSettings["NoofTestRequired"]);
            if (sampleReceive != null && sampleReceive.lstSampleTest != null && noOfTestParameter.Value > sampleReceive.lstSampleTest.Count)
            {
                int addNoofTestParameter = noOfTestParameter.Value - sampleReceive.lstSampleTest.Count;
                for (int i = 0; i < addNoofTestParameter; i++)
                {
                    sampleReceive.lstSampleTest.Add(new SampleTest());
                }
            }
            fillDropdown();
            return PartialView("~/Views/PartialView/SampleTest.cshtml", sampleReceive);
        }

        private void fillDropdown()
        {
            ViewBag.UOMS = new SelectList(UOMService.GetAll(), "UOMID", "UOMName");
            ViewBag.Products = new SelectList(ProductService.GetAll(), "ProductID", "ProductName");
            ViewBag.Tests = new SelectList(TestService.GetAll(), "TestID", "TestName");
        }

        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(SampleReceivingModel sampleReceivingModel)
        {
            IEnumerable<SampleReceive> lstSampleReceive = null;
            if (!string.IsNullOrEmpty(sampleReceivingModel.SRID))
            {
                lstSampleReceive = SampleReceivingService.FindBy(p => p.SRID == sampleReceivingModel.SRID);
            }
            else
            {
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
            }
            sampleReceivingModel.lstSampleReceiving = lstSampleReceive;
            ViewBag.ResultMessage = sampleReceivingModel.lstSampleReceiving.Count() == 0 ? "No Record Found" : "";
            return View(sampleReceivingModel);
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            SampleReceive SampleReceive = SampleReceivingService.GetById(id);
            ViewBag.NoOfProductReceived = SampleReceive.lstProductRecieved == null ? Convert.ToInt32(ConfigurationManager.AppSettings["NoOfProductReceived"]) : SampleReceive.lstProductRecieved.Count;
            ViewBag.NoofTestRequired =  SampleReceive.lstSampleTest == null ? Convert.ToInt32(ConfigurationManager.AppSettings["NoofTestRequired"]) : SampleReceive.lstSampleTest.Count;
            
            fillDropdown();
            if (SampleReceive != null)
            {
                return View(SampleReceive);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(SampleReceive sampleReceive)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SampleReceivingService.InsertORUpdateORDelete(sampleReceive);
                    ViewBag.ResultMessage = "Record updated successfully !";
                }
            }
            catch
            {
                ViewBag.ResultMessage = "Error occured";
            }
            ViewBag.NoOfProductReceived = sampleReceive.lstProductRecieved == null ? Convert.ToInt32(ConfigurationManager.AppSettings["NoOfProductReceived"]) : sampleReceive.lstProductRecieved.Count;
            ViewBag.NoofTestRequired = sampleReceive.lstSampleTest == null ? Convert.ToInt32(ConfigurationManager.AppSettings["NoofTestRequired"]) : sampleReceive.lstSampleTest.Count;
         
            fillDropdown();
            return View(sampleReceive);
        }

    }
}
