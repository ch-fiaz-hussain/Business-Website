using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ParaTech_Energy.Models
{
    [DataContract]
    public class DataPoint
    {

        public DataPoint(string src, string title)
        {
            this.src = src;
            this.title = title;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "src")]
        public string src = null;
        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "title")]
        public string title = null;
    }
}