// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Idp
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResources.Phone(),
                new IdentityResources.Email(),
                new IdentityResource("Permissions","权限",new List<string>{"Permission"})
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("scope1"),
                new ApiScope("scope2"),
                new ApiScope("api1","Permission",new List<string>{"Permission"})
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "console client",
                    ClientName = "Client Credentials Client",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                    AllowedScopes = { "api1" }
                },
                new Client
                {
                    ClientId="winform client",
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    ClientSecrets={new Secret("winform secret".Sha256())},
                    AllowedScopes={"api1",IdentityServerConstants.StandardScopes.OpenId}
                },
                new Client
                {
                    ClientId="mvc client",
                    ClientName="Asp.NET Core MVC Client",
                    AllowedGrantTypes=GrantTypes.CodeAndClientCredentials,
                    ClientSecrets={new Secret("mvc secret".Sha256())},
                    RedirectUris={"http://localhost:5002/signin-oidc"},
                    FrontChannelLogoutUri="http://localhost:5002/signout-oidc",
                    PostLogoutRedirectUris={ "http://localhost:5002/signout-callback-oidc" },
                    
                    AlwaysIncludeUserClaimsInIdToken=true,
                    RequireConsent=true,//如果不需要显示否同意授权 页面 这里就设置为false
                    AllowOfflineAccess=true,
                    AccessTokenLifetime=30,
                    AllowedScopes =
                    {
                        "api1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                },
                new Client
                {
                    ClientId="hybrid client",
                    ClientName="ASP.NET Core Hybrid Client",
                    ClientSecrets={new Secret("hybrid secret".Sha256()) },

                    AllowedGrantTypes=GrantTypes.HybridAndClientCredentials,
                    RedirectUris={"http://localhost:6006/signin-oidc"},
                    PostLogoutRedirectUris={ "http://localhost:6006/signout-callback-oidc" },
                    RequireConsent=true,

                    AllowOfflineAccess=true,
                    AccessTokenLifetime=30,
                    AlwaysIncludeUserClaimsInIdToken=false,

                    AllowedScopes =
                    {
                        "api1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                        
                    }
                },
                new Client
                {
                    ClientId="ABAP client",
                    ClientName="ABAP Client",
                    ClientSecrets={new Secret("ABAP secret".Sha256()) },

                    AllowedGrantTypes=GrantTypes.CodeAndClientCredentials,
                    RedirectUris={"http://localhost:6008/signin-oidc"},
                    FrontChannelLogoutUri="http://localhost:6008/signout-oidc",
                    PostLogoutRedirectUris={ "http://localhost:6008/signout-callback-oidc" },
                    RequireConsent=true,

                    AllowOfflineAccess=true,
                    //AccessTokenLifetime=30,
                    AlwaysIncludeUserClaimsInIdToken=true,

                    AllowedScopes =
                    {
                        "api1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.Profile,
                        "Permissions"
                    }
                }
            };
    }
}