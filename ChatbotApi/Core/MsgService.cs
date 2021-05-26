using ChatbotApi.Dto;
using ChatbotApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatbotApi.Core
{
    public class MsgService
    {
        private string _msgBody;
        private string _msgBodyToSent;
        private bool _cleanHistory;

        public MsgService(string msgBody)
        {
            _msgBody = msgBody;
            _cleanHistory = false;
        }

        public MessageDto MsgProcessor()
        {
            var splitMsg = _msgBody.Split(" ");
            string keyWord = splitMsg[0].ToUpper();
            

            if (keyWord == "COUNTRY" && splitMsg[1] != null && splitMsg[1] != "")
            {
                var requestMakerToExtApi = new RequestMakerToExtApi(splitMsg[1]);
                string rowContent = requestMakerToExtApi.GetRowDataModel();

                var countryOverview = new CountryOverview();
                if (!String.IsNullOrEmpty(rowContent))
                {
                    countryOverview = requestMakerToExtApi.MapResultToCountryOverviewDto(rowContent);
                    _msgBodyToSent = PrepareMsgBodyWithCountryDetails(countryOverview);
                }
                else
                {
                    _msgBodyToSent = "Provided country doesn't exist. Please double check typed country correctness.";
                }      
            }
            else if(StaticResponseLibrary.cmds.ContainsKey(keyWord))
            {
                _msgBodyToSent = StaticResponseLibrary.cmds[keyWord];
                if (keyWord == "BYE")
                {
                    _cleanHistory = true;
                }
            }
            else
            {
                _msgBodyToSent = @"I am sorry but I don't understand you message. If you want to get information about countries please type: country <country_name>. Example: country poland";
            }
            

            return CreateMsgToSent();
        }

        public Task<MessageDto> MsgProcessorAsync()
        {
            return Task<MessageDto>.Run(() => MsgProcessor());
        }

        public string PrepareMsgBodyWithCountryDetails(CountryOverview countryOverview)
        {
            return $"The full name of the country is {countryOverview.Name}. The capital is {countryOverview.Capital}. The currency is {countryOverview.Currency} and it's settled by {countryOverview.Population} people.";
        }

        public MessageDto CreateMsgToSent()
        {
            var msgDto = new MessageDto();
            msgDto.MessageBody = _msgBodyToSent;
            msgDto.UserName = "Bot";

            return msgDto;
        }

        public void CleanHistory(List<Message> history)
        {
            if (_cleanHistory)
            {
                history.Clear();
            }
        }


    }
}
