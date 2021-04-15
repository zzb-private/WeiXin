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
using Microsoft.Extensions.DependencyInjection;//�Դ�DI���
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

        //�ڴ���Ӳ������Զ�������ʹ��
        //��������������
        //  1-˲ʱ��ÿ��ʹ��ʵ��һ��(services.AddTransient)
        //  2-������ÿ��http����ʾ��һ��(services.AddScoped)
        //  3-������ȫ��Ψһ(services.AddSingleton)
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(option=> {
                option.Filters.Add(typeof(ErrorFilterAttribute));
            })//�൱���ṩmvc����
            //RazorĬ������£�SDK �������ļ�������ʱ��ͷ���ʱ���� Razor �� 
            //���ú�����ʱ����Ჹ������ʱ���룬������ Razor �༭�ļ�ʱ������и���
            //y����ʱ���루�޸���ͼ��������������Ŀ��
                .AddRazorRuntimeCompilation()
            .AddControllersAsServices(); 
            //services.AddControllers();//ֻ�ṩ����������
                    //.AddControllersAsServices(); ;

            //services.AddRazorPages();//ʹ��razor��ͼ

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
            //֧�� policy ��֤��Ȩ�ķ���
            //services.AddAuthorization(p =>
            //{
            //    p.AddPolicy("admin", x => x.RequireClaim("Name","admin"));
            //});


            services.AddMemoryCache();//ʹ���ڴ滺��

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //����ϵͳ�ļ�·��ָ��λ��
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

        //aotufac����
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //builder.RegisterType<SystemFileInfoService>().As<ISystemFileInfoRepository>().InstancePerLifetimeScope();//��ӵ���ע��
            //builder.RegisterType<IHttpContextAccessor>().InstancePerLifetimeScope();//��ӵ���ע��
            builder.RegisterType<CurrentUser>().As<ICurrentUser>().InstancePerLifetimeScope();//��ӵ���ע��
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().InstancePerLifetimeScope();//��ӵ���ע��



            Assembly service = Assembly.Load("ZZB.BLL");
            builder.RegisterAssemblyTypes(service)
            .Where(t => t.FullName.EndsWith("Service") && !t.IsAbstract) //������service��β�������Ͳ����ǳ���ġ�
                .InstancePerLifetimeScope() //�������ڣ�ÿ������
                .AsImplementedInterfaces()
            .PropertiesAutowired(); //����ע��


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.Use(async (context, next) =>
            {
                await next.Invoke(); //��������¸��м����������
            });

            // ע����룬��ֹ��������
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            loggerFactory.AddNLog();//���NLog

            //�Ƿ񿪷�ģʽ�����������ļ���launchSettings.json����ASPNETCORE_ENVIRONMENT �ֶ�ֵ
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();//
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");//������ת�Զ���ҳ��
            }

            

            app.UseStaticFiles();//ʹ�þ�̬�ļ����ʣ�Ĭ����wwwrootĿ¼�µģ�Ҳ�����Զ���Ŀ¼
                                 //UseFileServer�Ĺ��ܽ����UseStaticFiles��UseDefaultFiles��UseDirectoryBrowser��
                                 //app.UseFileServer(new FileServerOptions()
                                 //{
                                 //    FileProvider = new PhysicalFileProvider(
                                 //    Path.Combine(Directory.GetCurrentDirectory(), @"StaticFile")),
                                 //    RequestPath = new PathString("/StaticFiles"),
                                 //    EnableDirectoryBrowsing = true
                                 //});

            app.UseCookiePolicy();//ʹ��cookie����
            app.UseRouting();//����·��

            app.UseAuthentication();//������֤
            app.UseAuthorization();//��ʼ��Ȩ




            //app.UseResponseCompression();//ѹ�� Razor Pages ��Ӧ��

            //������ӳ���ڷ���UseEndpoints,2.X�汾��ʹ��UseMvc
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});
            //����·�ɹ���
            app.UseEndpoints(endpoints =>
            {

                //�Զ�������·��
                endpoints.MapAreaControllerRoute(
                    name: "areas", "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                //Ĭ��·��
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


                //endpoints.
                //endpoints.MapRazorPages();//��Ӧservices.AddRazorPages();//ʹ��razor��ͼ
            });
        }
    }
}
