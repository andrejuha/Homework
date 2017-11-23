 using System;
using System.Collections.Generic;
using Homework.Interfaces;

namespace Homework
{
    public  class ConfigureBase : ConfigureAbstract, IConfigurable
    {

        private Dictionary<int, IConfigurationItem> ConfigurationItems;

        public ConfigureBase()
        {
            ConfigurationItems = new Dictionary<int, IConfigurationItem>();
        }


        public override void Configure(IConfigurationItem parameter)
        {
            if (ConfigurationItems.ContainsKey(parameter.ID))

                ConfigurationItems[parameter.ID] = parameter;

            else

                ConfigurationItems.Add(parameter.ID, parameter);
        }

        public override IConfigurationItem GetParam(int parameterName)
        {
            if (ConfigurationItems.ContainsKey(parameterName))
                return ConfigurationItems[parameterName];
            throw new Exception("Configuration parameter name: " + parameterName + " not configured");
        }
    }
}
