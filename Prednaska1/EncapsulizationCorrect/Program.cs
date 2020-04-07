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

            // Vynucení invariantu o čísle a položkce
            var invoice = new Invoice("INV01", item); 
            
            invoice.SetInvoiceId(1); // Vynucení invariantu o ID
            
            var item2 = new InvoiceItem();
            
            // Ochrana vnitřní kolekce, která je navenek IReadonlyList
            invoice.AddItem(item);

            // Vyucení invariantu o neměnnosti čísla - nelze narušit
            // invoice.InvoiceNumber = "INV2"; 

            //Nelze vynucení invariantu o poslední položce
            // invoice.Items = new List<InvoiceItem>(); 

            foreach (var i in invoice.Items)
            {
                Console.WriteLine(i);
            }
        }
    }
}
