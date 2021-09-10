using DAL.Abstract;
using DAL.Concrete;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete.IoC.Ninject
{
    public class BusinessModule : NinjectModule
    {

        public override void Load()
        {
            Bind<ICategoryDAL>().To<CategoryDAL>();
            Bind<IProductDAL>().To<ProductDAL>();
            Bind<ISupplierDAL>().To<SupplierDAL>();
            Bind<DbContext>().To<Bilal0909DbContext>();
        }
    }
}
