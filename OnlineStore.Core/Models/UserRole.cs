using System;

namespace OnlineStore.Core.Models
{
    public class UserRole : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}