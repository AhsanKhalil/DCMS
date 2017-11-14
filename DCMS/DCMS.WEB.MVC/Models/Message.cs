using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCMS.WEB.MVC.Models
{
    public class Message
    {
        public MessageType Type { get; set; }
        public string Description { get; set; }
    }

    public enum MessageType
    {
        Inform
        ,Error
    }
}