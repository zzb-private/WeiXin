using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Http;



namespace ZZB.Tool.Authentication
{
    public class CurrentUser : ICurrentUser
    {
        //没有通过认证的，User会为空
        public ClaimsPrincipal Principal => _httpContextAccessor.HttpContext?.User;


        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUser(IHttpContextAccessor httpContextAccessor) 
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public int Id => int.Parse(Principal.Claims.FirstOrDefault(p=>p.Type == "id") == null ? "0" : Principal.Claims.FirstOrDefault(p => p.Type == "id").Value);

        public bool IsLogin => Principal.Identity.IsAuthenticated;
      
        public string Name => Principal.Claims.FirstOrDefault(p => p.Type == "name")?.Value;

        public bool HasRole { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool HasClaim { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
