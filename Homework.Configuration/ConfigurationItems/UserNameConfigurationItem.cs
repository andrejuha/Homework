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

    public class UserNameConfigurationItem : ConfigurationItem

    {
        private string userName;
        // Constructor

        public UserNameConfigurationItem(IConfigurable receiver, string userName) :

          base(receiver)

        {
            this.userName = userName;
        }

        public override int ID { get { return (int)ConfigurationEnum.UserName; } }

        public override string Value { get { return userName; } }
    }
}
