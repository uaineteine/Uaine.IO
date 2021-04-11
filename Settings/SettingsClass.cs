using System;
using System.Collections.Generic;
using System.Text;

namespace Uaine.IO
{
    public class SettingsClass : SettingsFile
    {
        public SettingsClass(string filename) : base(filename)
        {
        }

        List<SettingValue> values = new List<SettingValue>();

        public void Add(string name, object value)
        {
            Add(new SettingValue(name, value));
        }
        public void Add(SettingValue value)
        {
            values.Add(value);
        }
    }
}
