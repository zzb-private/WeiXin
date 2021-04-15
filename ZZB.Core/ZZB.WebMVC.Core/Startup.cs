using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using IdentityServer4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;//自带DI框架
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using ZZB.DAL;
using ZZB.Tool.Authentication;
using ZZB.Tool.IdentityServer;
using ZZB.WebMVC.Core.Filter;
using ZZB.WebMVC.Core.Tool;

namespace ZZB.WebMVC.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //在此添加参数可自定义服务绑定使用
        //有三种生命周期
        //  1-瞬时：每次使用实例一次(services.AddTransient)
        //  2-作用域：每次http请求示例一次(services.AddScoped)
        //  3-单例：全局唯一(services.AddSingleton)
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(option=> {
                option.Filters.Add(typeof(ErrorFilterAttribute));
            })//相当于提供mvc服务
            //Razor默认情况下，SDK 会启用文件的生成时间和发布时编译 Razor 。 
            //启用后，运行时编译会补充生成时编译，允许在 Razor 编辑文件时对其进行更新
            //y运行时编译（修改视图不用重新启动项目）
                .AddRazorRuntimeCompilation()
            .AddControllersAsServices(); 
            //services.AddControllers();//只提供控制器服务
                    //.AddControllersAsServices(); ;

            //services.AddRazorPages();//使用razor视图

            services.AddDbContext<ZZBDbContext>(p => p.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.ConfigureNonBreakingSameSiteCookies();

            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

            services.AddAuthentication(option=> {
                option.DefaultScheme = "cookies";
                option.DefaultChallengeScheme = "oidc";
            }).AddCookie("cookies").AddOpenIdConnect("oidc", option =>
                {
                    option.SignInScheme = "cookies";
                    option.Authority = Configuration.GetSection("IdentidyServer4:Url").Value;//"http://localhost:8002/";
                    option.RequireHttpsMetadata = false;
                    option.ClientId = Configuration.GetSection("IdentidyServer4:ClientId").Value;// "mvc clint";
                    option.ClientSecret = Configuration.GetSection("IdentidyServer4:ClientSecrets").Value;//"mvc secret";

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
            //支持 policy 认证授权的服务
            //services.AddAuthorization(p =>
            //{
            //    p.AddPolicy("admin", x => x.RequireClaim("Name","admin"));
            //});


            services.AddMemoryCache();//使用内存缓存

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //设置系统文件路径指定位置
            var path = Configuration["FilePaths:Root"];
            if (!Path.IsPathRooted(path))
            {
                path = Path.Combine(AppContext.BaseDirectory, path);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(path));
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, BaseControllerActivator>());
            //services.AddScoped<IServiceProvider>();
            

        }

        //aotufac配置
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //builder.RegisterType<SystemFileInfoService>().As<ISystemFileInfoRepository>().InstancePerLifetimeScope();//添加单个注册
            //builder.RegisterType<IHttpContextAccessor>().InstancePerLifetimeScope();//添加单个注册
            builder.RegisterType<CurrentUser>().As<ICurrentUser>().InstancePerLifetimeScope();//添加单个注册
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().InstancePerLifetimeScope();//添加单个注册



            Assembly service = Assembly.Load("ZZB.BLL");
            builder.RegisterAssemblyTypes(service)
            .Where(t => t.FullName.EndsWith("Service") && !t.IsAbstract) //类名以service结尾，且类型不能是抽象的　
                .InstancePerLifetimeScope() //生命周期，每次请求
                .AsImplementedInterfaces()
            .PropertiesAutowired(); //属性注入


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.Use(async (context, next) =>
            {
                await next.Invoke(); //请求进入下个中间件继续处理
            });

            // 注册编码，防止中文乱码
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            loggerFactory.AddNLog();//添加NLog

            //是否开发模式，根据配置文件“launchSettings.json”，ASPNETCORE_ENVIRONMENT 字段值
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();//
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");//否则跳转自定义页面
            }

            

            app.UseStaticFiles();//使用静态文件访问，默认是wwwroot目录下的，也可以自定义目录
                                 //UseFileServer的功能结合了UseStaticFiles，UseDefaultFiles和UseDirectoryBrowser。
                                 //app.UseFileServer(new FileServerOptions()
                                 //{
                                 //    FileProvider = new PhysicalFileProvider(
                                 //    Path.Combine(Directory.GetCurrentDirectory(), @"StaticFile")),
                                 //    RequestPath = new PathString("/StaticFiles"),
                                 //    EnableDirectoryBrowsing = true
                                 //});

            app.UseCookiePolicy();//使用cookie策略
            app.UseRouting();//启动路由

            app.UseAuthentication();//开启验证
            app.UseAuthorization();//开始授权




            //app.UseResponseCompression();//压缩 Razor Pages 响应。

            //控制器映射内发生UseEndpoints,2.X版本是使用UseMvc
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});
            //配置路由规则
            app.UseEndpoints(endpoints =>
            {

                //自定义区域路由
                endpoints.MapAreaControllerRoute(
                    name: "areas", "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                //默认路由
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


                //endpoints.
                //endpoints.MapRazorPages();//对应services.AddRazorPages();//使用razor视图
            });
        }
    }
}
