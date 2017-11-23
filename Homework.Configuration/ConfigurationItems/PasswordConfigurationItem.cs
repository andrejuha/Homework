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

    public class PasswordConfigurationItem : ConfigurationItem

    {
        private string password;
        // Constructor

        public PasswordConfigurationItem(IConfigurable receiver, string password) :

          base(receiver)

        {
            this.password = password;
        }

        public override int ID { get { return (int)ConfigurationEnum.Password; } }

        public override string Value
        {
            get
            {
                return password;
            }
        }
    }
}
