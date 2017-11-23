using Homework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Configuration
{
    /// <summary>

    /// The 'ConcreteCommand' class

    /// </summary>

    public class UrlConfigurationItem : ConfigurationItem

    {
        private string url;
        // Constructor

        public UrlConfigurationItem(IConfigurable receiver, string url) :

          base(receiver)

        {
            this.url = url;
        }

        public override int ID { get { return (int)ConfigurationEnum.Url; } }

        public override string Value
        {
            get
            {
                return url;
            }
        }
    }
}
