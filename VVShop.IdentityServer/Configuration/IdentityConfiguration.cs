﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace VVShop.IdentityServer.Configuration;

public class IdentityConfiguration
{
    public const string Admin = "Admin";
    public const string Client = "Client";

    public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
    {
        new IdentityResources.OpenId(),
        new IdentityResources.Email(),
        new IdentityResources.Profile()
    };

    public static IEnumerable<ApiScope> ApiScopes = new List<ApiScope>
    {
        // vshop é aplicação web que vai acessar // o IdentityServer para obter o token
      
        new ApiScope("vvshop", "Shop Server"),
        new ApiScope(name: "read", "Read data."),
        new ApiScope(name: "write", "Write data."),
        new ApiScope(name: "delete", "Delete data."),
    };

    public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new Client
            {
                ClientId = "client",
                ClientSecrets = { new Secret("foqs#csharp".Sha256()) },
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { "read", "write", "profile" }
            },
            new Client
            {
                ClientId = "vvshop",
                ClientSecrets = { new Secret("foqs#csharp".Sha256()) },
                AllowedGrantTypes= GrantTypes.Code, //via codigo
                RedirectUris = { "http://localhost:7019/signin-oidc", "http://localhost:5178/signin-oidc"},//login" }
                PostLogoutRedirectUris = {"http://localhost:7019/signout-callback-oidc" },
                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email, 
                    "vvshop"
                }
            }
        };
}
