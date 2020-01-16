using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVManagement.API.IdentityServer
{
    public class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        public static IEnumerable<ApiResource> Apis =>
        new List<ApiResource>
        {
            new ApiResource("api.cvmanagement", "My API")
        };
        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "ro.client",
                    ClientName = "Resource Owner Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },  
                    AllowedScopes = { "api.cvmanagement" }
                },
                new Client
                {
                    ClientId = "cvmanagement_swagger",
                    ClientName = "Swagger Client",

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,

                    RedirectUris =           { "https://localhost:5001/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { "https://localhost:5001/swagger/oauth2-redirect.html" },
                    AllowedCorsOrigins =     { "https://localhost:5001" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api.cvmanagement"
                    }
                },
                new Client
                {
                    ClientName = "angular_code_client",
                    ClientId = "angular_code_client",
                    AccessTokenType = AccessTokenType.Reference,
                    RequireConsent = false,

                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,

                    AllowAccessTokensViaBrowser = true,
                    RedirectUris = new List<string>
                    {
                        "http://localhost:4200",
                        "http://localhost:4200/authentication/login-callback",
                        "http://localhost:4200/silent-renew.html"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "http://localhost:4200/unauthorized",
                        "http://localhost:4200/authentication/logout-callback",
                        "http://localhost:4200"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:4200"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api.cvmanagement"
                    }
                }
            };
    }
}
