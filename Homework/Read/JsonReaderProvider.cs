using Homework.Configuration;
using Homework.Interfaces;
using Homework.Provider;
using System;
using System.IO;

namespace Homework
{
    public class JsonReaderProvider : ProviderBase<string, string>, IProviderBase<string, string>
    {
        public JsonReaderProvider(MediatorBase<string, string> mediator) : base(mediator)
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
