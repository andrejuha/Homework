using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Exceptions
{
    public class StreamExceptionJW : Exception
    {
        private StreamExceptionJW()
        {
        }

        public StreamExceptionJW(Exception ex) : base(ex.Message)
        {

        }
    }
}
