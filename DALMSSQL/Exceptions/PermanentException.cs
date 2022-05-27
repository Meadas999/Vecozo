using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALMSSQL.Exceptions
{
    public class PermanentException : Exception
    {
        public string errorMessage { get; set; }
        public string? PermanentErrorMessage { get; set; }

        public PermanentException(string errorMessage, string? perError = null) : base(errorMessage)
        {
            this.errorMessage = errorMessage;
            PermanentErrorMessage = perError;
        }

        public string GetFullError()
        {
            return $"{errorMessage} {PermanentErrorMessage}";
        }
    }
}
