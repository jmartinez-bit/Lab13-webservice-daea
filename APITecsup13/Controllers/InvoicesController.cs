using APITecsup13.Context;
using APITecsup13.Models;
using APITecsup13.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APITecsup13.Controllers
{
    public class InvoicesController : ApiController
    {
        private ExampleContext db = new ExampleContext();

        [HttpPost]
        public InvoiceResponse Insert(Invoice request)
        {
            double total = 0;
            foreach (Detail detail in request.Details)
            {
                detail.Igv = detail.SubTotal * 0.18;
                detail.Total = detail.SubTotal - detail.Igv;
                total += detail.Total;
            }
            request.Total = (int) total;
            request.CreatedOn = DateTime.Now;
            db.Invoices.Add(request);
            db.SaveChanges();
            var response = new InvoiceResponse
            {
                Number = request.Number,
                Total = request.Total,
                Name = db.Customers.First(c => c.CustomerID == request.CustomerID).Name
            };
            return response;
        }

        [HttpGet]
        public List<InvoiceResponseV2> GetByPrice(int MinPrice, int MaxPrice)
        {
            var invoices = db.Invoices.
                Where(x => x.Total > MinPrice && x.Total < MaxPrice)
                .ToList();

            var response = (from c in invoices
                            select new InvoiceResponseV2
                            {
                                Number = c.Number,
                                Total = c.Total
                            }).ToList();
            return response;
        }
    }
}
