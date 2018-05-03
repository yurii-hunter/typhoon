using System;

namespace Test.App.Core
{
    public class OptionNameAttribute : Attribute, IDescription
    {
        public OptionNameAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}
