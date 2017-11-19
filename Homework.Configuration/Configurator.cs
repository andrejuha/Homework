using Homework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Configuration
{
    /// <summary>

    /// The 'Invoker' class

    /// </summary>

    public class Configurator

    {

        private IConfigurable _configurationItem;


        public void ConfigurePath(IConfigurable receiver,string path)

        {
            IConfigurationItem pathConfigurationItem = new PathConfigurationItem(receiver, path);
            receiver.Configure(pathConfigurationItem);
        }
        //public void Configure(ConfigurationItem configurationItem)

        //{
        //    this._configurationItem = configurationItem;
        //    _configurationItem.Configure();
        //}

    }
}
