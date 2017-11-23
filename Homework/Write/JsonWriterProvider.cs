﻿using Homework.Configuration;
using Homework.Document;
using Homework.Provider;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml.Linq;

namespace Homework
{
    public class JsonWriterProvider : ProviderBase<string, string>
    {
        public JsonWriterProvider(MediatorBase<string, string> mediator) : base(mediator)
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

            try
            {
                 xdoc = XDocument.Parse(data);
            }
            catch (Exception ex)
            {
            }

            var doc = new SimpleDocument
            {
                Title = xdoc.Root.Element("title").Value,
                Text = xdoc.Root.Element("text").Value
            };
            try
            {
                 serializedDoc = JsonConvert.SerializeObject(doc);
            }
            catch(Exception ex)
            {

            }

            try
            {
                using (var targetStream = File.Open(targetFileName, FileMode.Create, FileAccess.Write))
                {
                    var sw = new StreamWriter(targetStream);
                }
            }
            catch (Exception ex)
            {

            }

            return string.Empty;
            //            sw.Write(serializedDoc);
            }
    }
}
