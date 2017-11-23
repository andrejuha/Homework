using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Exceptions
{
    public class AuthentificateExceptinCW : Exception
    {


        private AuthentificateExceptinCW()
        {

        }


        public AuthentificateExceptinCW(Exception ex) : base(ex.Message)
        {
            
        }
    }
}
