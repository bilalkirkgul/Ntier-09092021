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
    public class ProductController : Controller
    {
        IProductBLL productBLL;
        ICategoryBLL categoryBLL;
        ISupplierBLL supplierBLL;
        public ProductController(IProductBLL product, ICategoryBLL category, ISupplierBLL supplier)
        {
            productBLL = product;
            categoryBLL = category;
            supplierBLL = supplier;
        }

        List<ProductPropVM> ConvertProductViewModel(ICollection<Product> products)
        {
            List<ProductPropVM> productPropVMs = new List<ProductPropVM>();
            foreach (Product item in products)
            {
                productPropVMs.Add(new ProductPropVM
                {
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    UnitInStock = item.UnitInStock,
                    UnitPrice = item.UnitPrice,
                    CategoryID = item.CategoryID,
                    SupplierID = item.SupplierID,
                    CategoryName = item.Category.CategoryName,
                    CompanyName = item.Supplier.CompanyName

                });
            }
            return productPropVMs;
        }

        // GET: Product
        public ActionResult Index()
        {
            List<ProductPropVM> model = ConvertProductViewModel(productBLL.GetAll().ToList());
            return View(model);
        }

        ProductPropVM GetDataAdd()
        {
            var model = new ProductPropVM()
            {
                Product = new Product(),
                Categories = categoryBLL.GetAll().ToList(),
                Suppliers = supplierBLL.GetAll().ToList()
            };
            return model;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(GetDataAdd());
        }

        Product AddModelProduct(ProductPropVM productProp)
        {
            Product product = new Product()
            {
                ProductID = productProp.ProductID,
                ProductName = productProp.ProductName,
                UnitPrice = productProp.UnitPrice,
                UnitInStock = productProp.UnitInStock,
                CategoryID = productProp.Product.CategoryID,
                SupplierID = productProp.SupplierID
            };
            return product;
        }

        [HttpPost]
        public ActionResult Add(ProductPropVM productProp)
        {

            if (ModelState.IsValid)
            {
                var model = AddModelProduct(productProp);
                productBLL.Add(model);
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.Message = "Ürün ekleme işlemi başarısız oldu";
                return View(productProp);
            }

        }

        ProductPropVM GetDataUpdateViewModel(Product product)
        {
            //categories ve suppliers boş
            ProductPropVM propVM = new ProductPropVM()
            {
              ProductID=product.ProductID,
              ProductName=product.ProductName,
              UnitInStock=product.UnitInStock,
              UnitPrice=product.UnitPrice,
              CategoryID=product.CategoryID,
              SupplierID=product.SupplierID
              //CategoryName=product.Category.CategoryName,
              //CompanyName=product.Supplier.CompanyName

            };
            return propVM;
        }

        ProductPropVM ViewModelDoldur()
        {
            ProductPropVM model = new ProductPropVM()
            {
                Product = new Product(),
                Categories = categoryBLL.GetAll().ToList(),
                Suppliers = supplierBLL.GetAll().ToList()
            };
           return model;
        }

        [HttpGet]
        public ActionResult Update(int? productID)
        {
            if (productID.HasValue)
            {
                ProductPropVM propVM = ViewModelDoldur();
                Product product = productBLL.GetEntity(productID.Value);
                var model = GetDataUpdateViewModel(product);
                model.Categories.AddRange(propVM.Categories);
                foreach (var item in propVM.Suppliers)
                {
                    model.Suppliers.Add(item);
                }

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Product");
            }
        }

        Product ConvertDataModel(ProductPropVM propVM)
        {
            Product product = productBLL.GetEntity(propVM.ProductID);
            product.ProductID = propVM.ProductID;
            product.ProductName = propVM.ProductName;
            product.UnitInStock = propVM.UnitInStock;
            product.UnitPrice = propVM.UnitPrice;
            product.CategoryID = propVM.Product.CategoryID;
            product.SupplierID = propVM.SupplierID;          
            return product;
        }

        [HttpPost]
        public ActionResult Update(ProductPropVM propVM)
        {
            Product model = null;
            if (ModelState.IsValid)
            {
                model = ConvertDataModel(propVM);
                productBLL.Update(model);
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.Message = "Güncelleme işlemi başarısız oldu";
                return View(propVM);
            }
         
        }

        public ActionResult Delete(int? productID)
        {
            if (productID.HasValue)
            {
                productBLL.DeleteByID(productID.Value);
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return RedirectToAction("Index", "Product");
            }
        }

    }
}