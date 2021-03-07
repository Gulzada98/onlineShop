using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace project_2
{
    class ProductList : ISaveToFile
    {
        // создаем List<Product> prdct, в него запишем данные о складе. Поле статическое так как после заполнения нам нужно передать данные листа в класс Заказ для других операций
        static private List<Product> prdct = new List<Product>(); 
        static private List<Score> scr_1 = new List<Score>(); // создаем лист scr_1, в него запишем некоторые данные которые потом передадим в класс Score
        public void Add() // метод для добавления продукта на склад
        {
            Console.WriteLine("продукт какого типа хотите добавить?");
            Console.WriteLine(" 1 - TV   2 - Vacuum_Cleaner");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите сегодняшнюю дату");
            string DATE = Console.ReadLine();

            Console.WriteLine("Введите id товара которого хотите добавить");
            string ID = Console.ReadLine();
            int amount = 0;
            int j = 0;

            for (int i = 0; i < prdct.Count; i++)
            {
                if (prdct[i].Id_product == ID)
                {
                    j = i; // j нужен для фиксации индекса
                }
            }
            if (prdct[j].Id_product == ID)
            {
                Console.WriteLine("данный товар уже имеется на складе");
                Console.WriteLine("Введите кол-во приобретенного товара");
                amount = Convert.ToInt32(Console.ReadLine());
                prdct[j].Count += amount; // если товар с введенным айди уже имеется на складе мы увеличиваем только количество приобретаемого товара
                scr_1.Add(new Score(DATE, prdct[j].Name, 0, prdct[j].Price_product * amount));
                // На ранее упомянутый класс scr_1 добавляем данные о дате, названий товара и о расходе
                // этот лист каждый раз при добавлений товаров на склад расширяется, в результате мы получим все данные о расходе
            }
            else
            {
                // Если после поиска в листе Product введенный айди не найден нужно ввести информацию о дополнений в этот же лист
                Console.WriteLine("такого товара нет!");

                Console.WriteLine("введите айди нового товара ");
                string id_product = Console.ReadLine();
                Console.WriteLine("введите название нового товара ");
                string name = Console.ReadLine();
                Console.WriteLine("его фирму");
                string company = Console.ReadLine();
                Console.WriteLine("его цену");
                int price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("введите кол-во товара");
                amount = Convert.ToInt32(Console.ReadLine());

                if (a == 1)
                {
                    Console.WriteLine("и размер диагонали");
                    string size = Console.ReadLine();
                    prdct.Add(new TV(id_product, amount, name, company, price, DATE, size));
                    scr_1.Add(new Score(DATE, name, 0, price * amount));
                }
                else if (a == 2)
                {
                    Console.WriteLine("и мощность");
                    string power = Console.ReadLine();
                    prdct.Add(new TV(id_product, amount, name, company, price, DATE, power));
                    scr_1.Add(new Score(DATE, name, 0, price * amount));
                }
            }
        }
        public void Search_By_Name(string name)
        {
              List<Product> tmp = new List<Product>(); // временный лист (мини лист) tmp нужен для упрощения просмотра товаров
            foreach  (Product s in prdct)
            {
                if(name==s.Name) // если пользователю или админу нужно просмотреть товары на складе, и в случае если известен только название товара
                { // сравнивает названия в листе с введенным названием и собирает мини список из только нужных данных
                    tmp.Add(s);
                }
            }
            Console.WriteLine(tmp.Count);
            for (int i = 0; i < tmp.Count; i++) // вывод мини списка на экран
            {
                Console.WriteLine($"{tmp[i].Id_product}  {tmp[i].Count}   {tmp[i].Name}  {tmp[i].Company}   {tmp[i].Price_product}  {tmp[i].Date}");               
            }
        }                         
        //----------------------загрузка данных с базы в лист---------------------------------
        public void LoadPRD() // загрузка данных склада
        {
            prdct.Clear();
            StreamReader sr = new StreamReader("Products.txt");
            int count = System.IO.File.ReadAllLines("Products.txt").Length;
            string[] str = new string[count];

            for (int i = 0; i < count; i++)
            {
                str[i] = sr.ReadLine();
            }

            string[] d = new string[count];

            for (int i = 0; i < count; i++)
            {
                d = str[i].Split(' ');
                int Count = Convert.ToInt32(d[1]);
                int price = Convert.ToInt32(d[4]);

                if (d[2] == "TV")
                    prdct.Add(new TV(d[0], Count, d[2], d[3], price, d[5], d[6]));
                else if (d[2] == "Vacuum_Cleaner")
                    prdct.Add(new Vacuum_Cleaner(d[0], Count, d[2], d[3], price, d[5], d[6]));
            }
            sr.Close();
        }
        public StringBuilder GetString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Product elem in prdct)
            {
                builder.Append(elem.ToFile());
                builder.Append("\r\n");
            }
            return builder;
        }
        public void Show_Product()
        {
            Console.WriteLine(prdct.Count);
            for (int i = 0; i < prdct.Count; i++)
            {
                //Console.WriteLine($"{prdct[i].Id_product}  {prdct[i].Count}   {prdct[i].Name}  {prdct[i].Company}   {prdct[i].Price_product}  {prdct[i].Date}");
                prdct[i].show();
            }
        }
        static public List<Product> send_prdct(List<Product> prd_send) // метод для передачи листа Product в другой класс
        {
            foreach (Product s in prdct)
            {
                prd_send.Add(s);
            }
            return prd_send;
        }
        static public List<Score> send_scrRes(List<Score> scr_res) // Собранный лист scr_1 при добавлений товаров на склад
        { // отправляется в класс Score, где будет анализирован и собран в конечный счет лист
            foreach (Score s in scr_1)
            {
                scr_res.Add(s);
            }
            return scr_res;
        }
    }
}
