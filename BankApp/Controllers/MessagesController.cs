using System;
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

                //x = await client.GetStringAsync(new Uri("http://api.fixer.io/latest?base=NZD"));

                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                // calculate something for us to return
                int length = (activity.Text ?? string.Empty).Length;


                var userMessage = activity.Text;

                

                string endOutput = "Hello";

                //MobileServiceClient client = AzureManager.AzureManagerInstance.AzureClient;


                if (userMessage.ToLower().Equals("branch"))
                {
                    List<Branch_Tables> Branch = await AzureManager.AzureManagerInstance.GetBranch();
                    endOutput = "";
                    foreach (Branch_Tables t in Branch)
                    {
                        endOutput += "Location: " + t.Location;
                        /*"[" + t.Date + "] Happiness " + t.Happiness + ", Sadness " + t.Sadness + "\n\n";*/
                    }

                }

                if (userMessage.ToLower().Equals("staff"))
                {
                    List<Staff> Staff = await AzureManager.AzureManagerInstance.GetStaff();
                    endOutput = "";
                    foreach (Staff t in Staff)
                    {
                        endOutput += "Name: " + t.Name;
                        /*"[" + t.Date + "] Happiness " + t.Happiness + ", Sadness " + t.Sadness + "\n\n";*/
                    }

                }

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