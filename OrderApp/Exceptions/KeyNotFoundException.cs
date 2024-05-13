using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Middleware
{
    public class KeyNotFoundException : Exception
    {
        public KeyNotFoundException(string message) //: base(message)
        { }
    }
}
