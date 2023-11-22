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
                string? currencyCode = TryParseCodeNode(codeNode);

                HtmlNode labelNode = cellNodes[1];
                string? currencyLabel = TryParseLabelNode(labelNode);

                HtmlNode trendRateNode = cellNodes[2];

                HtmlNode rateNode = trendRateNode.SelectSingleNode(".//span[@class='rate']");
                float? currencyRate = TryParseRateNode(rateNode);

                HtmlNode? trendNode = trendRateNode.ChildNodes
                    .Where(childNode => childNode.Attributes.Any(attribute => attribute.Value.Contains("trend")))
                    .FirstOrDefault();

                Trend? currencyTrend = null;
                if (trendNode != null)
                {
                    currencyTrend = TryParseTrendNode(trendNode);
                }

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

        private static string? TryParseCodeNode(HtmlNode codeNode)
        {
            return codeNode.InnerText;
        }

        private static string? TryParseLabelNode(HtmlNode labelNode)
        {
            return labelNode.InnerText;
        }

        private static Trend? TryParseTrendNode(HtmlNode trendNode)
        {
            HtmlAttribute? classAttributeLookup = trendNode.Attributes
                .FirstOrDefault(attribute => attribute.Name == "class");

            if (classAttributeLookup == null)
            {
                return null;
            }

            string[] trendTokens = classAttributeLookup.Value.Split(" ");

            return trendTokens[1] == "up"
            ? Trend.Up
            : trendTokens[1] == "eq"
                        ? Trend.None
                        : Trend.Down;
        }

        private static float? TryParseRateNode(HtmlNode rateNode)
        {
            float result;
            bool parseAttempt = float.TryParse(rateNode.InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out result);

            if (parseAttempt)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
