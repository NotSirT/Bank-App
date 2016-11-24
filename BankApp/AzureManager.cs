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
        private IMobileServiceTable<Staff> Staff_Table;

        private AzureManager()
        {
            this.client = new MobileServiceClient("http://ctsbb.azurewebsites.net");
            this.Branch_Tables = this.client.GetTable<Branch_Tables>();
            this.Staff_Table = this.client.GetTable<Staff>();
        }

        public async Task<List<Branch_Tables>> GetBranch()
        {
            return await this.Branch_Tables.ToListAsync();
        }
        public async Task<List<Staff>> GetStaff()
        {
            return await this.Staff_Table.ToListAsync();
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