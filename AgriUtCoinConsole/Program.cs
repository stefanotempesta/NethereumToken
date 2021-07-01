using SmartContracts.Contracts.AgriUtCoin;
using SmartContracts.Contracts.AgriUtCoin.ContractDefinition;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexTypes;
using System;
using System.Threading.Tasks;

namespace AgriUtCoinConsole
{
    /**
    * @desc buy and sell token class
    */
    class Program
    {   
        const string url = "http://localhost:8545";
        const string privateKey = "0x35f3863b27575ff99d0055c9d98d1d6e0c6c03f613b6d13b03aee81352f1ce71";

        static public string m_contractAddress = "";

        static void Main(string[] args)
        {
            Web3 web3 = SetWeb3(privateKey, url);
            DeploymentContract(web3).Wait();
            SetPrice(web3, m_contractAddress, 10, 10).Wait();
            MintToken(web3, m_contractAddress, m_contractAddress, 10000).Wait();
            Buy(web3, m_contractAddress, 10).Wait();
            Sell(web3, m_contractAddress, 10).Wait();
            Console.ReadLine();
        }

        /** 
        * @desc set Web3
        * @param privateKey, url
        * @return Web3
        */
        static public Web3 SetWeb3(string privateKey, string url)
        {
            var account = new Account(privateKey);
            Web3 web3 = new Web3(account, url);
            return web3;
        }
        /**
        * @desc deployment contract
        * @param Web3
        * @return void
        */
        static public async Task DeploymentContract(Web3 web3)
        {
            try {
                Console.WriteLine("Deploying...");
                var deployment = new AgriUtCoinDeployment
                {
                    InitialSupply = new HexBigInteger(10000),
                    TokenName = "Test",
                    TokenSymbol = "T",
                };
                var receipt = await AgriUtCoinService.DeployContractAndWaitForReceiptAsync(web3, deployment);
                m_contractAddress = receipt.ContractAddress;
                var service = new AgriUtCoinService(web3, receipt.ContractAddress);
                
                Console.WriteLine($"Contract Deployment Tx Status: {receipt.Status.Value}");
                Console.WriteLine($"Contract Address: {service.ContractHandler.ContractAddress}");
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        /**
        * @desc set buying price and selling price
        * @param: web3, contract address, sellprice, buyprice
        */
        static public async Task SetPrice(Web3 web3, string contractAddress, long sellPrice, long buyprice)
        {
            try {
                Console.WriteLine("Set Buy and Sell price");
                var service = new AgriUtCoinService(web3, contractAddress);
                var receiptForSetPrice = await service.SetPricesRequestAndWaitForReceiptAsync(new SetPricesFunction(){NewSellPrice = sellPrice, NewBuyPrice = buyprice, Gas = 500000 });
                Console.WriteLine($"Finished Setting Price: Tx Hash: {receiptForSetPrice.TransactionHash}");
                Console.WriteLine($"Finished Setting Price: Tx Status: {receiptForSetPrice.Status.Value}");
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
        /**
        * @desc buy
        * @param: web3, contract address, amount
        */
        static public async Task Buy(Web3 web3, string contractAddress, long amount)
        {
            try{
                Console.WriteLine("Buying");
                
                var service = new AgriUtCoinService(web3, contractAddress);
                var receiptForBuy = await service.BuyRequestAndWaitForReceiptAsync(new BuyFunction(){Gas = 500000, AmountToSend = amount});
                Console.WriteLine($"Finished buying Tx Hash: {receiptForBuy.TransactionHash}");
                Console.WriteLine($"Finished buying: Tx Status: {receiptForBuy.Status.Value}");
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
        /**
        * @desc Sell
        * @param: web3, contract address, amount
        */
        static public async Task Sell(Web3 web3, string contractAddress, long amount)
        {
            try{
                Console.WriteLine("Selling");
                var service = new AgriUtCoinService(web3, contractAddress);
                var receiptForSell = await service.SellRequestAndWaitForReceiptAsync(new SellFunction(){ Amount = amount, Gas = 500000 });
                Console.WriteLine($"Finished buying Tx Hash: {receiptForSell.TransactionHash}");
                Console.WriteLine($"Finished buying: Tx Status: {receiptForSell.Status.Value}");
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
        /**
        * @desc Mint
        * @param: web3, contract address, target address, amount
        */
        static public async Task MintToken(Web3 web3, string contractAddress, string targetAddress, long amount)
        {
            try{
                Console.WriteLine("Minting");
                var service = new AgriUtCoinService(web3, contractAddress);
                var receiptForMint = await service.MintTokenRequestAndWaitForReceiptAsync(new MintTokenFunction(){ Target = targetAddress, MintedAmount = amount, Gas = 500000 });
                Console.WriteLine($"Finished buying Tx Hash: {receiptForMint.TransactionHash}");
                Console.WriteLine($"Finished buying: Tx Status: {receiptForMint.Status.Value}");
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
