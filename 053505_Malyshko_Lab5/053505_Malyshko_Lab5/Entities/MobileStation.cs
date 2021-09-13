using System;
using _053505_Malyshko_Lab5.Collections;

namespace _053505_Malyshko_Lab5.Entities
{

    class MobileStation
    {
        static private MyCustomCollection<Tariffs> Tariffs = new();
        static private MyCustomCollection<Clients> Clients = new();
        static private int AddTraffic()
        {
            int traffic;
            string input;
            do
            {
                Console.WriteLine("Введите трафик (Гб): ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out traffic));
            return traffic;
        }
        static private void AddTarrifsAndTraffic(Clients client)
        {
            int n;
            string input;
            string choice = "1";
            for (int j = 0; ; j++)
            {
                if (Equals(choice, "1"))
                {
                    do
                    {
                        Console.WriteLine("Тарифы: ");
                        Tariffs.PrintItems();
                        Console.WriteLine("Выберите тариф: ");
                        input = Console.ReadLine();
                    } while (!(int.TryParse(input, out n)) || (n <= 0 || n > Tariffs.Count));

                    for (int i = 0; i < Tariffs.Count; i++)
                    {
                        if (n == i + 1)
                        {
                            client.IndividualTariffs.Add(Tariffs[i]);
                            client.Traffics.Add(AddTraffic());
                        }
                    }
                }
                else
                    break;
                Console.WriteLine("Добавить еще тариф? 1-Да 2-Нет");
                choice = Console.ReadLine();
            }
        }
        static private int GeneralTraffic(Clients client)
        {
            int generalTraffic = 0;
            for (int j = 0; j < client.IndividualTariffs.Count; j++)
                generalTraffic += client.IndividualTariffs[j].Price * client.Traffics[j];
            return generalTraffic;
        }
        public void AddTariff()
        {
            Console.Clear();
            Console.WriteLine("Введите название тарифа: ");
            string Name = Console.ReadLine();
            int Price;
            string input;
            do
            {
                Console.WriteLine("Введите цену (BYN/1Гб): ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out Price));
            Tariffs tariff = new(Name, Price, Tariffs.Count + 1);
            Tariffs.Add(tariff);
        }
        public void AddClients()
        {
            Clients client = new();
            Console.WriteLine("Введите имя: ");
            string name = Console.ReadLine();

            Console.WriteLine("Введите фамилию: ");
            string surname = Console.ReadLine();

            client.Name = name;
            client.Surname = surname;

            AddTarrifsAndTraffic(client);

            Clients.Add(client);
        }  
        public void Find()
        {
            Console.Clear();
            Console.WriteLine("Surname\tName\tNumber\tTariff\tPrice\tTraffic");
            Clients.PrintItems();
            Console.WriteLine("Введите фамилию: ");
            string surname = Console.ReadLine();
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Equals(Clients[i].Surname, surname))
                    AddTarrifsAndTraffic(Clients[i]);
            }
        }
        public void GeneralTraffic()
        {
            Console.WriteLine("Surname\tName\tNumber\tTariff\tPrice\tTraffic");
            Clients.PrintItems();
            Console.WriteLine("Введите фамилию: ");
            string surname = Console.ReadLine();
            for (int i = 0; i < Clients.Count; i++)
                if (Equals(Clients[i].Surname, surname))
                    Console.WriteLine(GeneralTraffic(Clients[i]));
        }
        public void MaxTraffic()
        {
            Console.Clear();
            int maxTraffic = 0;
            Clients maxClient = new();
            for (int i = 0; i < Clients.Count; i++)
            {
                if (GeneralTraffic(Clients[i]) > maxTraffic)
                {
                    maxTraffic = GeneralTraffic(Clients[i]);
                    maxClient = Clients[i];
                }
            }
            Console.WriteLine("Surname\tName\tNumber\tTariff\tPrice\tTraffic");
            Console.WriteLine(maxClient);
            Console.WriteLine("Общий трафик: " + maxTraffic);
        }
        public void PrintTariffs() 
        {
            Tariffs.PrintItems();
        }
        public void PrintClients() 
        {
            Clients.PrintItems();
        }
    }
}
