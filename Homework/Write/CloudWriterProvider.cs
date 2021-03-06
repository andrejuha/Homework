﻿using Homework.Configuration;
using Homework.Exceptions;
using Homework.Interfaces;
using Homework.Provider;
using System;

namespace Homework
{
    public class CloudWriterProvider : ProviderBase<string, string>
    {
        public CloudWriterProvider(IMediator<string, string> mediator) : base(mediator)
        {
        }

        public override string ForwardData(string data)
        {
            return this.mediator.ForwardData(data, this);
        }


        public override string ProcessData(string data)
        {
            string targetFileName = base.GetParam((int)ConfigurationEnum.DestinationPath).Value;
            string userName = base.GetParam((int)ConfigurationEnum.UserName).Value;
            string password = base.GetParam((int)ConfigurationEnum.Password).Value;
            string url= base.GetParam((int)ConfigurationEnum.Url).Value;

            DummyAuthetificationProxy daProxy=new DummyAuthetificationProxy();
            bool authetificated=daProxy.Authentificate(userName, userName);

            if (!authetificated)
                throw new AuthentificateExceptinCW(new Exception("Dummy Cloud proxy not authetificated."));

            daProxy.WriteStringFile(targetFileName, data);


            return string.Empty;
        }
    }
}
