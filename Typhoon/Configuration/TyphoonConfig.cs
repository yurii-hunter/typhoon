using System;
using System.Configuration;

namespace Typhoon.Configuration
{
    internal class TyphoonConfig
    {
        private static readonly Lazy<TyphoonSection> MacroSpecFlowSection = new Lazy<TyphoonSection>(() =>
            LoadConfigurationFromPluginAssembly() ?? 
            LoadConfigurationFromAssemblyThatUsingThePlugin());

        private static TyphoonSection LoadConfigurationFromAssemblyThatUsingThePlugin()
        {
            return ConfigurationManager.GetSection("typhoon") as TyphoonSection;
        }

        private static TyphoonSection LoadConfigurationFromPluginAssembly()
        {
            var exeConfigPath = new Uri(typeof(TyphoonConfig).Assembly.CodeBase).LocalPath;
            var configurationSection = ConfigurationManager.OpenExeConfiguration(exeConfigPath).GetSection("typhoon");
            return configurationSection as TyphoonSection;
        }

        private static void ThrowAnErrorIfReportalPortalConfigurationSectionIsNull()
        {
            if (MacroSpecFlowSection.Value == null)
                throw new ConfigurationErrorsException("No 'typhoon' section in config file!");
        }

        public static TyphoonSection Typhoon
        {
            get
            {
                ThrowAnErrorIfReportalPortalConfigurationSectionIsNull();
                return MacroSpecFlowSection.Value;
            }
        }
    }
}
