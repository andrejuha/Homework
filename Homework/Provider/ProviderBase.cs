using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.Interfaces;

namespace Homework.Provider
{
    public abstract class ProviderBase<T, R> : IProviderBase<T, R>

    {

        protected MediatorBase<T, R> mediator;



        // Constructor

        public ProviderBase(MediatorBase<T, R> mediator)

        {

            this.mediator = mediator;

        }

        public abstract R ForwardData(T data);

        public abstract R ProcessData (T data);

    }
}
