using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Exceptions
{
    public class Exceptions : Exception
    {
        public Result result { get; set; }

        public AnuExceptions() { }

        public AnuExceptions(string message)
            : base(message) { }

        public AnuExceptions(string message, Exception inner)
            : base(message, inner) { }
        public AnuExceptions(Enum type)
        {
            result = type.GetResult();
        }
        public AnuExceptions(Enum type, string args = null)
        {
            if (args is null)
            {
                result = type.GetResult();
            }
            else
            {
                result = type.GetResult(args: args);
            }
        }
        public AnuExceptions(Enum type, string args = null, Exception exception = null)
        {
            if (args is null)
            {
                if (exception is null)
                {
                    result = type.GetResult();
                }
                else
                {
                    result = type.GetResult(exception);
                }
            }
            else
            {
                if (exception is null)
                {
                    result = type.GetResult(args: args);
                }
                else
                {
                    result = type.GetResult(args: args, exception);
                }
            }
        }
        public AnuExceptions(Enum type, Exception exception = null)
        {

            if (exception is null)
            {
                result = type.GetResult();
            }
            else
            {
                result = type.GetResult(exception);
            }

        }
    }
}
