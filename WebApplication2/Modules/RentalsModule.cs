using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Nancy;
using WebApplication2.Models;
using Nancy.ModelBinding;
using System.Globalization;

namespace WebApplication2.Modules
{
    public class RentalsModule : Nancy.NancyModule
    {
        public RentalsModule(CustomerModel ctx)
        {

            Get["/rentals/index"] = _ =>
            {
                var rental = ctx.Rentals.ToList();
                return View["index",rental];
            };

            Get["/add"] = _ =>
            {
                 return View["new"];
            };

            Get["/getcustomer/{id:int}"] = parameters =>
            {
                int id = parameters.id;
                var customer = ctx.Customers.Where(x => x.Id == id).FirstOrDefault();
                if (customer !=null)
                {
                    var data = JsonConvert.SerializeObject(customer);
                    var response = (Response)data;
                    response.ContentType = "application/json";
                    return response;
                }
                else
                {
                    var error = new {errorcode="999", error = "customerid could not be found" };
                    var data = JsonConvert.SerializeObject(error);
                    var response = (Response)data;
                    response.ContentType = "application/json";
                    return response;
                }
               
            };

            Get["/getbikes"] = _ =>
            {
                var bikes = ctx.Bikes.ToList();
                var data = JsonConvert.SerializeObject(bikes);
                var response = (Response)data;
                response.ContentType = "application/json";
                return response;
            };

            Post["/rentals/new"] = parameters =>
            {

                Rentals rentals = this.Bind<Rentals>();
                rentals.Createddate = DateTime.Now;
                DateTime dt1 = DateTime.ParseExact(rentals.Fromdate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                DateTime dt2 = DateTime.ParseExact(rentals.Todate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                var numberOfDays = (dt2 - dt1).TotalDays;
                if (numberOfDays > 7)
                {
                    var validationError = "Bikes can be rented for only 7 days or less";
                    ViewBag.ValidationError = validationError;
                    return View["new"];
                }
                else
                {
                    ctx.Rentals.Add(rentals);
                    ctx.SaveChanges();
                    return Response.AsRedirect("/rentals/index");
                }

            };
        }
    }
}