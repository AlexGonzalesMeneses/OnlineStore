using System;

namespace OnlineStore.Core.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public Guid CategoryId { get; set; }
    }
}