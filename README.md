# Nethereum.Faucet

Simple faucet to fund Ethereum accounts

## Configuration settings:
### Appsettings.json

Please modify the appsettings file to provide the Ethereum address, Explorer for transactions, private key and the maximum amount to fund.
```
"EthereumAddress": "http://ETHEREUM-ADDRESS:8545",
 "FunderPrivateKey": "PRIVATE KEY",
 "MaxAmountToFund": 100,
 "AmountToFund": 10,
 "UrlTxnExplorer": "http://BLOCKEXPLORER-ADDRESS/tx/"
```

[![Faucet demo](faucet.png "Faucet demo")]