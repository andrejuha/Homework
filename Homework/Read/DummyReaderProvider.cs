using Homework.Configuration;
using Homework.Interfaces;
using Homework.Provider;
using System;
using System.IO;

namespace Homework
{
    public class ReaderProvider : ProviderBase<string, string>, IProviderBase<string, string>
    {
        public ReaderProvider(MediatorBase<string, string> mediator) : base(mediator)
        {
        }

        public override string ForwardData(string data)
        {
            return this.mediator.ForwardData(data, this);
        }

        public override string ProcessData(string data)
        {
            Console.WriteLine("Reader gets message: " + data);
            return "Console writen:" + data;
        }
    }
}
