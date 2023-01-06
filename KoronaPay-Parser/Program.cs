using KoronaPayParserLib;
using System.Linq;

KoronaPayParser parser = new KoronaPayParser();

Console.WriteLine("Select a country: " + $"{string.Join(", ", parser.GetCountries())}");
var country = Console.ReadLine().ToUpper();
while (!parser.GetCountries().Contains(country))
{
    Console.WriteLine("Invalid country. Select a available country: " + $"{string.Join(", ", parser.GetCountries())}");
    country = Console.ReadLine().ToUpper();
}

Console.WriteLine("Select a currency: " + $"{string.Join(", ", parser.GetCurrencies(country))}");
var currency = Console.ReadLine().ToUpper(); ;
while (!parser.GetCurrencies(country).Contains(currency))
{
    Console.WriteLine("Invalid currency. Select an available currency: " + $"{string.Join(", ", parser.GetCurrencies(country))}");
    currency = Console.ReadLine().ToUpper();
}

parser.Parse(country, currency);

Console.WriteLine($"Exchange rate: {parser.GetExchangeRate()} {parser.GetSendingCurrency()}");
Console.WriteLine($"Transfer amount: {parser.GetReceivingAmount()} {parser.GetReceivingCurrency()}");
Console.WriteLine($"Transfer amount without commision: {parser.GetSendingAmountWithoutCommission()} {parser.GetSendingCurrency()}");
Console.WriteLine($"Commission: {parser.GetSendingCommission()} {parser.GetSendingCurrency()}");
Console.WriteLine($"Total transfer amount: {parser.GetSendingAmount()} {parser.GetSendingCurrency()}");
Console.ReadKey();