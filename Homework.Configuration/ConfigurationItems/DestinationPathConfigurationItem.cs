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

    public class DestinationPathConfigurationItem : ConfigurationItem

    {
        private string path;
        // Constructor

        public DestinationPathConfigurationItem(IConfigurable receiver, string path) :

          base(receiver)

        {
            this.path = path;
        }

        public override int ID { get { return (int)ConfigurationEnum.DestinationPath; } }

        public override string Value
        {
            get
            {
                return path;
            }
        }
    }
}
