using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Uaine.Objects.Primitives;

namespace Uaine.IO
{
    public class SettingValue : NamedObject
    {
        public Type type { get; set; }
        public object Value;
        private object _def;
        public object def { get => _def; }

        public SettingValue(string name, Type t, object val) : base(name)
        {
            type = t;
            Value = val;
            _def = val;
        }

        public SettingValue(string name, object val):base(name)
        {
            Value = val;
            type = val.GetType();
            _def = val;
        }

        internal void LoadValue(StreamReader sr)
        {
            try
            {
                string s = sr.ReadLine();
                if (type == typeof(string))
                {
                    Value = s;
                }
                if (type == typeof(int))
                {
                    Value = Convert.ToInt32(s);
                }
                else if (type == typeof(float))
                {
                    Value = Convert.ToSingle(s);
                }
                else if (type == typeof(double))
                {
                    Value = Convert.ToDouble(s);
                }
                else if (type == typeof(decimal))
                {
                    Value = Convert.ToDecimal(s);
                }
            }
            catch
            {
                Value = _def;
            }
        }
    }
}
