using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Exceptions
{
    public class ParseDataExceptionJW : Exception
    {
        private ParseDataExceptionJW()
        {
        }

        public ParseDataExceptionJW(Exception ex) : base(ex.Message)
        {

        }

        public ParseDataExceptionJW(Exception ex,string badData) : base(badData+" : "+ex.Message)
        {

        }
    }
}
