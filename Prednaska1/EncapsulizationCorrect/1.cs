using System;
using System.Collections.Generic;
using System.Text;

namespace EncapsulizationCorrect
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class Invoice
    {
        private readonly List<InvoiceItem> _items = new List<InvoiceItem>();

        public Invoice(string invoiceNumber, InvoiceItem item)
        {
            InvoiceNumber = invoiceNumber ?? throw new ArgumentNullException(nameof(invoiceNumber));
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _items.Add(item);
            InvoiceId = 0;
        }

        public void SetInvoiceId(int newId)
        {
            if (InvoiceId == 0)
            {
                InvoiceId = newId;
            }
            else
            {
                throw new InvalidOperationException("ID faktury nelze měnit poté co bylo nastaveno");
            }
        }

        public void AddItem(InvoiceItem item)
        {
            this._items.Add(item);
        }

        public void RemoveItemById(int id)
        {
            if (_items.Count == 1)
            {
                throw new InvalidOperationException("Nezle odebrat posledni polozku faktury.");
            }
            foreach (var item in _items)
            {
                if (item.Id != id)
                {
                    continue;
                }
                _items.Remove(item);
                return;
            }
        }

        public int InvoiceId { get; private set; }

        public string InvoiceNumber { get; }

        public IReadOnlyList<InvoiceItem> Items => _items;
    }
}
