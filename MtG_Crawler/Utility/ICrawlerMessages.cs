using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtG_Crawler.Utility
{
    public interface ICrawlerMessageReceiver
    {
        void Log(string message);

        void SetStatus(string statusText);
    }
}
