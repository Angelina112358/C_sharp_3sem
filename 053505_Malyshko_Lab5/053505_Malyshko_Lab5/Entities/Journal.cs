using System;
using System.Collections.Generic;
using System.Linq;

namespace _053505_Malyshko_Lab5.Entities
{
    class Journal
    {
        public class Events
        {
            public string info;
            public string name;
            public Events(string info, string name)
            {
                this.info = info;
                this.name = name;
            }
            public override string ToString()
            {
                return info + name;
            }
        }
        private readonly List<Events> CollectionEvents = new();
        public void AddEvent(string info, string name)
        {
            Events events = new(info, name);
            CollectionEvents.Add(events);
        }
    }
}
