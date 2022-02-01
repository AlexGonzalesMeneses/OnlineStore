using System;

namespace OnlineStore.Core.Models
{
    public class Order : BaseEntity
    {
        public decimal Total { get; set; }
        public Guid ItemId { get; set; }
    }
}