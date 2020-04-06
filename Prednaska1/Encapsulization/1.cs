using System.Collections.Generic;
using System.Linq;

namespace Encapsulization
{
    // Narušení zapouzdření - členy lze libovolně modifikovat. Invarianty nejsou 
    // vynuceny
    public class Invoice
    {
        public int InvoiceId { get; set; } // Accessor a mutator volně k dispozici
        public string InvoiceNumber { get; set; } // Accessor a mutator volně k dispozici
        public List<InvoiceItem> Items { get; set; } = new List<InvoiceItem>(); // Umožňuje nastavit celý list zvenku. Naprosté porušení zapouzdření.
    }

    /// <summary>
    /// Funkce vytažená mimo objekt. Validuje stav objektu, který díky tomu musí být velmi otevřený.
    /// Není např. žádný přístup k privátním členům faktury
    /// </summary>
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

    /// <summary>
    /// Funke / mutátor vytažená mimo objekt. Mění stav, vytváří objekt z věnjšku.
    /// Je schopen manipulovat zájmovým objektem i mimo jeho invarianty.
    /// Funkcionalita je těžko k nalezení a musí respektovat jiné mutátory.
    /// </summary>
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