using HtmlAgilityPack;
using System.Globalization;
using DoughAssistantBackend.Models;

namespace DoughAssistantBackend.Services
{
    public class CurrencyScraper
    {
        private readonly string _url;
        private readonly string _xPath;

        public CurrencyScraper(string url, string xPath)
        {
            _url = url;
            _xPath = xPath;
        }

        public List<Currency> GetCurrencies()
        {
            string htmlString = GetHtmlAsString(_url).Result;
            var result = ParseHtml(htmlString, _xPath);

            return result;
        }

        private async Task<string> GetHtmlAsString(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);
            return response;
        }

        private List<Currency> ParseHtml(string htmlString, string xPath)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);

            HtmlNode? tableBodyNode = htmlDoc.DocumentNode.SelectNodes(xPath).FirstOrDefault();

            List<Currency> currencies = new List<Currency>();

            if (tableBodyNode == null)
            {
                return currencies;
            }

            foreach (HtmlNode rowNode in tableBodyNode.SelectNodes("tr"))
            {
                HtmlNodeCollection cellNodes = rowNode.SelectNodes("td");

                HtmlNode codeNode = cellNodes[0];
                string currencyCode = TryParseCodeNode(codeNode);

                HtmlNode labelNode = cellNodes[1];
                string currencyLabel = TryParseLabelNode(labelNode);

                HtmlNode rateNode = cellNodes[2].SelectSingleNode(".//span[@class='rate']");
                float? currencyRate = ParseRateNode(rateNode);
                
                HtmlNode? trendNode = cellNodes[2].ChildNodes
                    .FirstOrDefault(childNode =>
                        childNode.Attributes.Any(attribute => attribute.Value.Contains("trend")));
                
                Trend? currencyTrend = ParseTrendNode(trendNode);
                
                Currency currency = new Currency()
                {
                    CurrencyCode = currencyCode,
                    Label = currencyLabel,
                    Rate = currencyRate,
                    Trend = currencyTrend
                };

                currencies.Add(currency);
            }

            return currencies;
        }

        private static string TryParseCodeNode(HtmlNode codeNode)
        {
            return codeNode.InnerText;
        }

        private static string TryParseLabelNode(HtmlNode labelNode)
        {
            return labelNode.InnerText;
        }

        private static Trend? ParseTrendNode(HtmlNode? trendNode)
        {
            HtmlAttribute? classAttributeLookup = trendNode?.Attributes
                .FirstOrDefault(attribute => attribute.Name == "class");

            if (classAttributeLookup == null)
            {
                return null;
            }

            string[] trendTokens = classAttributeLookup.Value.Split(" ");

            return trendTokens[1] switch
            {
                "up" => Trend.Up,
                "down" => Trend.Down,
                "eq" => Trend.None,
                _ => null
            };
        }

        private static float? ParseRateNode(HtmlNode rateNode)
        {
            bool isParsed = float.TryParse(rateNode.InnerText, NumberStyles.Any, CultureInfo.InvariantCulture,
                out var result);

            if (isParsed)
            {
                return result;
            }

            return null;
        }
    }
}