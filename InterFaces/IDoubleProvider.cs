

namespace Homework.Interfaces
{
    public interface IDoubleProvider<R, W>
    {
        IMediator<R, W> mediator { get; }
        IProviderBase<R, W> readerProvider { get; }
        IProviderBase<R, W> writerProvider { get; }

        void Process();
    }
}