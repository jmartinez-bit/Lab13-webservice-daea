using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace APITecsup13.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Number { get; set; }
        public int Total { get; set; }

        public List<Detail> Details { get; set; }

        public int? CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}