using Newtonsoft.Json.Linq;
using System.Net;

namespace KoronaPayParserLib
{
    public class KoronaPayParser
    {
        string _sendingCountry;
        string _sendingCurrency;
        string _receivingAmount;
        GetRequest _getRequest;
        JToken _response;
        DataStorage _dataStorage;
        public KoronaPayParser()
        {
            _dataStorage = new DataStorage();
            _sendingCountry = "RUS";
            _sendingCurrency = "RUB";
            _receivingAmount = (100 * 100).ToString();
        }

        public void Parse(string receivingCountry, string receivingCurrency)
        {
            try
            {
                string receivingCurrencyId = _dataStorage.GetCurrencyId(receivingCurrency);
                string sendingCurrencyId = _dataStorage.GetCurrencyId(_sendingCurrency);
                string address = ConfigureAddress(_sendingCountry, sendingCurrencyId, receivingCountry.ToUpper(), receivingCurrencyId, _receivingAmount);
                _getRequest = new GetRequest(address);
                _getRequest.Run();
                _response = JArray.Parse(_getRequest.Response)[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string ConfigureAddress(string sendingCountry, string sendingCurrencyId, string receivingCountry, string receivingCurrencyId, string receivingAmount)
        {
            return $"https://koronapay.com/transfers/online/api/transfers/tariffs?sendingCountryId={sendingCountry}&sendingCurrencyId={sendingCurrencyId}" +
                $"&receivingCountryId={receivingCountry}&receivingCurrencyId={receivingCurrencyId}&paymentMethod=debitCard&receivingAmount={receivingAmount}" +
                $"&receivingMethod=cash&paidNotificationEnabled=false";
        }

        public string GetExchangeRate()
        {
            if (_response != null)
                return _response["exchangeRate"].ToString();
            else
                return "N\\D";
        }

        public string GetReceivingAmount()
        {
            if (_receivingAmount.Length > 2)
                return $"{_receivingAmount.Substring(0, _receivingAmount.Length - 2)},{_receivingAmount.Substring(_receivingAmount.Length - 2)}";
            else
                return _receivingAmount;
        }

        public string GetSendingAmount()
        {
            if (_response != null)
            {
                var sendingAmount = _response["sendingAmount"].ToString();
                if (sendingAmount.Length > 2)
                    return $"{sendingAmount.Substring(0, sendingAmount.Length - 2)},{sendingAmount.Substring(sendingAmount.Length - 2)}";
                else
                    return sendingAmount;
            }
            else
                return "N\\D";
        }

        public string GetSendingAmountWithoutCommission()
        {
            if (_response != null)
            {
                var sendingAmountWithoutCommission = _response["sendingAmountWithoutCommission"].ToString();
                if (sendingAmountWithoutCommission.Length > 2)
                    return $"{sendingAmountWithoutCommission.Substring(0, sendingAmountWithoutCommission.Length - 2)}," +
                           $"{sendingAmountWithoutCommission.Substring(sendingAmountWithoutCommission.Length - 2)}";
                else
                    return sendingAmountWithoutCommission;
            }
            else
                return "N\\D";
        }
        public string GetSendingCommission()
        {
            if (_response != null)
            {
                var sendingCommission = _response["sendingCommission"].ToString();
                if (sendingCommission.Length > 2)
                    return $"{sendingCommission.Substring(0, sendingCommission.Length - 2)},{sendingCommission.Substring(sendingCommission.Length - 2)}";
                else
                    return sendingCommission;
            }
            else
                return "N\\D";
        }

    }
}