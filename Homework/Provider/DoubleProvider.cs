using Homework.Interfaces;
using Homework.Provider;
using System;

namespace Homework
{
    public class DoubleProvider<R,W> : ConfigureBase, IConfigurable, IDoubleProvider<R, W>
    {

        public IProviderBase<R, W> readerProvider {get; private set;}

        public IProviderBase<R, W> writerProvider { get; private set; }

        public IMediator<R, W> mediator { get; private set; }

        public DoubleProvider(IProviderBase<R, W> readerProvider, IProviderBase<R, W> writerProvider, IMediator<R, W> mediator)
        {
            
            this.readerProvider = readerProvider;
            this.writerProvider = writerProvider;
            this.mediator = mediator;
            this.mediator.ReaderProvider = readerProvider;
            this.mediator.WriterProvider = writerProvider;

        }

       public void Process()
        {
            //R data = default(R);
            //W writeData= default(W);
            //writeData=
                ((IReader) this.readerProvider).Read();

        }
    }
}
