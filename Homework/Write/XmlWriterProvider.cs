using Homework.Configuration;
using Homework.Provider;
using System;
using System.Xml;

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
            string targetFileName = base.GetParam((int)ConfigurationEnum.DestinationPath).Value;

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
           
            try
            {
                using (XmlWriter writer = XmlWriter.Create(targetFileName, settings))

                {
                    writer.WriteStartElement("Employee");
                }
            }
            catch
            {

            }
            return string.Empty;
        }
    }
}
