using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Exceptions
{
    public class XmlWriterExceptionXW : Exception
    {
        private XmlWriterExceptionXW()
        {
        }

        public XmlWriterExceptionXW(Exception ex) : base(ex.Message)
        {

        }
    }
}
