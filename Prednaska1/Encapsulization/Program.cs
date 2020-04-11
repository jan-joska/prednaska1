using System;
using System.Collections.Generic;

namespace Encapsulization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void UseInvoice()
        {
            var invoice = InvoiceManager.Create();
            
            // Mutace stavu z vnějšku
            InvoiceManager.AddNewItem(invoice, new InvoiceItem());

            // Porušení pravidla o jedné položce
            invoice.Items = new List<InvoiceItem>();

            // Změna Id faktury - není povoleno, porušení invariantu.
            invoice.InvoiceId = 6;

            // Změna čísla faktury na neplatne
            invoice.InvoiceNumber = "NEPLATNE";

            // Zapomenu zavolat validaci
            //var errors = InvoiceValidator.Validate(invoice);
            
            // V tomto mistě je faktura s narušeným stavem
        }
    }
}
