using Homework.Configuration;
using Homework.Interfaces;
using Homework.Provider;
using System;
using System.IO;

namespace Homework
{
    public class DiskReaderProvider : ProviderBase<string, string>, IProviderBase<string, string>, IReader

    {
        public DiskReaderProvider(IMediatorBase<string, string> mediator) : base(mediator)
        {
        }

        public override string ForwardData(string data)
        {
            return this.mediator.ForwardData(data, this);
        }

        public override string ProcessData(string data)
        {
            string sourceFileName = base.GetParam((int)ConfigurationEnum.SourcePath).Value;
            string input = string.Empty;
            try
            {
                using (FileStream sourceStream = File.Open(sourceFileName, FileMode.Open))
                {
                    var reader = new StreamReader(sourceStream);
                    input = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //            }
            }
            return input;
           
        }

        public void Read()
        {
           string data= ProcessData( null);
            ForwardData(data);
        }
    }
}
