using System;
using _053505_Malyshko_Lab5.Collections;
using _053505_Malyshko_Lab5.Entities;

namespace _053505_Malyshko_Lab5
{
    class Program
    {
       
        static void Main()
        {
            while (true)
            {
                int a;
                string input;
                MobileStation mobileStation = new();
                do
                {
                    Console.Write("1. Добавить тариф\n" +
                                      "2. Вывести тарифы\n" +
                                      "3. Добавить клиента\n" +
                                      "4. Вывести клиентов\n" +
                                      "5. Добавить тариф и трафик клиенту\n" +
                                      "6. Посчитать общий трафик\n" +
                                      "7. Клиент, заплативший наибольшую стоимость\n");
                    input = Console.ReadLine();
                } while (!(int.TryParse(input, out a))||(a<=0||a>7));
                Console.Clear();
                switch (a)
                {
                    case 1:
                        mobileStation.AddTariff();
                        break;
                    case 2:
                        mobileStation.PrintTariffs();
                        break;
                    case 3:
                        mobileStation.AddClients();
                        break;
                    case 4:
                        Console.WriteLine("Surname\tName\tNumber\tTariff\tPrice\tTraffic");
                        mobileStation.PrintClients();
                        break;
                    case 5:
                        mobileStation.Find();
                        break;
                    case 6:
                        mobileStation.GeneralTraffic();
                        break;
                    case 7:
                        mobileStation.MaxTraffic();
                        break;
                }
            }
        }
    }
}
