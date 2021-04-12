using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using IdentityModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using IdentityServer4;
using IdentityServer4.Test;

namespace OnlineShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes() =>
            new List<ApiScope> { 
                new ApiScope("shopApi", "shop API"),
                //new ApiScope(IdentityServerConstants.StandardScopes.OpenId),
                //new ApiScope(IdentityServerConstants.StandardScopes.Profile)
            };
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("shopApi", "shop API")
                {
                    Scopes = { "shopApi" }
                }
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                    new Client
                    {
                        ClientId = "onlineshop_angular",
                        ClientName = "Online Shop Angular",
                        ClientSecrets = { new Secret("secret".Sha256()) },
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                        RedirectUris = { "http://localhost:4200/auth-callback" },
                        PostLogoutRedirectUris = {"http://localhost:4200/"},
                        AllowedCorsOrigins = {"http://localhost:4200"},
                        AllowAccessTokensViaBrowser = true,
                        AccessTokenLifetime = 3600,
                        AllowedScopes = new [] {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            IdentityServerConstants.StandardScopes.Email,
                            "shopApi",
                            "roles"
                        },
                        AllowOfflineAccess = true,
                        AccessTokenType = AccessTokenType.Jwt,

                    }
                };
        }
    }
}

