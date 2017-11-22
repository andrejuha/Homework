﻿using Homework.Provider;
using System;

namespace Homework
{
    public class XmlWriterProvider : ProviderBase<string, string>
    {
        public XmlWriterProvider(MediatorBase<string, string> mediator) : base(mediator)
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