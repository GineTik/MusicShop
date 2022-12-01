using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Services.Utils
{
    public class FileManager
    {
        public static string ReadFile(string path)
        {
            string data = null;
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    data = sr.ReadToEnd();
                }
            }
            return data;

        }
    }
}
