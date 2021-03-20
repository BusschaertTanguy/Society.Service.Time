using System;
using Domain.Events;

namespace Domain.Entities
{
    public class Universe : RootEntity
    {
        private DateTime _currentTime;

        // Expose private constructor for EF not to trigger the event
        // Everytime by using the public constructor
        private Universe()
        {
        }

        public Universe(Guid id) : base(id)
        {
            _currentTime = DateTime.MinValue;
            Publish(new UniverseCreated(Id, _currentTime));
        }

        public void PassDay()
        {
            _currentTime = _currentTime.AddDays(1);
            Publish(new DayPassed(Id, _currentTime));
        }
    }
}