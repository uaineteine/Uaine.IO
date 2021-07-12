using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Uaine.IO
{
    public class SettingsClass : SettingsFile
    {
        public SettingsClass(string filename) : base(filename)
        {
        }

        public List<SettingValue> values = new List<SettingValue>();

        public void Add(string name, object value)
        {
            Add(new SettingValue(name, value));
        }
        public void Add(SettingValue value)
        {
            values.Add(value);
        }

        public object GetByName(string n)
        {
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i].Name==n)
                {
                    return values[i].Value;
                }
            }
            return null;
        }

        public void UpdateByName(string n, object value)
        {
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i].Name == n)
                {
                    values[i].NewDefaultAndSet(value);
                }
            }
        }

        public bool SaveFile()
        {
            try
            {
                using (FileStream fs = new FileStream(Filename, FileMode.Create))
                {
                    using (StreamWriter bw = new StreamWriter(fs))
                    {
                        for (int i = 0; i < values.Count; i++)
                        {
                            bw.WriteLine(values[i].Value);
                        }
                        //EOF
                        bw.Close();
                    }
                    fs.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool LoadFile()
        {
            try
            {
                if (File.Exists(Filename))
                {
                    using (FileStream fs = new FileStream(Filename, FileMode.Open))
                    {
                        using (StreamReader br = new StreamReader(fs))
                        {
                            for (int i = 0; i < values.Count; i++)
                            {
                                try
                                {
                                    values[i].ParseFromString(br.ReadLine());
                                }
                                catch
                                {
                                    values[i] = new SettingValue(values[i].Name, values[i].def);
                                }
                            }
                            //EOF
                            br.Close();
                        }
                        fs.Close();
                    }
                }
                else
                {
                    SaveFile();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
