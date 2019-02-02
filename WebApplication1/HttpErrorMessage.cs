using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WebApplication1
{
    [DataContract]
    public class HttpErrorMessage
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string ExceptionMessage { get; set; }

        [DataMember]
        public string MessageDetail { get; set; }
    }
}