using System;
using System.Collections.Generic;
using System.Linq;

namespace _053505_Malyshko_Lab5.Entities
{
    class Clients
    {
        public readonly Dictionary<int, Tariffs> IndividualTariffs = new();
        private int generalTraffic = 0;
        public int GeneralTraffic
        {
            get 
            {
                generalTraffic = 0;
                generalTraffic = IndividualTariffs.Sum(n => n.Value.Price);
                return generalTraffic;
            }
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Clients() { }
        public Clients(string name, string surname, Dictionary<int, Tariffs> tariff)
        {

            Name = name;
            Surname = surname;
            IndividualTariffs = tariff;
        }

        public IEnumerable<(string Name, int Sum)> GetByTariff()
        {
            return IndividualTariffs.GroupBy(t => t.Value.Name)
                .Select(g => (g.Key, g.Sum(t => t.Value.Price))).ToList();
        }

        public override string ToString()
        {
            string info = Surname + "\t" + Name;
            for (int i = 0; i < IndividualTariffs.Count; i++)
                info += IndividualTariffs[i] + "\t" + "\t" + "\n\t";
            return info + "\t\t\t\t" + GeneralTraffic;
        }
    }
}
