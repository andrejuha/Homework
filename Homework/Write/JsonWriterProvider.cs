using Homework.Configuration;
using Homework.Document;
using Homework.Exceptions;
using Homework.Interfaces;
using Homework.Provider;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace Homework
{
    public class JsonWriterProvider : ProviderBase<string, string>
    {
        public JsonWriterProvider(IMediatorBase<string, string> mediator) : base(mediator)
        {
        }

        public override string ForwardData(string data)
        {
            return this.mediator.ForwardData(data, this);
        }


        public override string ProcessData(string data)
        {
            string targetFileName = base.GetParam((int)ConfigurationEnum.DestinationPath).Value;
            XDocument xdoc = null;
            string serializedDoc = null;
            SimpleDocument doc = null;

            //IEnumerable<XNode> nodes = xdoc.Root.Nodes().to;

            try
            {
                 xdoc = XDocument.Parse(data);

                List<XNode> list = new List<XNode>(xdoc.Root.Nodes());

                Predicate<XNode> titleFinder = (XNode p) => { return ((System.Xml.Linq.XElement)p).Name == "title"; };
                Predicate<XNode> textFinder = (XNode p) => { return ((System.Xml.Linq.XElement)p).Name == "text"; };

                if (!(list.Exists(titleFinder)&& list.Exists(textFinder)))
                    throw new ParseDataExceptionJW(new Exception("JsonWriterProvider: node 'title'or node 'text'  not exists."));

                doc = new SimpleDocument
                {
                Title = xdoc.Root.Element("title").Value,
                Text = xdoc.Root.Element("text").Value
                };
            }
            catch (Exception ex)
            {
                throw new ParseDataExceptionJW(ex);
            }

    
            try
            {
                 serializedDoc = JsonConvert.SerializeObject(doc);
            }
            catch(Exception ex)
            {
                throw new SerializeExceptionJW(ex);
            }

            try
            {
                using (var targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write))
                {
                    var sw = new StreamWriter(targetStream);
                    sw.Write(serializedDoc);
                    sw.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new StreamExceptionJW(ex);
            }

            return string.Empty;
            //            sw.Write(serializedDoc);
            }
    }
}
