using Web;
using Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ViewModel;
using Model;

namespace Web.Controllers
{
    public class SOPController : Controller
    {
        //
        // GET: /SOP/

        #region Constroctor
        ISOPService SOPService;
        ITestService TestService;
        public SOPController(ISOPService SOPService, ITestService TestService)
        {
            this.SOPService = SOPService;
            this.TestService = TestService;
        }
        #endregion

        #region Action Method
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.TestList = new SelectList(TestService.GetAll(), "TestID", "TestName");
            return View();
        }


        // POST: /Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(SOP sop)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.TestList = new SelectList(TestService.GetAll(), "TestID", "TestName");
                    sop.Formula = Convert.ToString(TempData["formula"]);
                    if (string.IsNullOrEmpty(sop.Formula))
                    {
                        ModelState.AddModelError("", "Please insert formula");
                        return View(sop);
                    }
                    if (SOPService.FindBy(s => s.SOPName.Trim() == sop.SOPName.Trim()).Count() > 0)
                    {
                        ModelState.AddModelError("", "SOP alreary exists with same name");
                        return View(sop);
                    }
                    
                    sop.FileName = Convert.ToString(TempData.Peek("fileName"));
                    sop.Formula = Convert.ToString(TempData["formula"]);
                    SOPService.Create(sop);
                    ViewBag.ResultMessage = "Record inserted successfully !";
                }
            }
            catch
            {
                ViewBag.ResultMessage = "Error occured";
            }

            ResetModel(sop);
            return View();
        }



        [HttpPost]
        public ActionResult ShowDialog(int testId)
        {
            ViewBag.NumberOfParametersRequired = TestService.GetById(testId).NumberOfParametersRequired;
            return PartialView("InsertFormula");
        }

        [HttpPost]
        public void Upload(HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                string directoryPath = ConfigurationManager.AppSettings["SOPFileDirectroy"].ToString();
                if (!Directory.Exists(Server.MapPath(directoryPath)))
                {
                    Directory.CreateDirectory(Server.MapPath(directoryPath));
                }

                string fileName = upload.FileName;
                string extension = System.IO.Path.GetExtension(fileName);

                fileName = fileName.Substring(0, fileName.Length - extension.Length) + "-" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + extension;
                TempData["fileName"] = fileName;
                var path = Path.Combine(Server.MapPath(directoryPath), fileName);
                upload.SaveAs(path);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formula"></param>
        [HttpPost]
        public void InsertFormula(string formula)
        {
            TempData["formula"] = formula;
        }


        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(SOPViewModel sopViewModel)
        {
            IEnumerable<SOP> lstSOP = null;
            if (!string.IsNullOrEmpty(sopViewModel.SPID))
            {
                lstSOP = SOPService.FindBy(p => p.SID  == sopViewModel.SPID);
            }
            else
            {
                sopViewModel.ToDate = new DateTime(sopViewModel.ToDate.Year, sopViewModel.ToDate.Month, sopViewModel.ToDate.Day, 23, 59, 59);
                if (sopViewModel.ToDate.Year >= 1900 && sopViewModel.FromDate.Year >= 1900)
                {
                    lstSOP = SOPService.FindBy(p => p.CreatedDate >= sopViewModel.FromDate && p.CreatedDate <= sopViewModel.ToDate);
                }
                else if (sopViewModel.ToDate.Year >= 1900 && sopViewModel.FromDate.Year <= 1900)
                {
                    lstSOP = SOPService.FindBy(p => p.CreatedDate >= DateTime.MinValue && p.CreatedDate <= sopViewModel.ToDate);
                }
                else if (sopViewModel.ToDate.Year <= 1900 && sopViewModel.FromDate.Year >= 1900)
                {
                    lstSOP = SOPService.FindBy(p => p.CreatedDate >= sopViewModel.FromDate && p.CreatedDate <= DateTime.MaxValue);
                }
                else
                {
                    lstSOP = SOPService.FindBy(p => p.CreatedDate >= DateTime.MinValue && p.CreatedDate <= DateTime.MaxValue);
                }
            }
            ViewBag.ResultMessage = sopViewModel.lstSOP.Count() == 0 ? "No Record Found" : "";
            sopViewModel.lstSOP = lstSOP;
            return View(sopViewModel);
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            SOP sop = SOPService.GetById(id);
            ViewBag.TestList = new SelectList(TestService.GetAll(), "TestID", "TestName");
            TempData["formula"] = sop.Formula;
           
            if (sop != null)
            {
                return View(sop);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult Edit(SOP sop)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sop.Formula = Convert.ToString(TempData["formula"]);
                    sop.FileName = Convert.ToString(TempData.Peek("fileName")); 
                    SOPService.Update(sop);
                    ViewBag.ResultMessage = "Record updated successfully !";
                }
            }
            catch
            {
                ViewBag.ResultMessage = "Error occured";
            }
            ViewBag.TestList = new SelectList(TestService.GetAll(), "TestID", "TestName");
            return View(sop);
        }

        public ActionResult GetSOPDetails(long id)
        {
            SOP sop = SOPService.GetById(id);
           
            return Json(sop, JsonRequestBehavior.AllowGet);
            
        }

        #endregion
      
        #region Private Method
          /// <summary>
        /// Reset Model Data
        /// </summary>
        /// <param name="product"></param>
        private void ResetModel(SOP sop)
        {
            sop.SID = string.Empty;
            sop.SOPDescription = string.Empty;
            sop.SOPHtml = string.Empty;
            sop.SOPName = string.Empty;
            sop.TestID = 0;
            sop.FileName = string.Empty;
            sop.Formula = string.Empty;
            this.ModelState.Clear();
        }

        #endregion
    }
}
