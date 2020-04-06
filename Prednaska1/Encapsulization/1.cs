using System.Collections.Generic;
using System.Linq;

namespace Encapsulization
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public decimal UnitPrice { get; set; }
    }

    // Narušení zapouzdření - členy lze libovolně modifikovat. Invarianty nejsou 
    // vynuceny
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>();
    }

    public class InvoiceValidator
    {
        public static IEnumerable<string> Validate(Invoice invoice)
        {
            if (invoice.InvoiceNumber == null)
            {
                yield return "Číslo faktury není vyplněno";
            }

            if (!invoice.Items.Any())
            {
                yield return "Faktura musí mít alespoň jednu položku.";
            }
        }
    }

    public class InvoiceManager
    {
        public static void AddNewItem(Invoice invoice, InvoiceItem item)
        {
            invoice.Items.Add(item);
        }

        public static void RemoveItem(Invoice invoice, int id)
        {
            foreach (var item in invoice.Items)
            {
                if (item.Id != id)
                {
                    continue;
                }

                invoice.Items.Remove(item);
                return;
            }
        }

        public static Invoice Create()
        {
            return new Invoice
            {
                InvoiceId = 1,
                InvoiceNumber = "INV001"
            };
        }
    }
}