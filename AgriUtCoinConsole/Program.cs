using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Threading.Tasks;

namespace AgriUtCoinConsole
{
    class Program
    {   
        const string url = "http://localhost:8545"; //blockchain network url
        const string privateKey = "0x35f3863b27575ff99d0055c9d98d1d6e0c6c03f613b6d13b03aee81352f1ce71"; //the account's private key

        static public string m_contractAddress = ""; //address of smart contract depolyed.

        static void Main(string[] args)
        {
            var account = new Account(privateKey);
            var web3 = new Web3(account, url);
            GetContractAddress(web3).Wait();

            var userWallet = new UserWallet(url, @"Wallets");
            userWallet.SetContractAddress(m_contractAddress);

            userWallet.MainAsync(args).Wait();
        }

        /**
        * @desc getting address of deployed smart contract
        */
        private static async Task GetContractAddress(Web3 web3)
        {
            var interfaceAgriUt = new InterfaceAgriUtCoin();
            m_contractAddress = await interfaceAgriUt.DeploymentContract(web3, "test","T");
            Console.WriteLine($"Contract Deployment Tx Status: {m_contractAddress}");
        }
    }
}
