using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public class Supplier:IEntity
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
