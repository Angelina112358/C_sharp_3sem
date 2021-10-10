using System;
using System.Linq;
using System.Collections.Generic;



namespace _053505_Malyshko_Lab5.Entities
{

    class MobileStation
    {
        public delegate void Handler(string message, string name);
        public event Handler Notify;

        private readonly Dictionary<int, Tariffs> Tariffs = new();
        private readonly List<Clients> Clients = new();

        public void AddTariff(string Name, int Price)
        {
            Tariffs tariff = new(Name, Price, Tariffs.Count + 1);
            Tariffs.Add(Tariffs.Count + 1, tariff);
            Notify?.Invoke("Добавлен тариф: ", Name);
        }

        public void AddClients(string name, string surname, int number)
        {
            Clients client = new();
            client.Name = name;
            client.Surname = surname;
            client.IndividualTariffs.Add(client.IndividualTariffs.Count, Tariffs[number]);
            Clients.Add(client);
            Notify?.Invoke("Добавлен клиент: ", surname + " " + name);
        }

        public void AddTraffic(string Surname, int number)
        {
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Equals(Clients[i].Surname, Surname))
                {
                    Clients[i].IndividualTariffs.Add(Clients[i].IndividualTariffs.Count, Tariffs[number]);
                    Notify?.Invoke("Добавлен траффик по тарифу: " + Tariffs[number].Name, "Кому: " + Surname);
                }
            }
        }

        public IEnumerable<Tariffs> SortedByPrice() 
        {
            var result = from u in Tariffs.Values
                              orderby u.Price
                              select u;
            return result;
        }

        public IEnumerable<Clients> MaxTraffic()
        {
            var a = Clients.Max(t => t.GeneralTraffic);
            return from i in Clients
                   where i.GeneralTraffic == Clients.Max(t => t.GeneralTraffic)
                   select i;
        }

        public void RemoveTariff(int number)
        {
            Tariffs.Remove(number);
        }

        public void RemoveClients(string Surname)
        {
            foreach (Clients client in Clients)
                if (client.Surname == Surname)
                    Clients.Remove(client);
        }

        public List<Clients> GetClients()
        {
            return Clients;
        }

        public Dictionary<int, Tariffs> GetTariffs()
        {
            return Tariffs;
        }

        public int AmountClients(int amount)
        {
            int size = Clients.Aggregate(0, (a, p) => { return a = p.GeneralTraffic > amount ? a + 1 : a; });
            return size;
        }

        public int AllCost()
        {
            int Sum = Clients.Sum(n => n.GeneralTraffic);
            return Sum;
        }

        public IEnumerable<(string, int)> ListOfSum(string Surname)
        {
            IEnumerable<(string, int)> client = null;
            for (int i = 0; i < Clients.Count; i++)
                if (Clients[i].Surname == Surname)
                    client = Clients[i].GetByTariff();
            if (client != null)
                return client;
            else
                return null;
        }
    }
}
