using System;
using System.IO;
using System.Text;

namespace Uaine.IO
{
    public class FileData
    {
        protected string dir_in = "";
        public string DirIn => dir_in;
        protected string Filename;
        public string FullFilePath => Filename;
        public string[] Lines;

        public FileData(string filename)
        {
            Filename = filename;

            //make if directory exists
            string dir_in = "";
            try
            {
                dir_in = Path.GetDirectoryName(filename);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            try
            {
                Directory.CreateDirectory(dir_in);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
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

        public void SaveAllLines()
        {
            File.WriteAllLines(Filename, Lines);
        }
    }
}