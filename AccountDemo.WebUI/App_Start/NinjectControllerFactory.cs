using AccountDemo.Business.Abstract;
using AccountDemo.Business.Concrete;
using AccountDemo.DataAccess.Abstract;
using AccountDemo.DataAccess.Concrete;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AccountDemo.WebUI.App_Start
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;

        public NinjectControllerFactory()
        {
            kernel = new StandardKernel(new NinjectBindingModule());
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);
        }
    }
    public class NinjectBindingModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IAdminAuthDAL>().To<AdminAuthDAL>();
            Kernel.Bind<IAdminAuthService>().To<AdminAuthMenager>();          
        }
    }
}