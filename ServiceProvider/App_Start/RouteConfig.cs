using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ServiceProvider
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

             routes.MapRoute(
                  name: "ADDTwoNumbers",
                  url: "ADDTwoNumbers/AddTwoNumbers/{token}/{num1}/{num2}",
                  defaults: new { controller = "ADDTwoNumbers", action = "AddTwoNumbers" }
            );

            routes.MapRoute(
                 name: "ADDThreeNumbers",
                 url: "ADDThreeNumbers/AddThreeNumbers/{token}/{num1}/{num2}/{num3}",
                 defaults: new { controller = "ADDThreeNumbers", action = "AddThreeNumbers" }
            );

            routes.MapRoute(
                 name: "MulTwoNumbers",
                 url: "MulTwoNumbers/mulTwoNumbers/{token}/{num1}/{num2}",
                 defaults: new { controller = "MulTwoNumbers", action = "mulTwoNumbers" }
            );

            routes.MapRoute(
                 name: "MulThreeNumbers",
                 url: "MulThreeNumbers/mulThreeNumbers/{token}/{num1}/{num2}/{num3}",
                 defaults: new { controller = "MulThreeNumbers", action = "mulThreeNumbers" }
            );

            routes.MapRoute(
                 name: "GeneratePrimeNumbersToValue",
                 url: "GeneratePrimeNumbersToValue/generatePrimeNumbersToValue/{token}/{number1}",
                 defaults: new { controller = "GeneratePrimeNumbersToValue", action = "generatePrimeNumbersToValue" }
            );

            routes.MapRoute(
                 name: "GeneratePrimeNumbersInRange",
                 url: "GeneratePrimeNumbersInRange/generatePrimeNumberInRange/{token}/{startNumber}/{endNumber}",
                 defaults: new { controller = "GeneratePrimeNumbersInRange", action = "generatePrimeNumberInRange" }
            );

            routes.MapRoute(
                 name: "IsPrime",
                 url: "IsPrime/isPrime/{token}/{number}",
                 defaults: new { controller = "IsPrime", action = "isPrime" }
            );

            routes.MapRoute(
                 name: "Default",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
