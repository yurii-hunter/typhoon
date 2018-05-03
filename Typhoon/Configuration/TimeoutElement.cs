using System.Configuration;

namespace Typhoon.Configuration
{
    internal class TimeoutElement : ConfigurationElement
    {
        [ConfigurationProperty("explicitWait", IsRequired = true)]
        public int Explicit
        {
            get { return int.Parse(this["explicitWait"].ToString()); }
        }

        [ConfigurationProperty("implicitWait", IsRequired = true)]
        public int Implicit
        {
            get { return int.Parse(this["implicitWait"].ToString()); }
        }

        [ConfigurationProperty("existsWait", IsRequired = true)]
        public int Exists
        {
            get { return int.Parse(this["existsWait"].ToString()); }
        }
    }
}