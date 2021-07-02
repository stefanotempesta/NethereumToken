using SmartContracts.Contracts.AgriUtCoin;
using SmartContracts.Contracts.AgriUtCoin.ContractDefinition;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Hex.HexTypes;
using System;
using System.Threading.Tasks;
using System.Numerics;

namespace AgriUtCoinConsole
{
    /**
    * @desc buy and sell token class
    */
    class InterfaceAgriUtCoin
    {   
        /**
        * @desc deployment contract
        * @param Web3
        * @return string
        */
        public async Task<string> DeploymentContract(Web3 web3, string strTokenName, string strTokenSymbol)
        {
            try {
                Console.WriteLine("Deploying...");
                var deployment = new AgriUtCoinDeployment
                {
                    InitialSupply = new HexBigInteger(10000),
                    TokenName = strTokenName,
                    TokenSymbol = strTokenSymbol,
                };
                var receipt = await AgriUtCoinService.DeployContractAndWaitForReceiptAsync(web3, deployment);
                                                
                Console.WriteLine($"Contract Deployment Tx Status: {receipt.Status.Value}");

                return receipt.ContractAddress;
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return "";
            }
        }

        /**
        * @desc set buying price and selling price
        * @param: web3, contract address, sellprice, buyprice
        */
        public async Task SetPrice(Web3 web3, string contractAddress, long sellPrice, long buyprice)
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
        public async Task Buy(Web3 web3, string contractAddress, BigInteger amount)
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
        public async Task Sell(Web3 web3, string contractAddress, BigInteger amount)
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
        public async Task MintToken(Web3 web3, string contractAddress, string targetAddress, long amount)
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
        
        /**
        * @desc send coin to toAddress.
        */
        public async Task Send(Web3 web3, string contractAddress, string toAddress, BigInteger amount)
        {
            try {
                Console.WriteLine("Sending");
                var service = new AgriUtCoinService(web3, contractAddress);
                var receiptForSend = await service.TransferRequestAndWaitForReceiptAsync(new TransferFunction(){ To = toAddress, Value = amount, Gas = 500000 });
                Console.WriteLine($"Finished buying Tx Hash: {receiptForSend.TransactionHash}");
                Console.WriteLine($"Finished buying: Tx Status: {receiptForSend.Status.Value}");
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        /**
        * @desc get balance
        */

        public async Task<BigInteger> GetBalance(Web3 web3, string contractAddress, string ownerAddress)
        {
            try {
                Console.WriteLine("Getting Balance");
                var service = new AgriUtCoinService(web3, contractAddress);
                var receiptBalance = await service.BalanceQueryAsync(new BalanceFunction(){ ReturnValue1 = ownerAddress });
                Console.WriteLine($"Balance: {receiptBalance} ");
                Console.WriteLine("");
                return receiptBalance;
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return 0;
            }
        }
    }
}
