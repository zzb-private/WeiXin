using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using IdentityServer4;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;//×Ô´øDI¿ò¼Ü
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using ZZB.BLL.IRepositories;
using ZZB.BLL.IRepositories.File;
using ZZB.BLL.Servies.File;
using ZZB.DAL;
using ZZB.Tool.IdentityServer;
using ZZB.WebMVC.Core.Config;

namespace ZZB.WebMVC.Core
{
    public class Startuptest
    {
        public Startuptest(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //services.ConfigureNonBreakingSameSiteCookies();

            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "cookies";
                options.DefaultChallengeScheme = "oidc";
            }).AddCookie("cookies")
            .AddOpenIdConnect("oidc", option =>
            {
                option.SignInScheme = "cookies";
                option.Authority = "http://localhost:8002/";
                option.RequireHttpsMetadata = false;
                option.ClientId = "mvc clint";
                option.ClientSecret = "mvc secret";

                option.UseTokenLifetime = true;

                option.SaveTokens = true;
                option.ResponseType = "code";
                option.Scope.Clear();

                option.Scope.Add("myapi");
                option.Scope.Add(IdentityServerConstants.StandardScopes.OpenId);
                option.Scope.Add(IdentityServerConstants.StandardScopes.Profile);
                option.Scope.Add(IdentityServerConstants.StandardScopes.Phone);
                option.Scope.Add(IdentityServerConstants.StandardScopes.Address);
                option.Scope.Add(IdentityServerConstants.StandardScopes.Email);
                option.Scope.Add(IdentityServerConstants.StandardScopes.OfflineAccess);


            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
