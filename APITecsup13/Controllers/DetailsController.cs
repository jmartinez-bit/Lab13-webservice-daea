using APITecsup13.Context;
using APITecsup13.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APITecsup13.Controllers
{
    public class DetailsController : ApiController
    {
        private ExampleContext db = new ExampleContext();

        [HttpGet]
        public List<DetailResponse> GetByNumber(string Number)
        {
            var InvoiceID = db.Invoices.
                First(x => x.Number == Number).InvoiceID;
            var Details = db.Details.Where(d => d.InvoiceID == InvoiceID);

            var response = (from d in Details
                            select new DetailResponse
                            {
                                Quantity = d.Count,
                                Price = d.Price,
                                SubTotal = d.SubTotal,
                                Igv = d.Igv,
                                Total = d.Total
                            }).ToList();
            return response;
        }
    }
}
