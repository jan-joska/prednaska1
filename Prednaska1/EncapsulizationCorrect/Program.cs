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
            
            var invoice = new Invoice("INV01", item); // Vynucení invariantu o čísle a položkce
            invoice.SetInvoiceId(1); // Vynucení invariantu o ID
            
            var item2 = new InvoiceItem();
            invoice.AddItem(item);
            
            // invoice.InvoiceNumber = "INV2"; Vyucení invariantu o neměnnosti čísla
            //invoice.Items = new List<InvoiceItem>(); Nelze vynucení invariantu o poslední položce
            
            foreach (var i in invoice.Items)
            {
                Console.WriteLine(i);
            }
        }
    }
}
