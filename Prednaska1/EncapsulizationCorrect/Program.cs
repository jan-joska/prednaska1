using System;
using System.Collections.Generic;

namespace EncapsulizationCorrect
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static void UseInvoice()
        {
            var item = new InvoiceItem();
            var invoice = new Invoice("INV01", item);
            invoice.SetInvoiceId(1);
            
            // invoice.InvoiceNumber = "INV2"; Nelze
            //invoice.Items = new List<InvoiceItem>(); Nelze
            
            foreach (var i in invoice.Items)
            {
                Console.WriteLine(i);
            }
        }
    }
}
