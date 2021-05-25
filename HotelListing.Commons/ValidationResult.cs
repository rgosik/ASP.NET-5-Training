using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Commons
{
    public class ValidationResult<T>
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T Content { get; set; }
    }

    public class ValidationResult
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
