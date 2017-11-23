using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Exceptions
{
    public class ParseExceptionXW : Exception
    {
        private ParseExceptionXW()
        {
        }

        public ParseExceptionXW(Exception ex) : base(ex.Message)
        {

        }
    }
}
