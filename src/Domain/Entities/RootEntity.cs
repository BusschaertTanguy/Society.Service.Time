using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public abstract class RootEntity : Entity
    {
        private readonly List<object> _events = new();

        protected RootEntity() : base()
        {
        }
        
        protected RootEntity(Guid id) : base(id)
        {
        }

        public IEnumerable<object> DomainEvents => _events.AsReadOnly();

        protected void Publish(object domainEvent)
        {
            _events.Add(domainEvent);
        }

        public void ClearEvents()
        {
            _events.Clear();
        }
    }
}