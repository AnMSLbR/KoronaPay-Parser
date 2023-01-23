using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoronaPayParserLib
{
    internal class DataStorage
    {
        Dictionary<string, List<string>> countries = new Dictionary<string, List<string>>()
        {
            ["TJK"] = new List<string> { "USD", "RUB" },
            ["UZB"] = new List<string> { "USD" },
            ["KGZ"] = new List<string> { "USD", "RUB" },
            ["AZE"] = new List<string> { "USD", "AZN", "RUB" },
            ["TUR"] = new List<string> { "USD", "TRY", "EUR" },
            ["MDA"] = new List<string> { "EUR", "USD", "MDL" },
            ["KAZ"] = new List<string> { "USD", "KZT", "RUB" },
            ["GEO"] = new List<string> { "USD", "EUR", "GEL", "RUB" },
            ["BLR"] = new List<string> { "RUB" },
            ["VNM"] = new List<string> { "USD" },
            ["ISR"] = new List<string> { "USD" },
            ["CYP"] = new List<string> { "EUR" },
            ["KOR"] = new List<string> { "USD" },
            ["SRB"] = new List<string> { "EUR" }
        };

        Dictionary<string, string> currencies = new Dictionary<string, string>()
        {
            ["USD"] = "840",
            ["EUR"] = "978",
            ["RUB"] = "810",
            ["AZN"] = "944",
            ["TRY"] = "949",
            ["MDL"] = "498",
            ["KZT"] = "398",
            ["GEL"] = "981",
        };

        Dictionary<string, string> limits = new Dictionary<string, string>()
        {
            ["GEO"] = "1...2000 USD",
            ["CYP"] = "1...3000 EUR",
            ["Other"] = "1...5000 USD",
        };

        Dictionary<string, string> countriesFullForm = new Dictionary<string, string>()
        {
            ["AZE"] = "Azerbaijan",
            ["BLR"] = "Belarus",
            ["CYP"] = "Cyprus",
            ["GEO"] = "Georgia",
            ["ISR"] = "Israel",
            ["KAZ"] = "Kazakhstan",
            ["KGZ"] = "Kyrgyzstan",
            ["MDA"] = "Moldova",
            ["SRB"] = "Serbia",
            ["KOR"] = "South Korea",
            ["TJK"] = "Tajikistan",
            ["TUR"] = "Turkey",
            ["UZB"] = "Uzbekistan",
            ["VNM"] = "Vietnam",
        };

        public Dictionary<string, List<string>> Countries { get => countries; private set => countries = value; }
        public Dictionary<string, string> Limits { get => limits; private set => limits = value; }
        public Dictionary<string, string> CountriesFullForm { get => countriesFullForm; private set => countriesFullForm = value; }

        public string GetCurrencyId(string currency)
        {
            if (currencies.ContainsKey(currency.ToUpper()))
                return currencies[currency.ToUpper()];
            else
                return string.Empty;
        }

    }
}
