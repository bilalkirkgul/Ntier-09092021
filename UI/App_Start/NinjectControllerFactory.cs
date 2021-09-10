using BLL.Abstract;
using BLL.Concrete;
using BLL.Concrete.IoC.Ninject;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UI.Helpers.Ninject;

namespace UI.App_Start
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernal;
        public NinjectControllerFactory()
        {
            _kernal = new StandardKernel();
            _kernal.Load<BusinessModule>();
            _kernal.Load<BLLModule>();
            //AddBindings();
        }

        private void AddBindings()
        {

            //_kernal.Bind<ICategoryBLL>().To<CategoryBLL>();
            //_kernal.Bind<ISupplierBLL>().To<SupplierBLL>();
            //_kernal.Bind<IProductBLL>().To<ProductBLL>();
            //BusinessModule businessModule = new BusinessModule();
            //_kernal.Bind<ICategoryDAL>().To<CategoryDAL>();
            //_kernal.Bind<IProductDAL>().To<ProductDAL>();
            //_kernal.Bind<ISupplierDAL>().To<SupplierDAL>();
            //_kernal.Bind<DbContext>().To<Bilal0909DbContext>();
        }


        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_kernal.Get(controllerType);
        }
    }
}