using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace project_2
{
    class ZakazList : ISaveToFile // подключаем интерфейс ISaveToFile у которого имеется готовый метод GetString
    {
        private List<Zakaz> zkz = new List<Zakaz>();
        private List<Product> prd_2 = new List<Product>(); // Создаем новый лист prd_2, потом запишем сюда данные из листа Product.  
        static private List<Score> scr_2 = new List<Score>(); // создаем лист scr_2, в него запишем некоторые данные которые потом передадим в класс Score
        public void Add_ZKZ() // Метод для оформления (пользователем) заказа
        {
            ProductList.send_prdct(prd_2); // У класса ProductList используем метод send_prdct и получаем лист Product, записываем его в scr_2

            Console.WriteLine("Введите сегодняшнюю дату");
            string DATE = Console.ReadLine();
            Console.WriteLine("Введите свой ИИН");
            string ID_Klient = Console.ReadLine();
            Console.WriteLine("Введите свой ФИО");
            string FIO = Console.ReadLine();

            int choice = 1;
            int sum = 0;
            int all_sum = 0;
            while (choice != 0)
            {
                Console.WriteLine("Введите id товаpа которого хотите купить");
                string ID = Console.ReadLine();

                for (int i = 0; i < prd_2.Count; i++)
                {
                    if (prd_2[i].Id_product == ID)
                    {
                    h:
                        Console.WriteLine("Введите кол-во товара которого хотите купить");

                        int amount = Convert.ToInt32(Console.ReadLine());
                        if (amount <= prd_2[i].Count) // Если количество товара указанный пользователем меньше или равно с количеством товара на складе
                        {
                            string price = Convert.ToString(prd_2[i].Price_product);

                            zkz.Add(new Zakaz(ID_Klient, FIO, ID, prd_2[i].Name, amount, DATE, price));
                            scr_2.Add(new Score(DATE, prd_2[i].Name, prd_2[i].Price_product * amount, 0));

                            prd_2[i].Count -= amount;
                            sum = amount * prd_2[i].Price_product;
                        }
                        // Если количество товара указанный пользователем больше количества товара на складе
                        else { Console.WriteLine("к сожaлению товара меньше чем вы просите"); goto h; }
                    }
                }
                all_sum += sum; // Общий счет (сумма которую покупатель должен заплатить за все приобретенные товары)
                Console.WriteLine("Хотите добавить еще продукт? Если да нажмите 1. Если нет нажмите 0 ");
                choice = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("ваш чек!");
            Console.WriteLine($"Общая сумма: {all_sum}");
        }
        public StringBuilder GetString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Zakaz elem in zkz)
            {
                builder.Append(elem.ToFile());
                builder.Append("\r\n");
            }
            return builder;
        }

        // Собранный лист scr_2 при оформлений заказов
        // отправляется в класс Score, где будет анализирован и собран в конечный счет лист
        static public List<Score> send_scrRes(List<Score> scr_res)
        {
            foreach (Score s in scr_2)
            {
                scr_res.Add(s);
            }
            return scr_res;
        }
        public void Show_Zakaz()
        {
            for (int i = 0; i < zkz.Count; i++)
            {
                Console.WriteLine($"{zkz[i].ID_Klient}  {zkz[i].FIO}   {zkz[i].ID_Product}   {zkz[i].Name_Product} {zkz[i].Amount}  {zkz[i].Data}  {zkz[i].Price}");
            }
        }
    }
}
