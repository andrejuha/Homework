using Homework.Configuration;
using Homework.Exceptions;
using Homework.Interfaces;
using Homework.Provider;
using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Homework
{
    public class XmlWriterProvider : ProviderBase<string, string>
    {
        public XmlWriterProvider(IMediatorBase<string, string> mediator) : base(mediator)
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

            try
            {
                xdoc = XDocument.Parse(data);
            }
            catch (Exception ex)
            {
                throw new ParseExceptionXW(ex);
            }

            try
            {
             
                xdoc.Save(targetFileName);
                
            }
            catch (Exception ex)
            {
                throw new XmlWriterExceptionXW(ex);
            }
            return null;
        }
    }
}
