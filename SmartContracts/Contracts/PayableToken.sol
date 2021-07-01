// SPDX-License-Identifier: MIT
pragma solidity ^0.8.5;

contract PayableToken {
    address payable public owner;

    constructor() {
        owner = payable(msg.sender);
    }

    modifier onlyOwner {
        require(msg.sender == owner);
        _;
    }

    function transferOwnership(address newOwner) onlyOwner public {
        owner = payable(newOwner);
    }
}