using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models.ViewModel
{
    public class ProductVM
    {
        public ProductVM()
        {
            Products = new List<Product>().ToList();
            Suppliers = new List<Supplier>().ToList();
            Categories = new List<Category>().ToList();
        }


        public Product Product { get; set; }
        public List<Product> Products { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Category> Categories { get; set; }
    }
}