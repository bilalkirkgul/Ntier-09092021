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
    class CategoryMapping:EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            Property(a => a.CategoryID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(a => a.Products).WithRequired(a=>a.Category).HasForeignKey(a => a.CategoryID);

        }
    }
}
