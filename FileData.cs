using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uaine.IO
{
    public class FileData
    {
        protected string Filename;
        public string[] Lines;

        public FileData(string filename)
        {
            Filename = filename;
        }

        public void LoadAllLines()
        {
            Lines = File.ReadAllLines(Filename);
        }

        public string Text()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in Lines)
            {
                sb.Append(s);
                sb.Append("/n");
            }
            return sb.ToString();
        }
    }
}