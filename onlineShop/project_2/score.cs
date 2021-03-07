using System;
using System.Collections.Generic;
using System.Text;

namespace project_2
{
    class Score
    {
        public Score(string data, string name, int prihod, int raskhod)
        {
            this.Data = data;
            this.Name = name;
            this.Prihod = prihod;
            this.Raskhod = raskhod;
        }        
        public string Data { get; set; }
        public string Name { get; set; }
        public int Prihod { get; set; }
        public int Raskhod { get; set; }
        public string Tofile() => $"{Data} {Name} {Prihod} {Raskhod}";
    }
}
