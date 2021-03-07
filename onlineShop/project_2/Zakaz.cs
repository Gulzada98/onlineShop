using System;
using System.Collections.Generic;
using System.Text;

namespace project_2
{
    class Zakaz
    {
        // Свойства класса Заказ
        public string ID_Klient { get; set; }
        public string FIO { get; set; }
        public string ID_Product { get; set; }
        public string Name_Product { get; set; }
        public int Amount { get; set; }
        public string Data { get; set; }
        public string Price { get; set; }

        // Конструктор с параметрами
        public Zakaz(string id_Klient, string fio, string id_Product, string name_Product, int amount, string data, string price)
        {
            this.ID_Klient = id_Klient;
            this.FIO = fio;
            this.ID_Product = id_Product;
            this.Name_Product = name_Product;
            this.Amount = amount;
            this.Data = data;
            this.Price = price;
        }
        // Метод для преобразования типов на тип string. Это будет нужно когда мы будем записывать конечный результат на файлы (SaveToFile)
         public string ToFile() => $"{ID_Klient} {FIO} {ID_Product} {Name_Product} {Amount} {Data} {Price}";
    }
}
