using BLL.Abstract;
using BLL.Concrete;
using BLL.Concrete.IoC.Ninject;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Helpers.Ninject
{
    public class BLLModule : NinjectModule
    {
        
        public override void Load()
        {
           Bind<ICategoryBLL>().To<CategoryBLL>();
           Bind<ISupplierBLL>().To<SupplierBLL>();
           Bind<IProductBLL>().To<ProductBLL>();
        }
    }
}