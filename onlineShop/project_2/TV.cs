using System;
using System.Collections.Generic;
using System.Text;

namespace project_2
{
    class TV : Product
    {
        public string Size { get; set; }
        public TV(string id_product, int count, string name, string company, int price, string date, string size)
        {
            Id_product = id_product;
            Count = count;
            Name = name;
            Company = company;
            Price_product = price;
            Date = date;
            Size = size;
        }
        public override void show()
        {
            Console.WriteLine($"{Id_product} {Count} {Name} {Company} {Price_product} {Date} {Size}");
        }
        public override string ToFile() => $"{Id_product} {Count} {Name} {Company} {Price_product} {Date} {Size}";
    }

}
