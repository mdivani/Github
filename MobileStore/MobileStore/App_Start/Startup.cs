using System;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using MobileStore.Identity;
using MobileStore.Domain.Repositories;
using Microsoft.AspNet.Identity;
using System.Web.Services.Description;
using Microsoft.Extensions.DependencyInjection;

[assembly: OwinStartup(typeof(MobileStore.Startup))]

namespace MobileStore {
    public class Startup {

        public void Configuration(IAppBuilder app) {
            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Auth/Login")
            });
        }
    }
}
