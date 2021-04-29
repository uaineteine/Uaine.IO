using System;
using Uaine.Objects.Primitives.Values;

namespace Uaine.IO
{
    public class SettingValue : OValue
    {
        protected string _name;
        public string Name { get => _name; }
        public SettingValue(string name, Type t, object val) : base(t, val)
        {
            _name = name;
        }

        public SettingValue(string name, object val) : base(val)
        {
            _name = name;
        }

        internal void ParseFromString(string s)
        {
            try
            {
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
                else
                    Value = _def;
            }
            catch
            {
                Value = _def;
            }
        }
    }
}
