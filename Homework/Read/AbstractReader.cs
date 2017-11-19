using Homework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
       
   public abstract class AbstractReader: IConfigurable
        
    {
        public AbstractReader()
        { }

        public abstract void Configure(IConfigurationItem parameter);
       
    }
}
