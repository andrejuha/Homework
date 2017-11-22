using Homework.Interfaces;
using Homework.Provider;
using System;

namespace Homework
{
    public class ConcreteMediator<T, R> : MediatorBase<T, R>,IMediatorBase<T, R>
    {
        private IProviderBase<T, R> _readerProvider;

        private IProviderBase<T, R> _writerProvider;

        public IProviderBase<T, R> ReaderProvider
        {
            set
            {
                this._readerProvider = value;
            }
        }

        public IProviderBase<T, R> WriterProvider
        {
            set
            {
                this._writerProvider = value;
            }
        }

        public override R ForwardData(T data, IProviderBase<T, R> provider)
        {
            bool flag = provider == (ProviderBase<T, R>)this._readerProvider;
            R result;
            if (flag)
            {
                result = this._writerProvider.ProcessData(data);
            }
            else
            {
                result = this._readerProvider.ProcessData(data);
            }
            return result;
        }

    
    }
}