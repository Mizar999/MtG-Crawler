using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtG_Crawler.Data
{
    public class Card
    {
        public string Name { get; set; }
        public string GermanTranslation { get; set; }
        public string Rarity { get; set; }
        public decimal Price { get; set; }
        public string CollectorsNumber { get; set; }

        public Card() : this(string.Empty, string.Empty, string.Empty, string.Empty, 0.0M)
        {

        }

        public Card(string name, string germanTranslation, string rarity, string collectorsNumber, decimal price)
        {
            Name = name;
            GermanTranslation = germanTranslation;
            CollectorsNumber = collectorsNumber;
            Rarity = rarity;
            Price = price;
        }

        public override string ToString()
        {
            return string.Format("[{0}],[{1}],[{2}],[{3}],[{4}]", Name, GermanTranslation, Rarity, CollectorsNumber, Price);
        }
    }
}
