using System;
using System.Text;


namespace _053505_Malyshko_Lab5.Entities
{
    class Tariffs
    {
        public string Name { get; set; }
        public int Price { get; set; }
        readonly int Number;
        public Tariffs() { }
        public Tariffs(string name, int price, int number)
        {
            Name = name;
            Price = price;
            Number = number;
        }
        public override string ToString()
        {
            return Number.ToString() + "\t" + Name.ToString() + "\t" + Price.ToString();
        }
    }
}