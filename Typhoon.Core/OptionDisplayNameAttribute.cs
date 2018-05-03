using System;

namespace Test.App.Core
{
    public class OptionDisplayNameAttribute : Attribute, IDescription
    {
        public OptionDisplayNameAttribute(string name)
        {
            Value = name;
        }

        public string Value { get; set; }
    }
}
