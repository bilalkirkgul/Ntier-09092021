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
    class SupplierMapping:EntityTypeConfiguration<Supplier>
    {
        public SupplierMapping()
        {
            Property(a => a.SupplierID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(a => a.Products).WithRequired(a => a.Supplier).HasForeignKey(a => a.SupplierID);
        }

    }
}
