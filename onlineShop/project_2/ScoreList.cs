using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace project_2
{
    class ScoreList : ISaveToFile
    {
        private List<Score> scr = new List<Score>(); // конечный счет 
        private List<Score> scr_Res_1 = new List<Score>(); // лист создан для получения данных из класса ProductList
        private List<Score> scr_Res_2 = new List<Score>(); // лист создан для получения данных из класса ProductList
        public void LoadSCR()
        {
            StreamReader sr = new StreamReader("Score.txt");
            int count = System.IO.File.ReadAllLines("Score.txt").Length; // длина файла Score
            string[] str = new string[count]; // string массив str

            for (int i = 0; i < count; i++)
            {
                str[i] = sr.ReadLine(); // считываем файл и записываем в массив str
            }

            string[] d = new string[count]; // string массив

            for (int i = 0; i < count; i++)
            {
                d = str[i].Split(' '); // символы до пробела записываем в d
                int prihod = Convert.ToInt32(d[2]); // создаем int переменную. d[2] - типа string, а третий элемент класса scr должен быть типа int
                int raskhod = Convert.ToInt32(d[3]); 
                scr.Add(new Score(d[0], d[1], prihod, raskhod)); // добавляем в лист scr данные из массива
            }
            sr.Close(); // закрываем файл Score.txt
        }
        public void getOne()
        {
            ProductList.send_scrRes(scr_Res_1); // из класса ProductList переносим в этот класс данные и записываем в новый класс scr_Res_1
            ZakazList.send_scrRes(scr_Res_2); // из класса ZakazList переносим в этот класс данные и записываем в новый класс scr_Res_2

            // Дальше scr_Res_1 и scr_Res_2 записываем в лист scr. С класса ProductList мы принимаем данные о расходе,
            // а с класса ZakazList принимаем данные о приходе

            foreach (Score s in scr_Res_1) 
            {
                scr.Add(s); 
            }
            foreach (Score s in scr_Res_2)
            {
                scr.Add(s);
            }
        }
        public StringBuilder GetString()
        {            
            StringBuilder builder = new StringBuilder();
            foreach (Score elem in scr)
            {
                builder.Append(elem.Tofile());
                builder.Append("\r\n");
            }
            return builder;
        }
        public void Show_Score()
        {
            // Вывод List <Score> scr (счет - данные о приходе и расходе) на экран
            for (int i = 0; i < scr.Count; i++)
            {
                //                     дата       название товара     приход                расход
                Console.WriteLine($"{scr[i].Data}  {scr[i].Name}   {scr[i].Prihod}   {scr[i].Raskhod}");
            }
        }
    }
}
