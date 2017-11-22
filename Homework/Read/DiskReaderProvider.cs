using Homework.Interfaces;
using Homework.Provider;
using System;

namespace Homework
{
    public class DiskReaderProvider : ProviderBase<string, string>, IProviderBase<string, string>
    {
        public DiskReaderProvider(MediatorBase<string, string> mediator) : base(mediator)
        {
        }

        public override string ForwardData(string data)
        {
            return this.mediator.ForwardData(data, this);
        }

        public override string ProcessData(string data)
        {
            Console.WriteLine("Colleague1 gets message: " + data);
            return "Console writen:" + data;
        }
    }
}
