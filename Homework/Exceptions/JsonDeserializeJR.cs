using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Exceptions
{
    public class JsonDeserializeJR : Exception
    {


        private JsonDeserializeJR()
        {

        }


        public JsonDeserializeJR(Exception ex) : base(ex.Message)
        {
            
        }
    }
}
