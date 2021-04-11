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

        public SettingValue(string name, Type t, object val) : base(name)
        {
            type = t;
            Value = val;
        }

        public SettingValue(string name, object val):base(name)
        {
            Value = val;
            type = val.GetType();
        }
    }
}
