﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes =  {"CatalogFullPermissionn","CatalogReadPermissionn"} },
            new ApiResource("ResourceDiscount"){Scopes = {"DiscountFullPermission"} },
            new ApiResource("ResourceOrder"){Scopes = {"OrderFullPermission"}},
            new ApiResource("ResourceCargo"){Scopes = {"CargoFullPermission"}},
            new ApiResource("ResourceBasket"){Scopes = {"BasketFullPermission"}},
            new ApiResource("ResourceComment"){Scopes = {"CommentFullPermission"}},
            new ApiResource("ResourcePayments"){Scopes = {"PaymentsFullPermission"}},
            new ApiResource("ResourceImages"){Scopes = {"ImagesFullPermission"}},
            new ApiResource("ResourceMessage"){Scopes = {"MessageFullPermission"}},
            new ApiResource("ResourceOcelot"){Scopes = {"OcelotFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermissionn","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermissionn" , "Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission" , "Full authority for discount operations"),
            new ApiScope("OrderFullPermission" , "Full authority for order operations"),
            new ApiScope("CargoFullPermission" , "Full authority for cargo operations"),
            new ApiScope("BasketFullPermission" , "Full authority for basket operations"),
            new ApiScope("CommentFullPermission" , "Full authority for comment operations"),
            new ApiScope("PaymentsFullPermission" , "Full authority for payment operations"),
            new ApiScope("ImagesFullPermission" , "Full authority for images operations"),
            new ApiScope("MessageFullPermission" , "Full authority for message operations"),
            new ApiScope("OcelotFullPermission" , "Full authority for ocelot operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {

            //Visitor
            new Client
            {
                ClientId="MultiShopVisitorId",
                ClientName="Multi Shop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multishopsecret".Sha256()) },
                AllowedScopes = {"CatalogReadPermissionn", "CatalogFullPermissionn" , "OcelotFullPermission", "CommentFullPermission", "ImagesFullPermission", IdentityServerConstants.LocalApi.ScopeName }
            },

            //Manager
            new Client
            {
                ClientId="MultiShopManagerId",
                ClientName ="Multi Shop Manager User",
                AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = { "CatalogReadPermissionn" , "CatalogFullPermissionn", "OcelotFullPermission", "CommentFullPermission", "ImagesFullPermission" , "CargoFullPermission",
                    "PaymentsFullPermission", "BasketFullPermission", "DiscountFullPermission","ImagesFullPermission","PaymentsFullPermission","OrderFullPermission","MessageFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName, IdentityServerConstants.StandardScopes.Email , IdentityServerConstants.StandardScopes.OpenId ,IdentityServerConstants.StandardScopes.Profile}
            },

            //Admin
            new Client
            {
                ClientId="MultiShopAdminId",
                ClientName = "Multi Shop Admin User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = { "CatalogReadPermissionn" , "CatalogFullPermissionn" , "DiscountFullPermission" , "OrderFullPermission" , "CargoFullPermission","BasketFullPermission","OcelotFullPermission", "CommentFullPermission","PaymentsFullPermission","ImagesFullPermission","MessageFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName, IdentityServerConstants.StandardScopes.Email , IdentityServerConstants.StandardScopes.OpenId ,IdentityServerConstants.StandardScopes.Profile  },
                AccessTokenLifetime = 600
            }
        };

    }
}