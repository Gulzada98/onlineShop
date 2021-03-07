using System;
using System.Collections.Generic;
using System.Text;

namespace project_2
{
    class Controller
    {
        // Описание делегата для отправки сообщений.
        public delegate void SaveStateHandler(ISaveToFile list, string filename);
        // Описание события использующее делегат.
        public event SaveStateHandler Save;

        private ProductList prdct;
        private ZakazList zakz;
        private ScoreList scr;
        public Controller() //++++++++++++
        {
            prdct = new ProductList();
            zakz = new ZakazList();
            scr = new ScoreList();
        }           
        public void AddProduct() //++++++++++++
        {
            prdct.Add();
            Save?.Invoke(prdct, "Products.txt");
            scr.LoadSCR();
            scr.getOne();
            Save?.Invoke(scr, "Score.txt");
        }
        public void AddZakaz() //++++++++++++
        {
            zakz.Add_ZKZ();
            scr.LoadSCR();
            scr.getOne();
            Save?.Invoke(scr, "Score.txt");
            Save?.Invoke(prdct, "Products.txt");
            Save?.Invoke(zakz, "Zakaz.txt");
            zakz.Show_Zakaz();
        } 
        public void Show_pr() //+++++++++++
        {
            Console.WriteLine("Если хотите увидеть весь список продуктов нажмите 0 / Если определенную категорию нажмите 1");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 0)
            { prdct.Show_Product(); }
            else
            {
                Console.WriteLine("Введите название товара");
                string name = Console.ReadLine();
                prdct.Search_By_Name(name);
            }
        }         
        public void Show_scr()
        {
            scr.LoadSCR();
            scr.Show_Score();
        }       
        public void Load_Product() //++++++++++++
        {
            prdct.LoadPRD();
        }        
    }
}
