using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Commons
{
    public class ValidationResult<T> : ValidationResult
    {
        public T Content { get; set; }

        public ValidationResult(T content,
            int statusCode,
            bool succesful,
            string message = null) : base (statusCode, succesful, message)
        {
            Content = content;
        }
    }

    public class ValidationResult
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool Succesful { get; set; }

        public ValidationResult(int statusCode,
            bool succesful,
            string message = null)
        {
            StatusCode = statusCode;
            Succesful = succesful;
            Message = message;
        }
    }
}
