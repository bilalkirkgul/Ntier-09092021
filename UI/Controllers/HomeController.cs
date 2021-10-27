using BLL.Abstract;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models.ViewModel;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        IProductBLL productBLL;
        ICategoryBLL categoryBLL;
        ISupplierBLL supplierBLL;

        public HomeController(IProductBLL product, ICategoryBLL category, ISupplierBLL supplier)
        {
            productBLL = product;
            categoryBLL = category;
            supplierBLL = supplier;
        }


        ProductVM GetData()
        {
            var model = new ProductVM()
            {
                Products = productBLL.GetAll().ToList()
            };
            return model;
        }
        public ActionResult Index()
        {
            return View(GetData());
        }
        ProductVM GetDataAdd()//yeni product oluşturalacağı için new dedim. datadan herhangi bir veri çekmeyeceğim...
        {
            var model = new ProductVM()
            {
                Product = new Product(),
                Categories = categoryBLL.GetAll().ToList(),// ekleme esnasında bütün kategorileri listelemek ve seçmek için hepsi alındı
                Suppliers = supplierBLL.GetAll().ToList()
            };
            return model;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(GetDataAdd());
        }

        Product ConvertDataModel(ProductVM productVM)
        {
            Product product = new Product()
            {
                ProductName = productVM.Product.ProductName,
                UnitInStock = productVM.Product.UnitInStock,
                UnitPrice = productVM.Product.UnitPrice,
                SupplierID = productVM.Product.SupplierID,
                CategoryID = productVM.Product.CategoryID
            };
            return product;
        }

        [HttpPost]
        public ActionResult Add(ProductVM productVM)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var model = ConvertDataModel(productVM);
                    productBLL.Add(model);
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View(productVM);
        }

        ProductVM GetDataViewUpdate(int id)
        {
            var model = new ProductVM()
            {
                Product = productBLL.GetEntity(id),
                Categories = categoryBLL.GetAll().ToList(),
                Suppliers = supplierBLL.GetAll().ToList()
            };
            return model;
        }

        [HttpGet]
        public ActionResult Update(int? productID)
        {
            //Product product = productBLL.GetEntity(productID.Value);
            return View(GetDataViewUpdate(productID.Value));
        }
        Product GetDataUpdate(ProductVM productVM)
        {
            Product product = productBLL.GetEntity(productVM.Product.ProductID);
            product.ProductID = productVM.Product.ProductID;
            product.ProductName = productVM.Product.ProductName;
            product.UnitInStock = productVM.Product.UnitInStock;
            product.UnitPrice = productVM.Product.UnitPrice;
            product.CategoryID = productVM.Product.CategoryID;
            product.SupplierID = productVM.Product.SupplierID;
            return product;
        }

        [HttpPost]
        public ActionResult Update(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                var model = GetDataUpdate(productVM);
                productBLL.Update(model);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Güncelleme işlemi başarısız oldu";
                return View(productVM);
            }
        }

        public ActionResult Delete(int? productID)
        {
            //var model = productBLL.GetEntity(productID.Value);
           // productBLL.Delete(model);
           productBLL.DeleteByID(productID.Value);
            return RedirectToAction("Index");
        }

    }
}