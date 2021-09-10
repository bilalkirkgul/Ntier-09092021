using Core.DataAccess.EntityFramwork;
using DAL.Abstract;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
   public class CategoryDAL:EFRepositoryBase<Category, Bilal0909DbContext>,ICategoryDAL
    {
    }
}
