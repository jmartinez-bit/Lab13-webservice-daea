using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APITecsup13.Responses
{
    public class DetailResponse
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double SubTotal { get; set; }
        public double Igv { get; set; }
        public double Total { get; set; }
    }
}