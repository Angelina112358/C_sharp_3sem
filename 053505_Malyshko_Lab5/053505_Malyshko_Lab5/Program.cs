using System;
using _053505_Malyshko_Lab5.Entities;

namespace _053505_Malyshko_Lab5
{
    class Program
    {
        static void Main()
        {
            MobileStation mobileStation = new();

            Journal journal = new();
            mobileStation.Notify += journal.AddEvent;
            mobileStation.Notify += (string info, string name) => Console.WriteLine(info + " " + name);

            mobileStation.AddTariff("Mini", 10);
            mobileStation.AddTariff("Max", 30);
            mobileStation.AddTariff("Shake", 15);
            mobileStation.AddTariff("Play", 25);

            Console.WriteLine();
            mobileStation.AddClients("Ann", "Red", 1);
            mobileStation.AddClients("Nick", "Oran", 2);
            mobileStation.AddClients("Vlad", "Yell", 3);
            mobileStation.AddTraffic("Yell", 4);
            mobileStation.AddTraffic("Oran", 2);
            mobileStation.AddTraffic("Oran", 3);

            Console.WriteLine("Тарифы: ");
            Console.WriteLine("Номер:\tНазвание:\tСтоимость:");
            foreach (var a in mobileStation.GetTariffs())
                Console.WriteLine(a.Key + "\t" + a.Value.Name + "\t\t" + a.Value.Price);

            Console.WriteLine();
            foreach (var a in mobileStation.SortedByPrice())
                Console.WriteLine(a);

            Console.WriteLine("Surname\tName\tNumber\tTariff\tPrice\tGeneral traffic");
            foreach (var a in mobileStation.GetClients())
                Console.WriteLine(a);

            int number = 30;
            Console.Write("\nКоличество клиентов, заплатившие больше " + number + ": ");
            Console.WriteLine(mobileStation.AmountClients(number));

            Console.Write("\nКлиент с самым большим общим трафиком: ");
            foreach (var a in mobileStation.MaxTraffic())
            {
                Console.WriteLine(a.Surname + " " + a.Name + "\nКоличество его трафика: " + a.GeneralTraffic + "\n");
            }

            Console.WriteLine("Общий трафик всех клиентов: " + mobileStation.AllCost() + "\n");

            string Surname = "Oran";
            if (mobileStation.ListOfSum(Surname) != null)
            {
                Console.WriteLine("Группировка траффиков клиента: " + Surname);
                Console.WriteLine("Название:\t" + "Сумма: ");
                foreach (var a in mobileStation.ListOfSum(Surname))
                    Console.WriteLine(a.Item1 + "\t\t" + a.Item2);
            }
            else
                Console.WriteLine("Клиента с такой фамилией нет");

            Console.ReadKey();
        }
    }
}
