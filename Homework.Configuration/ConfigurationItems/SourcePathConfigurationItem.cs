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

    public class SourcePathConfigurationItem : ConfigurationItem

    {
        private string path;
        // Constructor

        public SourcePathConfigurationItem(IConfigurable receiver, string path) :

          base(receiver)

        {
            this.path = path;
        }

        public override int ID { get { return (int)ConfigurationEnum.SourcePath; } }

        public override string Value
        {
            get
            {
                return path;
            }
        }
    }
}
