using Homework.Configuration;
using Homework.Document;
using Homework.Exceptions;
using Homework.Interfaces;
using Homework.Provider;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml;

namespace Homework
{
    public class JsonReaderProvider : ProviderBase<string, string>, IProviderBase<string, string>, IReader
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
            string targetFileName = base.GetParam((int)ConfigurationEnum.DestinationPath).Value;
            SimpleDocument json = null;
            try
            {
                 json = JsonConvert.DeserializeObject<SimpleDocument>(data);
            }
            catch (Exception ex)
            {
                throw new StreamExceptionJW(ex);
            }

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            try
            {
                using (XmlWriter writer = XmlWriter.Create(targetFileName, settings))

                {
                    writer.WriteStartElement("Employee");

                    writer.WriteElementString("title", json.Title);

                    writer.WriteElementString("text", json.Text);

                    writer.WriteEndElement();
                }
            }
            catch (Exception ex)
            {
                throw new StreamExceptionJW(ex);
            }
            return string.Empty;
        }

        public void Read()
        {
            string data = ProcessData(null);
            ForwardData(data);
        }
    }
}
