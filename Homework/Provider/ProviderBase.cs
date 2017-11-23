using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.Interfaces;

namespace Homework.Provider
{
    public abstract class ProviderBase<T, R> : ConfigureBase, IProviderBase<T, R>, IConfigurable

    {
        
        protected IMediatorBase<string, string> mediator;



        // Constructor

        public ProviderBase(IMediatorBase<string, string> mediator)

        {

            this.mediator = mediator;

        }

        public abstract R ForwardData(T data);

        public abstract R ProcessData (T data);

        public override void Configure(IConfigurationItem parameter)
        {
            base.Configure(parameter);
        }

        

    }
}
