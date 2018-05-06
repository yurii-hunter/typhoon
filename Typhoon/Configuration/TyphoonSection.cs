using System.Configuration;

namespace Typhoon.Configuration
{
    internal class TyphoonSection : ConfigurationSection
    {
        [ConfigurationProperty("timeout", IsRequired = true)]
        public TimeoutElement Timeout
        {
            get { return (TimeoutElement)this["timeout"]; }
        }

        [ConfigurationProperty("webDriver", IsRequired = true)]
        public WebDriverElement WebDriver
        {
            get { return (WebDriverElement)this["webDriver"]; }
        }

        [ConfigurationProperty("application", IsRequired = true)]
        public ApplicationElement Application
        {
            get { return (ApplicationElement) this["application"]; }
        }
    }
}
