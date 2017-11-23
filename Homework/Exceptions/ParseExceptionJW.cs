using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Exceptions
{
    public class ParseExceptionJW : Exception
    {
        private ParseExceptionJW()
        {
        }

        public ParseExceptionJW(Exception ex) : base(ex.Message)
        {

        }
    }
}
