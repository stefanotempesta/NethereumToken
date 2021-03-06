using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace SmartContracts.Contracts.AgriUtCoin.ContractDefinition
{


    public partial class AgriUtCoinDeployment : AgriUtCoinDeploymentBase
    {
        public AgriUtCoinDeployment() : base(BYTECODE) { }
        public AgriUtCoinDeployment(string byteCode) : base(byteCode) { }
    }

    public class AgriUtCoinDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060408190526003805460ff19166012179055620013c038819003908190833981016040819052620000329162000218565b600080546001600160a01b031916331790556003548390839083906200005d9060ff16600a620002d5565b620000699084620003a0565b6004819055336000908152600560209081526040909120919091558251620000989160019190850190620000bb565b508051620000ae906002906020840190620000bb565b505050505050506200042b565b828054620000c990620003c2565b90600052602060002090601f016020900481019282620000ed576000855562000138565b82601f106200010857805160ff191683800117855562000138565b8280016001018555821562000138579182015b82811115620001385782518255916020019190600101906200011b565b50620001469291506200014a565b5090565b5b808211156200014657600081556001016200014b565b600082601f8301126200017357600080fd5b81516001600160401b038082111562000190576200019062000415565b604051601f8301601f19908116603f01168101908282118183101715620001bb57620001bb62000415565b81604052838152602092508683858801011115620001d857600080fd5b600091505b83821015620001fc5785820183015181830184015290820190620001dd565b838211156200020e5760008385830101525b9695505050505050565b6000806000606084860312156200022e57600080fd5b835160208501519093506001600160401b03808211156200024e57600080fd5b6200025c8783880162000161565b935060408601519150808211156200027357600080fd5b50620002828682870162000161565b9150509250925092565b600181815b80851115620002cd578160001904821115620002b157620002b1620003ff565b80851615620002bf57918102915b93841c939080029062000291565b509250929050565b6000620002e38383620002ea565b9392505050565b600082620002fb575060016200039a565b816200030a575060006200039a565b81600181146200032357600281146200032e576200034e565b60019150506200039a565b60ff841115620003425762000342620003ff565b50506001821b6200039a565b5060208310610133831016604e8410600b841016171562000373575081810a6200039a565b6200037f83836200028c565b8060001904821115620003965762000396620003ff565b0290505b92915050565b6000816000190483118215151615620003bd57620003bd620003ff565b500290565b600181811c90821680620003d757607f821691505b60208210811415620003f957634e487b7160e01b600052602260045260246000fd5b50919050565b634e487b7160e01b600052601160045260246000fd5b634e487b7160e01b600052604160045260246000fd5b610f85806200043b6000396000f3fe6080604052600436106101355760003560e01c80638da5cb5b116100ab578063cae9ca511161006f578063cae9ca5114610358578063dd62ed3e14610378578063e3d670d7146103b0578063e4849b32146103dd578063e724529c146103fd578063f2fde38b1461041d57600080fd5b80638da5cb5b146102b357806395d89b41146102eb578063a6f2ae3a14610300578063a9059cbb14610308578063b414d4b61461032857600080fd5b8063313ce567116100fd578063313ce567146101fb57806342966c68146102275780634b7503341461024757806379c650681461025d57806379cc67901461027d5780638620410b1461029d57600080fd5b806305fefda71461013a57806306fdde031461015c578063095ea7b31461018757806318160ddd146101b757806323b872dd146101db575b600080fd5b34801561014657600080fd5b5061015a610155366004610db9565b61043d565b005b34801561016857600080fd5b5061017161045f565b60405161017e9190610e65565b60405180910390f35b34801561019357600080fd5b506101a76101a2366004610cab565b6104ed565b604051901515815260200161017e565b3480156101c357600080fd5b506101cd60045481565b60405190815260200161017e565b3480156101e757600080fd5b506101a76101f6366004610c33565b610559565b34801561020757600080fd5b506003546102159060ff1681565b60405160ff909116815260200161017e565b34801561023357600080fd5b506101a7610242366004610da0565b6105d8565b34801561025357600080fd5b506101cd60075481565b34801561026957600080fd5b5061015a610278366004610cab565b61066e565b34801561028957600080fd5b506101a7610298366004610cab565b610747565b3480156102a957600080fd5b506101cd60085481565b3480156102bf57600080fd5b506000546102d3906001600160a01b031681565b6040516001600160a01b03909116815260200161017e565b3480156102f757600080fd5b50610171610861565b61015a61086e565b34801561031457600080fd5b506101a7610323366004610cab565b61089c565b34801561033457600080fd5b506101a7610343366004610be5565b60096020526000908152604090205460ff1681565b34801561036457600080fd5b506101a7610373366004610cd5565b6108b2565b34801561038457600080fd5b506101cd610393366004610c00565b600660209081526000928352604080842090915290825290205481565b3480156103bc57600080fd5b506101cd6103cb366004610be5565b60056020526000908152604090205481565b3480156103e957600080fd5b5061015a6103f8366004610da0565b61093a565b34801561040957600080fd5b5061015a610418366004610c6f565b6109b6565b34801561042957600080fd5b5061015a610438366004610be5565b610a30565b6000546001600160a01b0316331461045457600080fd5b600791909155600855565b6001805461046c90610ee8565b80601f016020809104026020016040519081016040528092919081815260200182805461049890610ee8565b80156104e55780601f106104ba576101008083540402835291602001916104e5565b820191906000526020600020905b8154815290600101906020018083116104c857829003601f168201915b505050505081565b3360008181526006602090815260408083206001600160a01b038716808552925280832085905551919290917f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925906105489086815260200190565b60405180910390a350600192915050565b6001600160a01b038316600090815260066020908152604080832033845290915281205482111561058957600080fd5b6001600160a01b0384166000908152600660209081526040808320338452909152812080548492906105bc908490610ed1565b909155506105cd9050848484610a69565b5060015b9392505050565b336000908152600560205260408120548211156105f457600080fd5b3360009081526005602052604081208054849290610613908490610ed1565b92505081905550816004600082825461062c9190610ed1565b909155505060405182815233907fcc16f5dbb4873280815c1ee09dbd06736cffcc184412cf7a71a0fdb75d397ca59060200160405180910390a2506001919050565b6000546001600160a01b0316331461068557600080fd5b6001600160a01b038216600090815260056020526040812080548392906106ad908490610e78565b9250508190555080600460008282546106c69190610e78565b909155505060405181815230906000907fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef9060200160405180910390a36040518181526001600160a01b0383169030907fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef9060200160405180910390a35050565b6001600160a01b03821660009081526005602052604081205482111561076c57600080fd5b6001600160a01b038316600090815260066020908152604080832033845290915290205482111561079c57600080fd5b6001600160a01b038316600090815260056020526040812080548492906107c4908490610ed1565b90915550506001600160a01b0383166000908152600660209081526040808320338452909152812080548492906107fc908490610ed1565b9250508190555081600460008282546108159190610ed1565b90915550506040518281526001600160a01b038416907fcc16f5dbb4873280815c1ee09dbd06736cffcc184412cf7a71a0fdb75d397ca59060200160405180910390a250600192915050565b6002805461046c90610ee8565b60006008543461087e9190610e90565b6000549091506108999030906001600160a01b031683610a69565b50565b60006108a9338484610a69565b50600192915050565b6000836108bf81856104ed565b1561093257604051638f4ffcb160e01b81526001600160a01b03821690638f4ffcb1906108f6903390889030908990600401610e28565b600060405180830381600087803b15801561091057600080fd5b505af1158015610924573d6000803e3d6000fd5b5050505060019150506105d1565b509392505050565b6007546109479082610eb2565b47101561095357600080fd5b60005461096a906001600160a01b03163083610a69565b6000546007546001600160a01b03909116906108fc9061098a9084610eb2565b6040518115909202916000818181858888f193505050501580156109b2573d6000803e3d6000fd5b5050565b6000546001600160a01b031633146109cd57600080fd5b6001600160a01b038216600081815260096020908152604091829020805460ff19168515159081179091558251938452908301527f48335238b4855f35377ed80f164e8c6f3c366e54ac00b96a6402d4a9814a03a5910160405180910390a15050565b6000546001600160a01b03163314610a4757600080fd5b600080546001600160a01b0319166001600160a01b0392909216919091179055565b6001600160a01b038216610a7c57600080fd5b6001600160a01b038316600090815260056020526040902054811115610aa157600080fd5b6001600160a01b038216600090815260056020526040902054610ac48282610e78565b1015610acf57600080fd5b6001600160a01b03831660009081526009602052604090205460ff1615610af557600080fd5b6001600160a01b03821660009081526009602052604090205460ff1615610b1b57600080fd5b6001600160a01b03831660009081526005602052604081208054839290610b43908490610ed1565b90915550506001600160a01b03821660009081526005602052604081208054839290610b70908490610e78565b92505081905550816001600160a01b0316836001600160a01b03167fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef83604051610bbc91815260200190565b60405180910390a3505050565b80356001600160a01b0381168114610be057600080fd5b919050565b600060208284031215610bf757600080fd5b6105d182610bc9565b60008060408385031215610c1357600080fd5b610c1c83610bc9565b9150610c2a60208401610bc9565b90509250929050565b600080600060608486031215610c4857600080fd5b610c5184610bc9565b9250610c5f60208501610bc9565b9150604084013590509250925092565b60008060408385031215610c8257600080fd5b610c8b83610bc9565b915060208301358015158114610ca057600080fd5b809150509250929050565b60008060408385031215610cbe57600080fd5b610cc783610bc9565b946020939093013593505050565b600080600060608486031215610cea57600080fd5b610cf384610bc9565b925060208401359150604084013567ffffffffffffffff80821115610d1757600080fd5b818601915086601f830112610d2b57600080fd5b813581811115610d3d57610d3d610f39565b604051601f8201601f19908116603f01168101908382118183101715610d6557610d65610f39565b81604052828152896020848701011115610d7e57600080fd5b8260208601602083013760006020848301015280955050505050509250925092565b600060208284031215610db257600080fd5b5035919050565b60008060408385031215610dcc57600080fd5b50508035926020909101359150565b6000815180845260005b81811015610e0157602081850181015186830182015201610de5565b81811115610e13576000602083870101525b50601f01601f19169290920160200192915050565b6001600160a01b0385811682526020820185905283166040820152608060608201819052600090610e5b90830184610ddb565b9695505050505050565b6020815260006105d16020830184610ddb565b60008219821115610e8b57610e8b610f23565b500190565b600082610ead57634e487b7160e01b600052601260045260246000fd5b500490565b6000816000190483118215151615610ecc57610ecc610f23565b500290565b600082821015610ee357610ee3610f23565b500390565b600181811c90821680610efc57607f821691505b60208210811415610f1d57634e487b7160e01b600052602260045260246000fd5b50919050565b634e487b7160e01b600052601160045260246000fd5b634e487b7160e01b600052604160045260246000fdfea2646970667358221220b839e082d51c91eb1c2895862df00dd397895be0bc92a61c04527aef344defbf64736f6c63430008060033";
        public AgriUtCoinDeploymentBase() : base(BYTECODE) { }
        public AgriUtCoinDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("uint256", "initialSupply", 1)]
        public virtual BigInteger InitialSupply { get; set; }
        [Parameter("string", "tokenName", 2)]
        public virtual string TokenName { get; set; }
        [Parameter("string", "tokenSymbol", 3)]
        public virtual string TokenSymbol { get; set; }
    }

    public partial class AllowanceFunction : AllowanceFunctionBase { }

    [Function("allowance", "uint256")]
    public class AllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
        [Parameter("address", "", 2)]
        public virtual string ReturnValue2 { get; set; }
    }

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve", "bool")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "_spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "_value", 2)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class ApproveAndCallFunction : ApproveAndCallFunctionBase { }

    [Function("approveAndCall", "bool")]
    public class ApproveAndCallFunctionBase : FunctionMessage
    {
        [Parameter("address", "_spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "_value", 2)]
        public virtual BigInteger Value { get; set; }
        [Parameter("bytes", "_extraData", 3)]
        public virtual byte[] ExtraData { get; set; }
    }

    public partial class BalanceFunction : BalanceFunctionBase { }

    [Function("balance", "uint256")]
    public class BalanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class BurnFunction : BurnFunctionBase { }

    [Function("burn", "bool")]
    public class BurnFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_value", 1)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class BurnFromFunction : BurnFromFunctionBase { }

    [Function("burnFrom", "bool")]
    public class BurnFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "_from", 1)]
        public virtual string From { get; set; }
        [Parameter("uint256", "_value", 2)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class BuyFunction : BuyFunctionBase { }

    [Function("buy")]
    public class BuyFunctionBase : FunctionMessage
    {

    }

    public partial class BuyPriceFunction : BuyPriceFunctionBase { }

    [Function("buyPrice", "uint256")]
    public class BuyPriceFunctionBase : FunctionMessage
    {

    }

    public partial class DecimalsFunction : DecimalsFunctionBase { }

    [Function("decimals", "uint8")]
    public class DecimalsFunctionBase : FunctionMessage
    {

    }

    public partial class FreezeAccountFunction : FreezeAccountFunctionBase { }

    [Function("freezeAccount")]
    public class FreezeAccountFunctionBase : FunctionMessage
    {
        [Parameter("address", "target", 1)]
        public virtual string Target { get; set; }
        [Parameter("bool", "freeze", 2)]
        public virtual bool Freeze { get; set; }
    }

    public partial class FrozenAccountFunction : FrozenAccountFunctionBase { }

    [Function("frozenAccount", "bool")]
    public class FrozenAccountFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class MintTokenFunction : MintTokenFunctionBase { }

    [Function("mintToken")]
    public class MintTokenFunctionBase : FunctionMessage
    {
        [Parameter("address", "target", 1)]
        public virtual string Target { get; set; }
        [Parameter("uint256", "mintedAmount", 2)]
        public virtual BigInteger MintedAmount { get; set; }
    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class SellFunction : SellFunctionBase { }

    [Function("sell")]
    public class SellFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class SellPriceFunction : SellPriceFunctionBase { }

    [Function("sellPrice", "uint256")]
    public class SellPriceFunctionBase : FunctionMessage
    {

    }

    public partial class SetPricesFunction : SetPricesFunctionBase { }

    [Function("setPrices")]
    public class SetPricesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newSellPrice", 1)]
        public virtual BigInteger NewSellPrice { get; set; }
        [Parameter("uint256", "newBuyPrice", 2)]
        public virtual BigInteger NewBuyPrice { get; set; }
    }

    public partial class SymbolFunction : SymbolFunctionBase { }

    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
    {

    }

    public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }

    [Function("totalSupply", "uint256")]
    public class TotalSupplyFunctionBase : FunctionMessage
    {

    }

    public partial class TransferFunction : TransferFunctionBase { }

    [Function("transfer", "bool")]
    public class TransferFunctionBase : FunctionMessage
    {
        [Parameter("address", "_to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "_value", 2)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom", "bool")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "_from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "_to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "_value", 3)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "_owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "_spender", 2, true )]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "_value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class BurnEventDTO : BurnEventDTOBase { }

    [Event("Burn")]
    public class BurnEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("uint256", "value", 2, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class FrozenFundsEventDTO : FrozenFundsEventDTOBase { }

    [Event("FrozenFunds")]
    public class FrozenFundsEventDTOBase : IEventDTO
    {
        [Parameter("address", "target", 1, false )]
        public virtual string Target { get; set; }
        [Parameter("bool", "frozen", 2, false )]
        public virtual bool Frozen { get; set; }
    }

    public partial class TransferEventDTO : TransferEventDTOBase { }

    [Event("Transfer")]
    public class TransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class AllowanceOutputDTO : AllowanceOutputDTOBase { }

    [FunctionOutput]
    public class AllowanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }





    public partial class BalanceOutputDTO : BalanceOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }







    public partial class BuyPriceOutputDTO : BuyPriceOutputDTOBase { }

    [FunctionOutput]
    public class BuyPriceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class DecimalsOutputDTO : DecimalsOutputDTOBase { }

    [FunctionOutput]
    public class DecimalsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }



    public partial class FrozenAccountOutputDTO : FrozenAccountOutputDTOBase { }

    [FunctionOutput]
    public class FrozenAccountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }



    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class SellPriceOutputDTO : SellPriceOutputDTOBase { }

    [FunctionOutput]
    public class SellPriceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

    [FunctionOutput]
    public class SymbolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TotalSupplyOutputDTO : TotalSupplyOutputDTOBase { }

    [FunctionOutput]
    public class TotalSupplyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }






}
