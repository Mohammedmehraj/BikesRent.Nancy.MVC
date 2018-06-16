using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Rentals
    {
        public int Id { get; set; }
        public string Fromdate { get; set; }
        public string Todate { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phoneno { get; set; }
        public string Bike { get; set; }
        public DateTime Createddate { get; set; }
    }
}