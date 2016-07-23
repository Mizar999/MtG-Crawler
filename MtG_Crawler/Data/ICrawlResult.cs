using System.Collections.Generic;
using MtG_Crawler.Data;

namespace MtG_Crawler.Data
{
    public interface ICrawlResult
    {
        IEnumerable<CardSet> GetData(string setParameter);
    }
}
