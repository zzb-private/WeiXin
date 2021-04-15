using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZZB.DTO;
using ZZB.DTO.Application;
using ZZB.Tool.Authentication;

namespace ZZB.WebMVC.Core.Controllers
{
    public abstract class BaseController : Controller
    {
        public IServiceProvider ServiceProvider { get; set; }
        protected readonly object ServiceProviderLock = new object();

        protected TService LazyGetRequiredService<TService>(ref TService reference)
            => LazyGetRequiredService(typeof(TService), ref reference);

        protected TRef LazyGetRequiredService<TRef>(Type serviceType, ref TRef reference)
        {
            if (reference == null)
            {
                lock (ServiceProviderLock)
                {
                    if (reference == null)
                    {
                        reference = (TRef)ServiceProvider.GetRequiredService(serviceType);
                    }
                }
            }

            return reference;
        }
        protected Type ObjectMapperContext { get; set; }
        protected DTO.Application.IObjectMapper ObjectMapper
        {
            get
            {
                if (_objectMapper != null)
                {
                    return _objectMapper;
                }

                if (ObjectMapperContext == null)
                {
                    return LazyGetRequiredService(ref _objectMapper);
                }

                return LazyGetRequiredService(
                    typeof(IObjectMapper<>).MakeGenericType(ObjectMapperContext),
                    ref _objectMapper
                );
            }
        }
        private DTO.Application.IObjectMapper _objectMapper;


        protected ICurrentUser CurrentUser => LazyGetRequiredService(ref _currentUser);
        private ICurrentUser _currentUser;

        protected IConfiguration Configuration => LazyGetRequiredService(ref _configuration);
        private IConfiguration _configuration;

        protected async Task<IActionResult> OkAsync(bool Success, object data = null,string Mess = null) => await Task.Run(() =>Ok(new { Success, Mess, data }));
        protected async Task<IActionResult> OkAsync(ResultDto result, object data = null) => await Task.Run(() =>Ok(new { result.Success, result.Mess, data }));
        protected IActionResult Ok(bool Success, string Mess = null, object data = null) => Ok(new { Success, Mess, data });
    }
}
