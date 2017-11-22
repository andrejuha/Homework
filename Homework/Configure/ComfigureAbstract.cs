using Homework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
       
   public abstract class ComfigureAbstract: IConfigurable
        
    {
        public ComfigureAbstract()
        { }

        public abstract void Configure(IConfigurationItem parameter);

        public abstract IConfigurationItem GetParam(int parameterID);

    }
}
