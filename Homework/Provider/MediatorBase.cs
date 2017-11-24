using Homework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Provider
{
    /// <summary>

    /// The 'MediatorBase' abstract base class

    /// </summary>

    public abstract class MediatorBase<T, R> : IMediatorBase<T, R>

    {
        public abstract R ForwardData(T data, IProviderBase<T, R> provider);

        public abstract IProviderBase<T, R> ReaderProvider
        {
            set;
           
        }

        public abstract IProviderBase<T, R> WriterProvider
        {
            set;
        }
    }
    
}
