# Nethereum.Faucet

Simple faucet to fund Ethereum accounts

## Installation as a dotnet new template
To install the faucet as a "dotnet new" template use the following command:

```
dotnet new -i Nethereum.Templates.Faucet::*
```

Then run:

```
dotnet new nethereumfaucet -n BankConsortiumFaucet
```

Where -n BankConsortiumFaucet is the NameSpace of your project.

## Manual clone, installation
All the source files can be found on the Content folder.

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

![Faucet demo](faucet.png "Faucet demo")
