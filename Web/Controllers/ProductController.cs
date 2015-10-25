
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web;
using Web.ViewModel;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        #region Constroctor
        IProductService ProductService;
        public ProductController(IProductService ProductService)
        {
            this.ProductService = ProductService;
        }

        #endregion

        #region Action Method
        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (ProductService.FindBy(p => p.ProductName.Trim() == product.ProductName.Trim()).Count() > 0)
                    {
                        ModelState.AddModelError("", "Product alreary exists with same product name");
                        return View(product);
                    }
                    if (ProductService.FindBy(p => p.PID.Trim() == product.PID.Trim()).Count() > 0)
                    {
                        ModelState.AddModelError("", "Product alreary exists with same product ID");
                        return View(product);
                    }
                    ProductService.Create(product);
                    ResetModel(product);
                    ViewBag.ResultMessage = "Record inserted successfully !";
                }
            }
            catch
            {
                ViewBag.ResultMessage = "Error occured";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Details(ProductViewModel productDetails)
        {
            IEnumerable<Product> lstProduct = null;
            if (!string.IsNullOrEmpty(productDetails.PID))
            {
                lstProduct = ProductService.FindBy(p => p.PID == productDetails.PID);
            }
            else
            {
                productDetails.ToDate = new DateTime(productDetails.ToDate.Year, productDetails.ToDate.Month, productDetails.ToDate.Day, 23, 59, 59);
                if (productDetails.ToDate.Year >= 1900 && productDetails.FromDate.Year >= 1900)
                {
                    lstProduct = ProductService.FindBy(p => p.CreatedDate >= productDetails.FromDate && p.CreatedDate <= productDetails.ToDate);
                }
                else if (productDetails.ToDate.Year >= 1900 && productDetails.FromDate.Year <= 1900)
                {
                    lstProduct = ProductService.FindBy(p => p.CreatedDate >= DateTime.MinValue && p.CreatedDate <= productDetails.ToDate);
                }
                else if (productDetails.ToDate.Year <= 1900 && productDetails.FromDate.Year >= 1900)
                {
                    lstProduct = ProductService.FindBy(p => p.CreatedDate >= productDetails.FromDate && p.CreatedDate <= DateTime.MaxValue);
                }
                else
                {
                    lstProduct = ProductService.FindBy(p => p.CreatedDate >= DateTime.MinValue && p.CreatedDate <= DateTime.MaxValue);
                }
            }
            productDetails.lstProducts = lstProduct;
            ViewBag.ResultMessage = lstProduct.Count() == 0 ? "No Record Found" : "";
            return View(productDetails);
        }


        [HttpGet]
        public ActionResult Edit(long id)
        {
            var product = new Product();
            product = ProductService.GetById(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductService.Update(product);
                    ViewBag.ResultMessage = "Record updated successfully !";
                }
            }
            catch
            {
                ViewBag.ResultMessage = "Error occured";
            }
            return View(product);
        }
        #endregion

        #region Private Method
        private void ResetModel(Product product)
        {
            product.ProductName = string.Empty;
            product.PID = string.Empty;
            product.ProductDescription = string.Empty;
            this.ModelState.Clear();
        }
        #endregion

    }
}
