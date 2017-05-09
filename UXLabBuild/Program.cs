using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UXLabBuild
{
    class Program
    {
        static void Main(string[] args)
        {
            StockInfo stockinfo = new StockInfo("MSFT");
            var msftStock = stockinfo.Lookup();
            Console.WriteLine("{0} ({1}) stock is at {2}",
                               msftStock.Name, msftStock.Symbol, msftStock.LastPrice);
        }
    }

    class StockInfo
    {
        public string symbol { get; set; }
        private readonly HttpClient http;

        public StockInfo(string symbol)
        {
            this.symbol = symbol;
            http = new HttpClient();
        }

        public Stock Lookup()
        {
            string url = string.Format("http://dev.markitondemand.com/MODApis/Api/v2/Quote/json?symbol={0}", symbol);
            var json = await http.GetStringAsync(url);
            Stock stock = JsonConvert.DeserializeObject<Stock>(json);
            return Stock;
        }

        public class Stock
        {
            public string Status { get; set; }
            public string Name { get; set; }
            public string Symbol { get; set; }
            public double LastPrice { get; set; }
            public double Change { get; set; }
            public double ChangePercent { get; set; }
            public string Timestamp { get; set; }
            public int MSDate { get; set; }
            public long MarketCap { get; set; }
            public int Volume { get; set; }
            public double ChangeYTD { get; set; }
            public double ChangePercentYTD { get; set; }
            public double High { get; set; }
            public double Low { get; set; }
            public double Open { get; set; }
        }
    }
}
