using HtmlAgilityPack;

namespace WebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Send Get Request
            string url = "https://weather.com/no-NO/weather/today/l/8f6c82896fd2b9f5f33a3540946133816f19366b5cb9f644b6106ce457e644f2";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Get Temp
            var tempElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--MHmYY']");
            var temp = tempElement.InnerText.Trim();
            Console.WriteLine("Temperature: " + temp);

            // Get Condition
            var conditionsElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue--mZC_p']");
            var conditions = conditionsElement.InnerText.Trim();
            Console.WriteLine("Conditions: " + conditions);

            // Get Location
            var locationElement = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='CurrentConditions--location--1YWj_']");
            var location = locationElement.InnerText.Trim();
            Console.WriteLine("City: " + location);
        }
    }
}