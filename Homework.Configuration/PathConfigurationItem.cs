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

    public class PathConfigurationItem : ConfigurationItem

    {
        private string path;
        // Constructor

        public PathConfigurationItem(IConfigurable receiver, string path) :

          base(receiver)

        {
            this.path = path;
        }

        public override int ID { get { return (int)ConfigurtionEnum.Path; } }


    }
}
