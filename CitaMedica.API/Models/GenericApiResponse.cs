using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitaMedica.API.Models
{
    public class GenericApiResponse : IResponse
    {
        public int HttpCode { get; set; }
        public string Message { get; set; }
    }
}