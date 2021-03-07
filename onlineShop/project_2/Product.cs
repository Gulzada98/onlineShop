using System;
using System.Collections.Generic;
using System.Text;

namespace project_2
{
    abstract class Product
    {    
        public string Id_product { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public int Price_product { get; set; }
        public string Date { get; set; }
        public abstract void show();
        public abstract string ToFile();
    }
}











