using BLL.Abstract;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.ViewModels;

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

        List<SupplierVM> ConvertViewModel(ICollection<Supplier> suppliers)
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
        public ActionResult Index()
        {
            List<Supplier> suppliers = supplierBLL.GetAll().ToList();
            return View(ConvertViewModel(suppliers));
        }
    }
}