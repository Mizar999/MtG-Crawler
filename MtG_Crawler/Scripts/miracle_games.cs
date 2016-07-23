using System;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Threading;
using HtmlAgilityPack;
using MtG_Crawler.Data;
using MtG_Crawler.Utility;
using System.Text.RegularExpressions;
using System.Linq;

// Hinweis: In den VS-Eigenschaften dieser Datei muss "Buildvorgang" auf "Keine" gesetzt sein

public class Script
{
    private static Dictionary<string, string> _rarities;
    private string _currentSet;
    private string _currentRarity;
    private static Regex _removeCommentsRegex;
    private static Encoding _webSiteEncoding;

    static Script()
    {
        _rarities = new Dictionary<string, string>();
        _rarities["c"] = "Common";
        _rarities["u"] = "Uncommon";
        _rarities["r"] = "Rare";
        _rarities["m"] = "Mythic Rare";

        _removeCommentsRegex = new Regex(@"<!--\d+-->");

        _webSiteEncoding = Encoding.GetEncoding("iso-8859-1");
    }

    public IEnumerable<CardSet> GetData(string setParameter)
    {
        string[] sets = setParameter.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(element => element.ToLower()).Distinct().ToArray();
        foreach (string setStr in sets)
        {
            _currentSet = setStr;
            MessageController.SetStatus(string.Format("Set: {0}", _currentSet));
            CardSet cards = new CardSet(setStr);

            foreach (KeyValuePair<string, string> rarity in _rarities)
            {
                HtmlWeb htmlWeb = new HtmlWeb()
                {
                    AutoDetectEncoding = false,
                    OverrideEncoding = _webSiteEncoding
                };

                _currentRarity = rarity.Value;
                string url = string.Format("http://www.miraclegames.de/d/cards.php?id=index&set={0}&ra={1}&la=mix", setStr, rarity.Key);
                HtmlDocument doc = htmlWeb.Load(url);
                foreach (Card card in GetCards(doc.DocumentNode, rarity.Value))
                    cards.AddCard(card);

                Thread.Sleep(500);
            }

            cards.OrderBy(CardSet.MythicRarity, CardSet.RareRarity, CardSet.UncommonRarity, CardSet.CommonRarity);
            yield return cards;

            MessageController.Log(string.Format("Set: '{0}' {1}", setStr, cards.GetSetOverview()));
        }
    }

    private IEnumerable<Card> GetCards(HtmlNode docNode, string rarity)
    {
        HtmlNodeCollection nodes = docNode.SelectNodes("//table//tr[@valign = 'center' and @height = '25']");
        if (nodes != null)
        {
            int counter = 0;
            foreach (HtmlNode node in nodes)
            {
                HtmlNode cardNameNode = node.SelectSingleNode("./td[1]/div/a[contains(@href, 'cards.php?id=search&cn=')]/font");
                HtmlNode cardPriceNode = node.SelectSingleNode("./td[2]/div/font");
                if (cardNameNode != null && cardPriceNode != null)
                {
                    MessageController.SetStatus(string.Format("Set: {0} / Seltenheit: {1} / Anzahl Karten: {2}", _currentSet, _currentRarity, counter + 1));

                    string[] names = cardNameNode.InnerText.Split(new string[] { "&nbsp;" }, StringSplitOptions.RemoveEmptyEntries);
                    string price = _removeCommentsRegex.Replace(cardPriceNode.InnerText, string.Empty);
                    decimal convertedPrice = decimal.Parse(price, CultureInfo.InvariantCulture);
                    yield return new Card()
                    {
                        Name = names.Length >= 0 ? names[0] : "<No Name>",
                        GermanTranslation = names.Length >= 1 ? names[1] : "<No Name>",
                        Rarity = rarity,
                        CollectorsNumber = (++counter).ToString(),
                        Price = convertedPrice
                    };
                }
            }
        }
    }
}
