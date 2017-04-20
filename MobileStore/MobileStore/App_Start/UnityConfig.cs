using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using MobileStore.Domain.Repositories;
using MobileStore.Identity;
using MobileStore.Repository.Repositories;
using System;
using System.Web;
using System.Web.Mvc;
using Unity.Mvc5;

namespace MobileStore.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<IdentityUser, int>, UserStore>(new TransientLifetimeManager());
            container.RegisterType<RoleStore>(new TransientLifetimeManager());

            container.RegisterType<IAuthenticationManager>(

                new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}