using Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Mapping
{
    class ProductMapping:EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            Property(a => a.ProductID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
