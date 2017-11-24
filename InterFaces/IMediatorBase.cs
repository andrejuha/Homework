using Homework.Interfaces;

namespace Homework.Interfaces
{
    public interface IMediatorBase<T, R>
    {
        R ForwardData(T data, IProviderBase<T, R> provider);

        IProviderBase<T, R> ReaderProvider
        {
            set;

        }

         IProviderBase<T, R> WriterProvider
        {
            set;
        }
    }
}