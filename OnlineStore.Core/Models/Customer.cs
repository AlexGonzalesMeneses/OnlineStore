using System;

namespace OnlineStore.Core.Models
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Nit { get; set; }
        public Guid UserId { get; set; }
    }
}