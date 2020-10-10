﻿using DavinciJ15TokenBot.Common.Interfaces;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DavinciJ15TokenBot.EthereumConnector.EthNode
{
    public class EthNodeEthereumConnector : IEthereumConnector
    {
        private static string erc20Abi = @"[{""constant"":true,""inputs"":[],""name"":""name"",""outputs"":[{""name"":"""",""type"":""string""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""spender"",""type"":""address""},{""name"":""tokens"",""type"":""uint256""}],""name"":""approve"",""outputs"":[{""name"":""success"",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":true,""inputs"":[],""name"":""totalSupply"",""outputs"":[{""name"":"""",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""from"",""type"":""address""},{""name"":""to"",""type"":""address""},{""name"":""tokens"",""type"":""uint256""}],""name"":""transferFrom"",""outputs"":[{""name"":""success"",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":true,""inputs"":[],""name"":""decimals"",""outputs"":[{""name"":"""",""type"":""uint8""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":true,""inputs"":[],""name"":""_totalSupply"",""outputs"":[{""name"":"""",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":true,""inputs"":[{""name"":""tokenOwner"",""type"":""address""}],""name"":""balanceOf"",""outputs"":[{""name"":""balance"",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":false,""inputs"":[],""name"":""acceptOwnership"",""outputs"":[],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":true,""inputs"":[],""name"":""owner"",""outputs"":[{""name"":"""",""type"":""address""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":true,""inputs"":[],""name"":""symbol"",""outputs"":[{""name"":"""",""type"":""string""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":true,""inputs"":[{""name"":""a"",""type"":""uint256""},{""name"":""b"",""type"":""uint256""}],""name"":""safeSub"",""outputs"":[{""name"":""c"",""type"":""uint256""}],""payable"":false,""stateMutability"":""pure"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""to"",""type"":""address""},{""name"":""tokens"",""type"":""uint256""}],""name"":""transfer"",""outputs"":[{""name"":""success"",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":true,""inputs"":[{""name"":""a"",""type"":""uint256""},{""name"":""b"",""type"":""uint256""}],""name"":""safeDiv"",""outputs"":[{""name"":""c"",""type"":""uint256""}],""payable"":false,""stateMutability"":""pure"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""spender"",""type"":""address""},{""name"":""tokens"",""type"":""uint256""},{""name"":""data"",""type"":""bytes""}],""name"":""approveAndCall"",""outputs"":[{""name"":""success"",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":true,""inputs"":[{""name"":""a"",""type"":""uint256""},{""name"":""b"",""type"":""uint256""}],""name"":""safeMul"",""outputs"":[{""name"":""c"",""type"":""uint256""}],""payable"":false,""stateMutability"":""pure"",""type"":""function""},{""constant"":true,""inputs"":[],""name"":""newOwner"",""outputs"":[{""name"":"""",""type"":""address""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""tokenAddress"",""type"":""address""},{""name"":""tokens"",""type"":""uint256""}],""name"":""transferAnyERC20Token"",""outputs"":[{""name"":""success"",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":true,""inputs"":[{""name"":""tokenOwner"",""type"":""address""},{""name"":""spender"",""type"":""address""}],""name"":""allowance"",""outputs"":[{""name"":""remaining"",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":true,""inputs"":[{""name"":""a"",""type"":""uint256""},{""name"":""b"",""type"":""uint256""}],""name"":""safeAdd"",""outputs"":[{""name"":""c"",""type"":""uint256""}],""payable"":false,""stateMutability"":""pure"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""_newOwner"",""type"":""address""}],""name"":""transferOwnership"",""outputs"":[],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[],""payable"":false,""stateMutability"":""nonpayable"",""type"":""constructor""},{""payable"":true,""stateMutability"":""payable"",""type"":""fallback""},{""anonymous"":false,""inputs"":[{""indexed"":true,""name"":""_from"",""type"":""address""},{""indexed"":true,""name"":""_to"",""type"":""address""}],""name"":""OwnershipTransferred"",""type"":""event""},{""anonymous"":false,""inputs"":[{""indexed"":true,""name"":""from"",""type"":""address""},{""indexed"":true,""name"":""to"",""type"":""address""},{""indexed"":false,""name"":""tokens"",""type"":""uint256""}],""name"":""Transfer"",""type"":""event""},{""anonymous"":false,""inputs"":[{""indexed"":true,""name"":""tokenOwner"",""type"":""address""},{""indexed"":true,""name"":""spender"",""type"":""address""},{""indexed"":false,""name"":""tokens"",""type"":""uint256""}],""name"":""Approval"",""type"":""event""}]";
        private readonly string nodeAddress;
        private readonly AuthenticationHeaderValue authenticationHeader;

        public EthNodeEthereumConnector(string nodeAddress, AuthenticationHeaderValue authenticationHeader)
        {
            this.nodeAddress = nodeAddress;
            this.authenticationHeader = authenticationHeader;
        }

        public async Task<decimal> GetAccountBalanceAsync(string address, string contractAddress, int decimals)
        {
            var web3 = new Web3(url: this.nodeAddress, authenticationHeader: this.authenticationHeader); 
            var contract = web3.Eth.GetContract(erc20Abi, contractAddress);
            var balanceFunction = contract.GetFunction("balanceOf");
            var balance = await balanceFunction.CallAsync<BigInteger>(address);

            var divisor = Math.Pow(10, decimals);

            return (long)balance / Convert.ToDecimal(divisor);
        }
    }
}
