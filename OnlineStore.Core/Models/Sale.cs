using System;

namespace OnlineStore.Core.Models
{
    public class Sale : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public DateTime Date { get; set; }
    }
}