using System;
using System.Collections.Generic;
using System.Text;


namespace project_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            SaveToFile saveTo = new SaveToFile();
            controller.Save += saveTo.WriteToFile;
            controller.Load_Product();

            Console.WriteLine("Если вы владелец нажмите 0 / если вы покупатель нажмите 1");
            int option = Convert.ToInt32(Console.ReadLine());
            int operation;
            int choice = 1;
            int end = 3;
            if (option == 0)
            {
                while (end != 0)
                {
                    Console.WriteLine("1 - Просмотр списка продуктов    2 - Добавить продукт    3 - Просмотр  (Приход - Расход) документа ");
                    Console.WriteLine("Выберите операцию ");
                    operation = Convert.ToInt32(Console.ReadLine());
                    if (operation == 1)
                    {
                        controller.Show_pr();
                    }
                    else if (operation == 2)
                    {
                        while (choice != 0)
                        {
                            controller.AddProduct();
                            Console.WriteLine("Хотите добавить еще продукт? Если да нажмите 1. Если нет нажмите 0 ");
                            choice = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    else if (operation == 3)
                    {
                        controller.Show_scr();
                    }
                    Console.WriteLine("Хотите выполнить еще какие-нибудь операций? Если да нажмите 1. Если нет нажмите 0 ");
                    end = Convert.ToInt32(Console.ReadLine());
                }
            }
            else if (option == 1)
            {
                while (end != 0)
                {
                    Console.WriteLine("1 - Просмотр списка продуктов    2 - Заказать товар");
                    Console.WriteLine("Выберите операцию ");
                    operation = Convert.ToInt32(Console.ReadLine());
                    if (operation == 1)
                    {
                        controller.Show_pr();
                    }
                    else if (operation == 2)
                    {
                        controller.AddZakaz();
                    }
                    Console.WriteLine("Хотите выполнить еще какие-нибудь операций? Если да нажмите 1. Если нет нажмите 0 ");
                    end = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
    }
}

