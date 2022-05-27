using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQL.Exceptions
{
    public class TemporaryException : Exception
    {
        public string errorMessage { get; set; }
        public string? excMessage { get; set; }

        public TemporaryException(string errorMessage, string? excMessage = null) : base(errorMessage)
        {
            this.errorMessage = errorMessage;
            this.excMessage = excMessage;
        }

        public string GetError()
        {
            return $"{errorMessage} {excMessage}";
        }
    }
}
