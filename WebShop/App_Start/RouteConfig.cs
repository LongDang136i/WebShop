using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "ProductDetail",
                 url: "chi-tiet/{metatitle}-{id}",
                 defaults: new { controller = "Product", action = "ProductDetail", id = UrlParameter.Optional },
                 namespaces: new[] { "WebShop.Controllers" }
             );
            routes.MapRoute(
                name: "ListProductByCategory",
                url: "san-pham/{metatitle}-{cateId}",
                defaults: new { controller = "Product", action = "ListProductByCategory", id = UrlParameter.Optional },
                namespaces: new[] { "WebShop.Controllers" }
            );
            routes.MapRoute(
                name: "AllProduct",
                url: "tat-ca-san-pham",
                defaults: new { controller = "Product", action = "AllProduct", id = UrlParameter.Optional },
                namespaces: new[] { "WebShop.Controllers" }
            );

            routes.MapRoute(
                 name: "About",
                 url: "gioi-thieu",
                 defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "WebShop.Controllers" }
             );
            routes.MapRoute(
                  name: "News",
                  url: "tin-tuc",
                  defaults: new { controller = "News", action = "Index", id = UrlParameter.Optional },
                  namespaces: new[] { "WebShop.Controllers" }
              );
            routes.MapRoute(
                  name: "Contact",
                  url: "lien-he",
                  defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
                  namespaces: new[] { "WebShop.Controllers" }
              );
            routes.MapRoute(
                  name: "Home",
                  url: "trang-chu",
                  defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                  namespaces: new[] { "WebShop.Controllers" }
              );
            routes.MapRoute(
                  name: "Login",
                  url: "dang-nhap",
                  defaults: new { controller = "Client", action = "Login", id = UrlParameter.Optional },
                  namespaces: new[] { "WebShop.Controllers" }
              );
            routes.MapRoute(
                 name: "Register",
                 url: "dang-ki",
                 defaults: new { controller = "Client", action = "Register", id = UrlParameter.Optional },
                 namespaces: new[] { "WebShop.Controllers" }
             );

            routes.MapRoute(
                 name: "Payment",
                 url: "thanh-toan",
                 defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
                 namespaces: new[] { "WebShop.Controllers" }
             );
            routes.MapRoute(
                 name: "Success",
                 url: "hoan-thanh",
                 defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
                 namespaces: new[] { "WebShop.Controllers" }
             );
            routes.MapRoute(
                  name: "Cart",
                  url: "gio-hang",
                  defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
                  namespaces: new[] { "WebShop.Controllers" }
              );
            routes.MapRoute(
                  name: "AddCart",
                  url: "them-gio-hang",
                  defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                  namespaces: new[] { "WebShop.Controllers" }
              );

            
            //routes.MapRoute(
            //    name: "ProductDetailByCategory",
            //    url: "{categorymetatitle}/chi-tiet/{metatitle}/{id}",
            //    defaults: new { controller = "Product", action = "ProductDetail", id = UrlParameter.Optional },
            //    namespaces: new[] { "WebShop.Controllers" }
            //);


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional},
                namespaces: new[] {"WebShop.Controllers"}
            );
        }
    }
}
