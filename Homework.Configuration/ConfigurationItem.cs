using Homework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Configuration
{

    /// <summary>

    /// The 'ConfigurationItem' abstract class

    /// </summary>

    public abstract class ConfigurationItem : IConfigurationItem

    {

        protected IConfigurable receiver;

        

        // Constructor

        public ConfigurationItem(IConfigurable receiver)

        {

            this.receiver = receiver;

        }

        public abstract int ID { get; }

        public abstract string Value { get; }

      
    }








}
