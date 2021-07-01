using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using SmartContracts.Contracts.AgriUtCoin.ContractDefinition;

namespace SmartContracts.Contracts.AgriUtCoin
{
    public partial class AgriUtCoinService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, AgriUtCoinDeployment agriUtCoinDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<AgriUtCoinDeployment>().SendRequestAndWaitForReceiptAsync(agriUtCoinDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, AgriUtCoinDeployment agriUtCoinDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<AgriUtCoinDeployment>().SendRequestAsync(agriUtCoinDeployment);
        }

        public static async Task<AgriUtCoinService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, AgriUtCoinDeployment agriUtCoinDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, agriUtCoinDeployment, cancellationTokenSource);
            return new AgriUtCoinService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public AgriUtCoinService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> AllowanceQueryAsync(AllowanceFunction allowanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
        }

        
        public Task<BigInteger> AllowanceQueryAsync(string returnValue1, string returnValue2, BlockParameter blockParameter = null)
        {
            var allowanceFunction = new AllowanceFunction();
                allowanceFunction.ReturnValue1 = returnValue1;
                allowanceFunction.ReturnValue2 = returnValue2;
            
            return ContractHandler.QueryAsync<AllowanceFunction, BigInteger>(allowanceFunction, blockParameter);
        }

        public Task<string> ApproveRequestAsync(ApproveFunction approveFunction)
        {
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(ApproveFunction approveFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(string spender, BigInteger value)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.Spender = spender;
                approveFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string spender, BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.Spender = spender;
                approveFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> ApproveAndCallRequestAsync(ApproveAndCallFunction approveAndCallFunction)
        {
             return ContractHandler.SendRequestAsync(approveAndCallFunction);
        }

        public Task<TransactionReceipt> ApproveAndCallRequestAndWaitForReceiptAsync(ApproveAndCallFunction approveAndCallFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveAndCallFunction, cancellationToken);
        }

        public Task<string> ApproveAndCallRequestAsync(string spender, BigInteger value, byte[] extraData)
        {
            var approveAndCallFunction = new ApproveAndCallFunction();
                approveAndCallFunction.Spender = spender;
                approveAndCallFunction.Value = value;
                approveAndCallFunction.ExtraData = extraData;
            
             return ContractHandler.SendRequestAsync(approveAndCallFunction);
        }

        public Task<TransactionReceipt> ApproveAndCallRequestAndWaitForReceiptAsync(string spender, BigInteger value, byte[] extraData, CancellationTokenSource cancellationToken = null)
        {
            var approveAndCallFunction = new ApproveAndCallFunction();
                approveAndCallFunction.Spender = spender;
                approveAndCallFunction.Value = value;
                approveAndCallFunction.ExtraData = extraData;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveAndCallFunction, cancellationToken);
        }

        public Task<BigInteger> BalanceQueryAsync(BalanceFunction balanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceFunction, BigInteger>(balanceFunction, blockParameter);
        }

        
        public Task<BigInteger> BalanceQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var balanceFunction = new BalanceFunction();
                balanceFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<BalanceFunction, BigInteger>(balanceFunction, blockParameter);
        }

        public Task<string> BurnRequestAsync(BurnFunction burnFunction)
        {
             return ContractHandler.SendRequestAsync(burnFunction);
        }

        public Task<TransactionReceipt> BurnRequestAndWaitForReceiptAsync(BurnFunction burnFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFunction, cancellationToken);
        }

        public Task<string> BurnRequestAsync(BigInteger value)
        {
            var burnFunction = new BurnFunction();
                burnFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(burnFunction);
        }

        public Task<TransactionReceipt> BurnRequestAndWaitForReceiptAsync(BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var burnFunction = new BurnFunction();
                burnFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFunction, cancellationToken);
        }

        public Task<string> BurnFromRequestAsync(BurnFromFunction burnFromFunction)
        {
             return ContractHandler.SendRequestAsync(burnFromFunction);
        }

        public Task<TransactionReceipt> BurnFromRequestAndWaitForReceiptAsync(BurnFromFunction burnFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFromFunction, cancellationToken);
        }

        public Task<string> BurnFromRequestAsync(string from, BigInteger value)
        {
            var burnFromFunction = new BurnFromFunction();
                burnFromFunction.From = from;
                burnFromFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(burnFromFunction);
        }

        public Task<TransactionReceipt> BurnFromRequestAndWaitForReceiptAsync(string from, BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var burnFromFunction = new BurnFromFunction();
                burnFromFunction.From = from;
                burnFromFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFromFunction, cancellationToken);
        }

        public Task<string> BuyRequestAsync(BuyFunction buyFunction)
        {
             return ContractHandler.SendRequestAsync(buyFunction);
        }

        public Task<string> BuyRequestAsync()
        {
             return ContractHandler.SendRequestAsync<BuyFunction>();
        }

        public Task<TransactionReceipt> BuyRequestAndWaitForReceiptAsync(BuyFunction buyFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(buyFunction, cancellationToken);
        }

        public Task<TransactionReceipt> BuyRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<BuyFunction>(null, cancellationToken);
        }

        public Task<BigInteger> BuyPriceQueryAsync(BuyPriceFunction buyPriceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BuyPriceFunction, BigInteger>(buyPriceFunction, blockParameter);
        }

        
        public Task<BigInteger> BuyPriceQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BuyPriceFunction, BigInteger>(null, blockParameter);
        }

        public Task<byte> DecimalsQueryAsync(DecimalsFunction decimalsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DecimalsFunction, byte>(decimalsFunction, blockParameter);
        }

        
        public Task<byte> DecimalsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DecimalsFunction, byte>(null, blockParameter);
        }

        public Task<string> FreezeAccountRequestAsync(FreezeAccountFunction freezeAccountFunction)
        {
             return ContractHandler.SendRequestAsync(freezeAccountFunction);
        }

        public Task<TransactionReceipt> FreezeAccountRequestAndWaitForReceiptAsync(FreezeAccountFunction freezeAccountFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(freezeAccountFunction, cancellationToken);
        }

        public Task<string> FreezeAccountRequestAsync(string target, bool freeze)
        {
            var freezeAccountFunction = new FreezeAccountFunction();
                freezeAccountFunction.Target = target;
                freezeAccountFunction.Freeze = freeze;
            
             return ContractHandler.SendRequestAsync(freezeAccountFunction);
        }

        public Task<TransactionReceipt> FreezeAccountRequestAndWaitForReceiptAsync(string target, bool freeze, CancellationTokenSource cancellationToken = null)
        {
            var freezeAccountFunction = new FreezeAccountFunction();
                freezeAccountFunction.Target = target;
                freezeAccountFunction.Freeze = freeze;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(freezeAccountFunction, cancellationToken);
        }

        public Task<bool> FrozenAccountQueryAsync(FrozenAccountFunction frozenAccountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FrozenAccountFunction, bool>(frozenAccountFunction, blockParameter);
        }

        
        public Task<bool> FrozenAccountQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var frozenAccountFunction = new FrozenAccountFunction();
                frozenAccountFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<FrozenAccountFunction, bool>(frozenAccountFunction, blockParameter);
        }

        public Task<string> MintTokenRequestAsync(MintTokenFunction mintTokenFunction)
        {
             return ContractHandler.SendRequestAsync(mintTokenFunction);
        }

        public Task<TransactionReceipt> MintTokenRequestAndWaitForReceiptAsync(MintTokenFunction mintTokenFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintTokenFunction, cancellationToken);
        }

        public Task<string> MintTokenRequestAsync(string target, BigInteger mintedAmount)
        {
            var mintTokenFunction = new MintTokenFunction();
                mintTokenFunction.Target = target;
                mintTokenFunction.MintedAmount = mintedAmount;
            
             return ContractHandler.SendRequestAsync(mintTokenFunction);
        }

        public Task<TransactionReceipt> MintTokenRequestAndWaitForReceiptAsync(string target, BigInteger mintedAmount, CancellationTokenSource cancellationToken = null)
        {
            var mintTokenFunction = new MintTokenFunction();
                mintTokenFunction.Target = target;
                mintTokenFunction.MintedAmount = mintedAmount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintTokenFunction, cancellationToken);
        }

        public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> SellRequestAsync(SellFunction sellFunction)
        {
             return ContractHandler.SendRequestAsync(sellFunction);
        }

        public Task<TransactionReceipt> SellRequestAndWaitForReceiptAsync(SellFunction sellFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(sellFunction, cancellationToken);
        }

        public Task<string> SellRequestAsync(BigInteger amount)
        {
            var sellFunction = new SellFunction();
                sellFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(sellFunction);
        }

        public Task<TransactionReceipt> SellRequestAndWaitForReceiptAsync(BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var sellFunction = new SellFunction();
                sellFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(sellFunction, cancellationToken);
        }

        public Task<BigInteger> SellPriceQueryAsync(SellPriceFunction sellPriceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SellPriceFunction, BigInteger>(sellPriceFunction, blockParameter);
        }

        
        public Task<BigInteger> SellPriceQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SellPriceFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> SetPricesRequestAsync(SetPricesFunction setPricesFunction)
        {
             return ContractHandler.SendRequestAsync(setPricesFunction);
        }

        public Task<TransactionReceipt> SetPricesRequestAndWaitForReceiptAsync(SetPricesFunction setPricesFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPricesFunction, cancellationToken);
        }

        public Task<string> SetPricesRequestAsync(BigInteger newSellPrice, BigInteger newBuyPrice)
        {
            var setPricesFunction = new SetPricesFunction();
                setPricesFunction.NewSellPrice = newSellPrice;
                setPricesFunction.NewBuyPrice = newBuyPrice;
            
             return ContractHandler.SendRequestAsync(setPricesFunction);
        }

        public Task<TransactionReceipt> SetPricesRequestAndWaitForReceiptAsync(BigInteger newSellPrice, BigInteger newBuyPrice, CancellationTokenSource cancellationToken = null)
        {
            var setPricesFunction = new SetPricesFunction();
                setPricesFunction.NewSellPrice = newSellPrice;
                setPricesFunction.NewBuyPrice = newBuyPrice;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPricesFunction, cancellationToken);
        }

        public Task<string> SymbolQueryAsync(SymbolFunction symbolFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(symbolFunction, blockParameter);
        }

        
        public Task<string> SymbolQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> TotalSupplyQueryAsync(TotalSupplyFunction totalSupplyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(totalSupplyFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalSupplyQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> TransferRequestAsync(TransferFunction transferFunction)
        {
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(TransferFunction transferFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> TransferRequestAsync(string to, BigInteger value)
        {
            var transferFunction = new TransferFunction();
                transferFunction.To = to;
                transferFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(transferFunction);
        }

        public Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(string to, BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var transferFunction = new TransferFunction();
                transferFunction.To = to;
                transferFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(TransferFromFunction transferFromFunction)
        {
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFromFunction transferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(string from, string to, BigInteger value)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(TransferOwnershipFunction transferOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(TransferOwnershipFunction transferOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(string newOwner)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(string newOwner, CancellationTokenSource cancellationToken = null)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }
    }
}
