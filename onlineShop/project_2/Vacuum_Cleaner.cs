using System;
using System.Collections.Generic;
using System.Text;

namespace project_2
{
    class Vacuum_Cleaner : Product
    {
        public string Power { get; set; }
        public Vacuum_Cleaner(string id_product, int count, string name, string company, int price, string date, string power)
        {
            Id_product = id_product;
            Count = count;
            Name = name;
            Company = company;
            Price_product = price;
            Date = date;
            Power = power;
        }
        public override void show()
        {
            Console.WriteLine($"{Id_product} {Count} {Name} {Company} {Price_product} {Date} {Power}");
        }

        public override string ToFile() => $"{Id_product} {Count} {Name} {Company} {Price_product} {Date} {Power}";
    }

}
