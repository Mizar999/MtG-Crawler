using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtG_Crawler.Data
{
    public class CardSet
    {
        public string Name { get; set; }

        public const string BasicLandRarity = "Basic Land";
        public const string CommonRarity = "Common";
        public const string UncommonRarity = "Uncommon";
        public const string RareRarity = "Rare";
        public const string MythicRarity = "Mythic Rare";

        private List<Card> _cards;

        public CardSet() : this(string.Empty)
        {

        }

        public CardSet(string name)
        {
            Name = name;
            _cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            _cards.Add(card);
        }

        public void Clear()
        {
            _cards.Clear();
        }

        public IEnumerable<Card> GetCards()
        {
            return _cards;
        }

        public void OrderBy(params string[] rarities)
        {
            // Sortiere alle Karten nach Preis, Name, Sammlernummer und gruppiere sie nach Seltenheit
            var queryRarities =
                from card in _cards
                orderby card.Price descending, card.Name, card.CollectorsNumber
                group card by card.Rarity into newGroup
                orderby newGroup.Key
                select newGroup;

            List<Card> sortedCards = new List<Card>();
            // Daten in der übergebenen Seltenheitsreihenfolge hinzufügen
            foreach (string rarity in rarities)
                sortedCards.AddRange(queryRarities.Where(group => string.Equals(group.Key, rarity)).SelectMany(group => group));
            // Die Daten der restlichen Seltenheiten hinzufügen
            sortedCards.AddRange(queryRarities.Where(group => !rarities.Contains(group.Key)).SelectMany(group => group));

            _cards = sortedCards;
        }

        public IEnumerable<string> GetDistinctRarities()
        {
            return _cards.Select(card => card.Rarity).Distinct();
        }

        public string GetSetOverview()
        {
            Dictionary<string, int> rarityCount = new Dictionary<string, int>();

            foreach (Card card in _cards)
            {
                if (rarityCount.ContainsKey(card.Rarity))
                    ++rarityCount[card.Rarity];
                else
                    rarityCount[card.Rarity] = 1;
            }

            StringBuilder rarityDistribution = new StringBuilder();
            foreach (string rarity in GetDistinctRarities())
            {
                if (rarityDistribution.Length > 0)
                    rarityDistribution.Append(", ");
                rarityDistribution.AppendFormat("{0}: {1}", rarity, rarityCount[rarity]);
            }

            if (rarityDistribution.Length > 0)
                return string.Format("{0} Karten - {1}", _cards.Count, rarityDistribution.ToString());

            return string.Format("{0} Karten", _cards.Count);
        }

        public override string ToString()
        {
            string setOverview = GetSetOverview();

            StringBuilder builder = new StringBuilder();
            builder.AppendLine(Name);

            if (!string.IsNullOrEmpty(setOverview))
                builder.AppendLine(setOverview);

            foreach (Card card in _cards)
                builder.AppendLine(card.ToString());

            return builder.ToString();
        }
    }
}
