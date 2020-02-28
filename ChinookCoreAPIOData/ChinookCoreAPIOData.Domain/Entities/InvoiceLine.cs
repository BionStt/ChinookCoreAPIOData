using System.Text.Json.Serialization;
using ChinookCoreAPIOData.Domain.ApiModels;
using ChinookCoreAPIOData.Domain.Converters;

namespace ChinookCoreAPIOData.Domain.Entities
{
    public class InvoiceLine : IConvertModel<InvoiceLine, InvoiceLineApiModel>
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
        public int TrackId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public virtual Invoice Invoice { get; set; }
        [JsonIgnore]
        public virtual Track Track { get; set; }

        public InvoiceLineApiModel Convert() =>
            new InvoiceLineApiModel
            {
                InvoiceLineId = InvoiceLineId,
                InvoiceId = InvoiceId,
                TrackId = TrackId,
                UnitPrice = UnitPrice,
                Quantity = Quantity
            };
    }
}