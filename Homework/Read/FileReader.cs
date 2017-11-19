using Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.Interfaces;

namespace Homework
{
    public class FileReader : AbstractReader
    {

        private Dictionary<int, IConfigurationItem> ConfigurationItems;

        public FileReader()
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

    }
}
