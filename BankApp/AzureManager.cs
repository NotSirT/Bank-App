using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.MobileServices;
using BankApp.Model;
using System.Threading.Tasks;

namespace BankApp
{
    public class AzureManager
    {

        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<Branch_Tables> Branch_Tables;

        private AzureManager()
        {
            this.client = new MobileServiceClient("http://witbottest.azurewebsites.net");
            this.Branch_Tables = this.client.GetTable<Branch_Tables>();
         
        }

        public async Task<List<Branch_Tables>> GetBranch()
        {
            return await this.Branch_Tables.ToListAsync();
        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }
         
    }
   
}