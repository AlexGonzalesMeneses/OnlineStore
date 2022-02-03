using System;

namespace OnlineStore.Core.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}