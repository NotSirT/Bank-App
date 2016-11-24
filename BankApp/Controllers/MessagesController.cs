﻿using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.MobileServices;
using BankApp.Model;
using System.Collections.Generic;

namespace BankApp
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {

                HttpClient client = new HttpClient();
                string x = await client.GetStringAsync(new Uri("http://api.fixer.io/latest?base=NZD"));
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));

                // calculate something for us to return
                int length = (activity.Text ?? string.Empty).Length;

                var userMessage = activity.Text;

                // message output is set to this on default 
                string endOutput = "Hello, welcome to Contoso, \n\n type 'help' to return a list of our features";

                

                if (userMessage.ToLower().Equals("branches"))
                {
                    List<Branch_Tables> branch = await AzureManager.AzureManagerInstance.GetBranch();
                    endOutput = "";
                    foreach (Branch_Tables t in branch)
                    {
                        endOutput += "Location: " + t.Location + "\n\n";
                    }

                }

                //checks if message is "exchange rates" and then returns the exchange rates against the NZD in a card
                if (userMessage.ToLower().Equals("exchange rates"))
                {
                    CurrencyObject.RootObject rootObject;

                    rootObject = JsonConvert.DeserializeObject<CurrencyObject.RootObject>(x);

                    string AUD = rootObject.rates.AUD;
                    string GBP = rootObject.rates.GBP;
                    string EUR = rootObject.rates.EUR;
                    string JPY = rootObject.rates.JPY;
                    string USD = rootObject.rates.USD;

                    Activity replyToConversation = activity.CreateReply("Popular Contoso Exchange Rates");
                    replyToConversation.Recipient = activity.From;
                    replyToConversation.Type = "message";
                    replyToConversation.Attachments = new List<Attachment>();

                    List<CardImage> cardImages = new List<CardImage>();
                    cardImages.Add(new CardImage(url: "http://vignette1.wikia.nocookie.net/mobius-paradox/images/6/68/Contoso_logo.jpg/revision/latest?cb=20150621174845"));

                    List<CardAction> cardButtons = new List<CardAction>();
                 
                    ThumbnailCard plCard = new ThumbnailCard()
                    {
                        Title = "The exchange rate for NZD: ",
                        Subtitle = ($"AUD: {AUD}          \n\n GBP: {GBP} \n\n EUR: {EUR} \n\n  JPY:{JPY} \n\n USD: {USD}"),
                        Images = cardImages,
                        Buttons = cardButtons
                    };

                    Attachment plAttachment = plCard.ToAttachment();
                    replyToConversation.Attachments.Add(plAttachment);
                    await connector.Conversations.SendToConversationAsync(replyToConversation);

                    return Request.CreateResponse(HttpStatusCode.OK);

                }

                /*------------------------------*/

                //checks if message is "staff" and then returns the staff in the database

                if (userMessage.ToLower().Equals("staff"))
                {
                    List<Staff> staff = await AzureManager.AzureManagerInstance.GetStaff();
                    endOutput = "";
                    foreach (Staff t in staff)
                    {
                        endOutput += "Staff Names: \n\n " + t.Name + "\n\n";
                    }

                }
                
                //return reply to user
                Activity reply = activity.CreateReply(endOutput);
                await connector.Conversations.ReplyToActivityAsync(reply);

            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}