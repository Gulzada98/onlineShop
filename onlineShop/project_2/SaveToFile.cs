using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace project_2
{
    class SaveToFile
    {
        public void WriteToFile(ISaveToFile saveToFile, string fileName)
        {
            using (StreamWriter file = new StreamWriter(fileName, false, Encoding.Unicode))
            {
                file.Write(saveToFile.GetString());
            }
        }
    }
}
