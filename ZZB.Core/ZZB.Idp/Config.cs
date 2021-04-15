// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace ZZB.Idp
{
    public class Config
    {
        private readonly IConfiguration _configuration;

        private string ClientId => _configuration.GetSection("Clients:ClientId").Value;
        private string ClientSecrets => _configuration.GetSection("Clients:ClientSecrets").Value;
        private string Url => _configuration.GetSection("Clients:Url").Value;
        
        public Config(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResources.Email(),
                new IdentityResources.Phone(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("myapi","我的api服务"),
            };

        public IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "myapi" }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = ClientId,//"mvc clint",
                    ClientSecrets = { new Secret(ClientSecrets/*"mvc secret"*/.Sha256()) },

                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,

                    //RequireConsent=true,//如果不需要显示否同意授权 页面 这里就设置为false

                    RedirectUris = { $"{Url}/signin-oidc" },
                    FrontChannelLogoutUri = $"{Url}/signout-oidc" ,
                    PostLogoutRedirectUris = { $"{Url}/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,//把scopes的权限claim带回来，false的话不会带，比如Name的Claim
    
                    //AccessTokenLifetime = 60,//60s，默认是一小时

                    AllowedScopes = {
                        "myapi",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OfflineAccess
                    },
                },
            };
    }
}