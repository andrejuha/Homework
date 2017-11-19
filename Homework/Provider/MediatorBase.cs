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

    public abstract class MediatorBase<T, R>

    {

        public abstract R ForwardData(T data,

          ProviderBase<T, R> colleague);

    }
}
