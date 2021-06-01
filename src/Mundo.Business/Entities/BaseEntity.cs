using System;

namespace Mundo.Business.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            _Insert = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime _Insert { get; set; }
    }
}
