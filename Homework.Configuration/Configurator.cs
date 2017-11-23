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

        public void ConfigureSourcePath(IConfigurable receiver,string path)

        {
            IConfigurationItem configurationItem = new SourcePathConfigurationItem(receiver, path);
            receiver.Configure(configurationItem);
        }

        public void ConfigureDestinationPath(IConfigurable receiver, string path)

        {
            IConfigurationItem configurationItem = new DestinationPathConfigurationItem(receiver, path);
            receiver.Configure(configurationItem);
        }
        public void ConfigureUserName(IConfigurable receiver, string name)

        {
            IConfigurationItem configurationItem = new UserNameConfigurationItem(receiver, name);
            receiver.Configure(configurationItem);
        }

        public void ConfigureUrl(IConfigurable receiver, string url)

        {
            IConfigurationItem configurationItem = new UrlConfigurationItem(receiver, url);
            receiver.Configure(configurationItem);
        }

        public void ConfigurePassword(IConfigurable receiver, string password)

        {
            IConfigurationItem configurationItem = new PasswordConfigurationItem(receiver, password);
            receiver.Configure(configurationItem);
        }

    }
}
