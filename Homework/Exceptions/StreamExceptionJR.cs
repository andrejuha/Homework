using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Exceptions
{
    public class StreamExceptionJR : Exception
    {


        private StreamExceptionJR()
        {

        }


        public StreamExceptionJR(Exception ex) : base(ex.Message)
        {
            
        }
    }
}
