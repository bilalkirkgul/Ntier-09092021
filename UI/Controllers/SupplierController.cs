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
    public class SupplierController : Controller
    {
        // GET: Supplier

        ISupplierBLL supplierBLL;
        public SupplierController(ISupplierBLL supplier)
        {
            supplierBLL = supplier;
        }

        //Database'den gelen verileri List tipinde ViewModel Nesnesine dönüştürmek için bu methodu oluşturdum.
        List<SupplierVM> ConvertListViewModel(ICollection<Supplier> suppliers)
        {
            List<SupplierVM> supplierVMs = new List<SupplierVM>();
            foreach (var item in suppliers)
            {
                supplierVMs.Add(new SupplierVM
                {
                    SupplierID = item.SupplierID,
                    CompanyName = item.CompanyName,
                    ContactName = item.ContactName
                });
            }
            return supplierVMs;
        }


        //Kullanıcının giriş yapmış olduğu veriler SupplierViewModel nesnesinde yakalanmaktadır. Bu nesne içerisinde yakaladığpım verieleri databasede yer alan supplier nesnesine çeviridim.. 
        Supplier ConvertModel(SupplierVM supplierVM)
        {
            Supplier supplier = new Supplier()
            {
                SupplierID = supplierVM.SupplierID,
                CompanyName = supplierVM.CompanyName,
                ContactName = supplierVM.ContactName

            };
            return supplier;
        }

        //Tekil olarak databaseden yakalamış olduğum veriyi ViewModel tipinde kullanıcıya aktaracağım veri nesne türüne çevirdim..
        SupplierVM ConvertView(Supplier model)
        {
            SupplierVM supplier = new SupplierVM()
            {
                SupplierID = model.SupplierID,
                CompanyName = model.CompanyName,
                ContactName = model.ContactName
            };
            return supplier;
        }


        public ActionResult Index()
        {
            List<Supplier> suppliers = supplierBLL.GetAll().ToList();
            return View(ConvertListViewModel(suppliers));
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(SupplierVM supplierVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    supplierBLL.Add(ConvertModel(supplierVM));
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Tedarikçi kayıt işlemi gerçekleşmedi";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(supplierVM);
            }
            return View(supplierVM);


        }

        [HttpGet]
        public ActionResult Update(int? supplierVmId)
        {
            Supplier supplier;
            if (supplierVmId.HasValue)
            {
                supplier = supplierBLL.GetEntity(supplierVmId.Value);
                return View(ConvertView(supplier));
            }
            else
            {
                return RedirectToAction("Index", "Supplier");
            }

        }

        Supplier UpdateSupplierModel(SupplierVM supplierVM)
        {
            Supplier supplier = supplierBLL.GetEntity(supplierVM.SupplierID);
            supplier.SupplierID = supplierVM.SupplierID;
            supplier.CompanyName = supplierVM.CompanyName;
            supplier.ContactName = supplierVM.ContactName;
            return supplier;

        }

        [HttpPost]
        public ActionResult Update(SupplierVM supplierVM)
        {
            //Supplier supplier=null;
            Supplier updateSupplier = supplierBLL.GetEntity(supplierVM.SupplierID);
            try
            {
      
                updateSupplier.SupplierID = supplierVM.SupplierID;
                updateSupplier.CompanyName = supplierVM.CompanyName;
                updateSupplier.ContactName = supplierVM.ContactName;

                #region 2. Yöntem
                //supplier = UpdateSupplierModel(supplierVM);
                //supplierBLL.Update(supplier);          
                #endregion

                supplierBLL.Update(updateSupplier);
                return RedirectToAction("Index", "Supplier");

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

            }
            return View(supplierVM);
        }

        public ActionResult Delete(int supplierVmId)
        {
            supplierBLL.DeleteByID(supplierVmId);
            return RedirectToAction("Index", "Supplier");
        }
    }
}