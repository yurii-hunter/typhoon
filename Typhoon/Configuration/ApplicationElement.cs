using System.Configuration;

namespace Typhoon.Configuration
{
    internal class ApplicationElement : ConfigurationElement
    {
        [ConfigurationProperty("baseUrl", IsRequired = true)]
        public string BaseUrl
        {
            get { return this["name"].ToString(); }
        }
    }
}