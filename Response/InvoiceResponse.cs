using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APITecsup13.Responses
{
    public class InvoiceResponse
    {
        public string Number { get; set; }
        public double Total { get; set; }
        public string Name { get; set; }
    }
}