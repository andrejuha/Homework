using Homework.Configuration;
using Homework.Exceptions;
using Homework.Interfaces;
using Homework.Provider;
using System;

namespace Homework
{
    public class CloudReaderProvider : ProviderBase<string, string>, IProviderBase<string, string>, IReader, ICloudReaderProvider
    {
        private DummyAuthetificationProxy daProxy= null;
        public CloudReaderProvider(IMediator<string, string> mediator) : base(mediator)
        {
        }

        public override string ForwardData(string data)
        {
            return this.mediator.ForwardData(data, this);
        }

        public override string ProcessData(string data)
        {
            string sourceFileName = base.GetParam((int)ConfigurationEnum.SourcePath).Value;
            string userName = base.GetParam((int)ConfigurationEnum.UserName).Value;
            string password = base.GetParam((int)ConfigurationEnum.Password).Value;
            string url = base.GetParam((int)ConfigurationEnum.Url).Value;


            if (daProxy == null)
            {
                daProxy = new DummyAuthetificationProxy();
                bool authetificated = daProxy.Authentificate(userName, userName);

                if (!authetificated)
                    throw new AuthentificateExceptinCW(new Exception("Dummy Cloud proxy not authetificated."));
            }

          string outpuData=  daProxy.GetStringFile(sourceFileName);


          return outpuData;
        }

        public void Read()
        {
            string data = ProcessData(null);
            ForwardData(data);
        }
    }
}
