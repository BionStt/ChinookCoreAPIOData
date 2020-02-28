using System;
using System.Collections.Generic;
using ChinookCoreAPIOData.Domain.Entities;

namespace ChinookCoreAPIOData.Domain.Repositories
{
    public interface IInvoiceLineRepository : IDisposable
    {
        List<InvoiceLine> GetAll();
        InvoiceLine GetById(int id);
        List<InvoiceLine> GetByInvoiceId(int id);
        List<InvoiceLine> GetByTrackId(int id);
        InvoiceLine Add(InvoiceLine newInvoiceLine);
        bool Update(InvoiceLine invoiceLine);
        bool Delete(int id);
    }
}