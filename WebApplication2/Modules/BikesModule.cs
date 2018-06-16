using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Modules
{
    public class BikesModule:Nancy.NancyModule
    {
        public BikesModule(CustomerModel ctx)
        {
            Get["/bikes"] = _ =>
            {

                var bikes = ctx.Bikes.ToList();
                return View["index", bikes];
            };

            Get["/bikes/new"] = _ =>
            {
                var bikes = new Bikes();
                return View["new"];
            };

            Post["/bikes/add"] = parameters =>
            {
                var bikes = this.Bind<Bikes>();
                if (bikes != null)
                {
                    if (ctx.Bikes.Count() <= 10)
                    {
                        ctx.Bikes.Add(bikes);
                        ctx.SaveChanges();
                        return Response.AsRedirect("/bikes");
                    }
                    else
                    {
                        var validationError = "Cannot save the bike";
                        ViewBag.ValidationError = validationError;
                        return View["new"];
                    }
             
                }
                return 500;
            };
        }
    }
}