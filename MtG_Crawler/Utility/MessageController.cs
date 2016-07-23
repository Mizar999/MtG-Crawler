using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtG_Crawler.Utility
{
    public class MessageController
    {
        public static ICrawlerMessageReceiver Receiver { get; set; }

        public static void Log(string message)
        {
            Receiver.Log(message);
        }

        public static void SetStatus(string statusText)
        {
            Receiver.SetStatus(statusText);
        }
    }
}
