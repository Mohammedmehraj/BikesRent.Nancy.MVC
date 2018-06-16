using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Modules
{
    public class CustomerModule : NancyModule
    {
        public CustomerModule(CustomerModel ctx)
        {
            Get["/getcustomers"] = _ =>
            {

                var customers = ctx.Customers.ToList();
                return View["index", customers];
            };

            Get["/customer/new"] = _ =>
            {
                var customer = new Customer();
                return View["new", customer];
            };

            Post["/customer/new"] = parameters =>
            {
                var customer = this.Bind<Customer>();
                if (customer != null)
                {
                    ctx.Customers.Add(customer);
                    ctx.SaveChanges();
                    return Response.AsRedirect("/getcustomers");
                }
                return 500;
            };


            Get["/customer/update/{id:int}"] = parameters =>
            {
                int id = parameters.id;

                //int id = ids.Value();
                var customer = ctx.Customers.Where(x => x.Id == id).FirstOrDefault();
                if (customer != null)
                {
                    return View["update", customer];
                }
                return 404;
            };

            Post["/customer/update"] = parameters =>
            {
                Customer customer = this.Bind<Customer>();
                if (customer != null)
                {
                    ctx.SetModified(customer);
                    ctx.SaveChanges();
                    return Response.AsRedirect("/getcustomers");
                }
                return 404;
            };
        }
    }
}