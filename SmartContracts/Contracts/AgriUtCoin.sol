// SPDX-License-Identifier: MIT
pragma solidity ^0.8.5;
import "./PayableToken.sol";
import "./TokenERC20.sol";

contract AgriUtCoin is PayableToken, TokenERC20 {
    uint256 public sellPrice;
    uint256 public buyPrice;

    mapping (address => bool) public frozenAccount;

    event FrozenFunds(address target, bool frozen);

    /* Initializes contract with initial supply tokens to the creator of the contract */
    constructor(
        uint256 initialSupply,
        string memory tokenName,
        string memory tokenSymbol
    ) TokenERC20(initialSupply, tokenName, tokenSymbol) payable {}

    /* Internal transfer, only can be called by this contract */
    function _transfer(address _from, address _to, uint _value) override internal {
        require (_to != address(0x0));                      // Prevent transfer to 0x0 address. Use burn() instead
        require (balance[_from] >= _value);                 // Check if the sender has enough
        require (balance[_to] + _value >= balance[_to]);    // Check for overflows
        require(!frozenAccount[_from]);                     // Check if sender is frozen
        require(!frozenAccount[_to]);                       // Check if recipient is frozen
        balance[_from] -= _value;                           // Subtract from the sender
        balance[_to] += _value;                             // Add the same to the recipient
        emit Transfer(_from, _to, _value);
    }

    /// @notice Create mintedAmount tokens and send it to target
    /// @param target Address to receive the tokens
    /// @param mintedAmount the amount of tokens it will receive
    function mintToken(address target, uint256 mintedAmount) onlyOwner public {
        balance[target] += mintedAmount;
        totalSupply += mintedAmount;
        emit Transfer(address(0), address(this), mintedAmount);
        emit Transfer(address(this), target, mintedAmount);
    }

    /// @notice Prevent / allow target from sending and receiving tokens
    /// @param target Address to be frozen
    /// @param freeze either to freeze it or not
    function freezeAccount(address target, bool freeze) onlyOwner public {
        frozenAccount[target] = freeze;
        emit FrozenFunds(target, freeze);
    }

    /// @notice Allow users to buy tokens for newBuyPrice and sell tokens for newSellPrice
    /// @param newSellPrice Price the users can sell to the contract
    /// @param newBuyPrice Price users can buy from the contract
    function setPrices(uint256 newSellPrice, uint256 newBuyPrice) onlyOwner public {
        sellPrice = newSellPrice;
        buyPrice = newBuyPrice;
    }

    /// @notice Buy tokens from contract by sending coin
    function buy() payable public {
        uint amount = msg.value / buyPrice;          // calculates the amount
        _transfer(address(this), owner, amount);     // makes the transfers
    }

    /// @notice Sell amount tokens to contract
    /// @param amount amount of tokens to be sold
    function sell(uint256 amount) public {
        require(address(this).balance >= amount * sellPrice);   // checks if the contract has enough coin to buy
        _transfer(owner, address(this), amount);                // makes the transfers
        owner.transfer(amount * sellPrice);                     // sends coin to the seller. It's important to do this last to avoid recursion attacks
    }
}