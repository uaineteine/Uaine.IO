using System;
using System.IO;
using System.Text;
using Uaine.IO.Checksum;

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

        public Checksum.Checksum CheckSum(int checktype)
        {
            byte[] fileData = File.ReadAllBytes(Filename);
            byte[] checksum;
            // Calculate checksum based on the chosen algorithm
            if (checktype == ChecksumType.MD5)
                    checksum =  Checksum.Checksum.CalculateMD5Checksum(fileData).HashBytes;
            else if (checktype == ChecksumType.SHA256)
                    checksum = Checksum.Checksum.CalculateSHA256Checksum(fileData).HashBytes;
            else
                    throw new ArgumentException("Invalid checksum algorithm specified");
            return new Checksum.Checksum(checksum, checktype);
        }
        public Checksum.Checksum CheckSum()
        {
            //default sha256
            return (CheckSum(ChecksumType.SHA256));
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