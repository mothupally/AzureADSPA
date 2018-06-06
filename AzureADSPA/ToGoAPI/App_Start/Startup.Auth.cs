using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.ActiveDirectory;
using System.Configuration;
using System.Security.Claims;

namespace ToGoAPI
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    Audience = "299ecf3a-7f6e-4286-a3f6-e778cded8184",
                    Tenant = ConfigurationManager.AppSettings["ida:Tenant"],
                });
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
               new WindowsAzureActiveDirectoryBearerAuthenticationOptions
               {
                   Audience = ConfigurationManager.AppSettings["ida:Audience"],
                   Tenant = ConfigurationManager.AppSettings["ida:Tenant"],
               });
        }

    }
}

