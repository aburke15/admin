using System;

namespace Admin.Data.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}