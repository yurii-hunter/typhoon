using System.Configuration;

namespace Typhoon.Configuration
{
    internal class WebDriverElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return this["name"].ToString(); }
        }
    }
}