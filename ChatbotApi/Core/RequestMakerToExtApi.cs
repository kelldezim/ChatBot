using ChatbotApi.Dto;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using static ChatbotApi.APIDataModel;

namespace ChatbotApi.Core
{
    public class RequestMakerToExtApi
    {
        private string _countryName;
        private IRestResponse _restResponse;

        public RequestMakerToExtApi(string countryName)
        {
            _countryName = countryName;
        }

        public string GetRowDataModel()
        {
            var client = new RestClient("https://restcountries.eu/rest/v2/name/");
            var request = new RestRequest(_countryName + "?fullText=true");
            _restResponse = client.Execute(request);

            if(_restResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }
            return _restResponse.Content;  
        }

        public CountryOverview MapResultToCountryOverviewDto(string rowContent)
        {
            var countryOver = new CountryOverview();
            List<Country> desirializedResult = JsonConvert.DeserializeObject<List<Country>>(rowContent);
            countryOver.Name = desirializedResult[0].name;
            countryOver.Capital = desirializedResult[0].capital;
            countryOver.Currency = desirializedResult[0].currencies[0].name;
            countryOver.Population = desirializedResult[0].population;

            return countryOver;   
        }
    }
}
