using Homework.Configuration;
using Homework.Document;
using Homework.Exceptions;
using Homework.Interfaces;
using Homework.Provider;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Homework
{
    public class JsonReaderProvider : ProviderBase<string, string>, IProviderBase<string, string>, IReader
    {
        public JsonReaderProvider(IMediator<string, string> mediator) : base(mediator)
        {
        }

        public override string ForwardData(string data)
        {
            return this.mediator.ForwardData(data, this);
        }

        public override string ProcessData(string data)
        {
            string targetFileName = base.GetParam((int)ConfigurationEnum.SourcePath).Value;
            SimpleDocument json = null;
            try
            {
                using (StreamReader r = new StreamReader(targetFileName))
                {
                    string jsonfile = r.ReadToEnd();
                    json = JsonConvert.DeserializeObject<SimpleDocument>(jsonfile);
                }

            }
            catch (Exception ex)
            {
                throw new JsonDeserializeJR(ex);
            }

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            //string oututdata=string.Empty;
            XmlDocument doc = new XmlDocument();
            try
            {
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(docNode);

                XmlNode simpleDocument = doc.CreateElement("SimpleDocument");
                doc.AppendChild(simpleDocument);

                XmlNode productNode = doc.CreateElement("title");
                productNode.AppendChild(doc.CreateTextNode("Java"));
                simpleDocument.AppendChild(productNode);


                XmlNode productNode1 = doc.CreateElement("text");
                productNode1.AppendChild(doc.CreateTextNode(json.Title));
                simpleDocument.AppendChild(productNode1);
    
            }
            catch (Exception ex)
            {
                throw new StreamExceptionJR(ex);
            }
            return doc.OuterXml; 
        }

        public void Read()
        {
            string data = ProcessData(null);
            ForwardData(data);
        }
    }
}
