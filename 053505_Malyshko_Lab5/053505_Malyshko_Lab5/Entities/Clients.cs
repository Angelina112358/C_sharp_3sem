using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _053505_Malyshko_Lab5.Collections;

namespace _053505_Malyshko_Lab5.Entities
{
    class Clients
    {
        public readonly MyCustomCollection<Tariffs> IndividualTariffs = new();
        public readonly MyCustomCollection<int> Traffics = new();
        public string Name { get; set; }
        public string Surname { get; set; }
        public Clients() { }
        public Clients(string name, string surname, MyCustomCollection<Tariffs> tariff, MyCustomCollection<int> traffics)
        {

            Name = name;
            Surname = surname;
            IndividualTariffs = tariff;
            Traffics = traffics;
        }
        public override string ToString()
        {
            string info = Surname + "\t" + Name;
            for (int i = 0; i < IndividualTariffs.Count; i++)
                info += IndividualTariffs[i] + "\t" + Traffics[i].ToString() + "\n\t";
            return info;
        }
    }
}
