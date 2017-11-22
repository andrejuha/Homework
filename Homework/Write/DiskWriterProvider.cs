using Homework.Provider;
using System;

namespace Homework
{
    public class WriterProvider : ProviderBase<string, string>
    {
        public WriterProvider(MediatorBase<string, string> mediator) : base(mediator)
        {
        }

        public override string ForwardData(string data)
        {
            return this.mediator.ForwardData(data, this);
        }


        public override string ProcessData(string data)
        {
            Console.WriteLine("WriterProvider ProcessData message: " + data);
            return "Console writen:" + data;
        }
    }
}
