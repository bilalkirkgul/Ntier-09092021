using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models.ViewModel
{
    public class ProductPropVM
    {
        public ProductPropVM()
        {
            Categories = new HashSet<Category>().ToList();
            Suppliers = new HashSet<Supplier>().ToList();
        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public string CategoryName { get; set; }
        public int CategoryID { get; set; }
        public string CompanyName { get; set; }
        public int SupplierID { get; set; }
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
    }
}