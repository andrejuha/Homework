using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Exceptions
{
    public class SerializeExceptionJW : Exception
    {
        private SerializeExceptionJW()
        {
        }

        public SerializeExceptionJW(Exception ex) : base(ex.Message)
        {

        }
    }
}
