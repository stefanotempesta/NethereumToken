using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.HdWallet;
using Newtonsoft.Json;
using NBitcoin;
using Rijndael256;
using System;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
using System.Collections;
using System.Linq;

namespace AgriUtCoinConsole {

    /**
    * @desc Class of wallet creation
    */
    class UserWallet
    {
        static private string network = "";
        static private string workingDirectory = "";

        static private string m_contractAddress = ""; // address of deployed AgriUtCoin smart contract.

        public UserWallet(string strNetwork, string strWorkingDirectory)
        {
            network = strNetwork;
            workingDirectory = strWorkingDirectory;
        }
        
        /**
        * @desc run
        */
        public async Task MainAsync(string[] args)
        {
            string[] availableOperations = {"create", "load", "exit"};
            string input = string.Empty;
            bool isWalletReady = false;
            Wallet wallet = new Wallet(Wordlist.English, WordCount.Twelve);

            Web3 web3 = new Web3(network);
            Directory.CreateDirectory(workingDirectory);
            
            while(!input.ToLower().Equals("exit"))
            {
                if(!isWalletReady)
                {
                    do{
                        input = ReceiveCommandCreateLoad();
                    } while (!((IList)availableOperations).Contains(input));

                    switch (input)
                    {
                        case "create":
                            wallet = CreateWalletDialog();
                            isWalletReady = true;
                             Console.WriteLine("ddddddd: ");
                            break;
                        case "load":
                            wallet = LoadWalletDialog();
                            isWalletReady = true;
                            break;
                        case "exit":
                            return;
                    }
                } else {
                    string[] walletAvaliableOperations = {"balance","receive","send","buy","sell","exit"};
                    string inputCommand = string.Empty;

                    while (!inputCommand.ToLower().Equals("exit"))
                    {
                        do {
                            inputCommand = ReceiveCommandForTokensOperations();
                        } while (!((IList)walletAvaliableOperations).Contains(inputCommand));

                        switch (inputCommand)
                        {
                            case "send":
                                await SendTransactionDialog(wallet);
                                break;
                            case "balance":
                                await GetWalletBallanceDialog(web3, wallet);
                                break;
                            case "receive":
                                Receive(wallet);
                                break;
                            case "buy":
                                await BuyTransactionDialog(wallet);
                                break;
                            case "sell":
                                await SellTransactionDialog(wallet);
                                break;
                            case "exit":
                                return;
                        }
                    }
                }    
            }
        }

        /**
        * @desc: set deployed smart contract's address
        * @param: strAddress - the address of deployed smart contract
        */
        public void SetContractAddress(string strAddress)
        {
            m_contractAddress = strAddress;
        }
        /**
        * @desc The interface of wallet creation
        */
        public static Wallet CreateWalletDialog()
        {
            try {
                string password;
                string passwordConfirmed;
                do {
                    Console.WriteLine("Enter password for encryption: ");
                    password = ReadLine();
                    Console.WriteLine("Confirm password: ");
                    passwordConfirmed = ReadLine();
                    if(password != passwordConfirmed)
                    {
                        Console.WriteLine("Passwords did not match");
                        Console.WriteLine("Try again.");
                    }
                } while (password != passwordConfirmed);

                Wallet wallet = CreateWallet(password, workingDirectory);
                return wallet;
            } catch (Exception e)
            {
                Console.WriteLine($"Error: Wallet in path {workingDirectory} can't be created!");
                throw(e);
            }
        }

        /**
        * @desc The interface of loading wallet
        */
        public static Wallet LoadWalletDialog()
        {
            Console.WriteLine("Enter: Name of the file containing wallet: ");
            string nameOfWallet = ReadLine();
            Console.WriteLine("Enter: Password: ");
            string pass = ReadLine();
            try {
                Wallet wallet = LoadWalletFromJsonFile(nameOfWallet, workingDirectory, pass);
                return wallet; 
            } catch (Exception e) {
                Console.WriteLine($"ERROR! Wallet {nameOfWallet} in path {workingDirectory} can`t be loaded!");
                throw e;
            }
        }

        /**
        * @desc The interface of getting wallet's balance
        */
        public static async Task GetWalletBallanceDialog(Web3 web3, Wallet wallet)
        {
            Console.WriteLine("Balance: ");
            try {
                await Balance(web3, wallet); 
            } catch (Exception) {
                Console.WriteLine("Error occured!");
            }
        }

        
        /**
        * @desc the interface of send coin
        */
        public static async Task SendTransactionDialog(Wallet wallet)
        {
            Console.WriteLine("Enter: Address sending coins.");
            string fromAddress = ReadLine();
            Console.WriteLine("Enter: Address receiving coins");
            string toAddress = ReadLine();
            Console.WriteLine("Enter: Amount of coins.");
            double amountOfCoins = 0d;
            try {
                amountOfCoins = double.Parse(ReadLine());
            } catch (Exception) {
                Console.WriteLine("Unacceptable input for amount of coins.");
            }

            if (amountOfCoins > 0.0d)
            {
                Console.WriteLine($"You will send {amountOfCoins} coin from {fromAddress} to {toAddress}");
                Console.WriteLine($"Are you sure? yes/no");
                string answer = ReadLine();
                if (answer.ToLower() == "yes")
                {
                    // Send the Transaction.
                    await Send(wallet, fromAddress, toAddress, amountOfCoins);
                }
            }
            else
            {
                Console.WriteLine("Amount of coins for transaction must be positive number!");
            }
        }

        /**
        * @desc interface of buying coin
        */
        public static async Task BuyTransactionDialog(Wallet wallet)
        {
            Console.WriteLine("Enter: Address sending coins.");
            string fromAddress = ReadLine();
            Console.WriteLine("Enter: Amount of coins.");
            double amountOfCoins = 0d;
            try {
                amountOfCoins = double.Parse(ReadLine());
            } catch (Exception) {
                Console.WriteLine("Unacceptable input for amount of coins.");
            }

            if (amountOfCoins > 0.0d)
            {
                Console.WriteLine($"You will buy {amountOfCoins} coin");
                Console.WriteLine($"Are you sure? yes/no");
                string answer = ReadLine();
                if (answer.ToLower() == "yes")
                {
                    // Send the Transaction.
                    await Buy(wallet, fromAddress, amountOfCoins);
                }
            }
            else
            {
                Console.WriteLine("Amount of coins for transaction must be positive number!");
            }
        }

        /**
        * @desc interface of selling coin
        */
        public static async Task SellTransactionDialog(Wallet wallet)
        {
            Console.WriteLine("Enter: Address sending coins.");
            string fromAddress = ReadLine();
            Console.WriteLine("Enter: Amount of coins.");
            double amountOfCoins = 0d;
            try {
                amountOfCoins = double.Parse(ReadLine());
            } catch (Exception) {
                Console.WriteLine("Unacceptable input for amount of coins.");
            }

            if (amountOfCoins > 0.0d)
            {
                Console.WriteLine($"You will sell {amountOfCoins} coin");
                Console.WriteLine($"Are you sure? yes/no");
                string answer = ReadLine();
                if (answer.ToLower() == "yes")
                {
                    // Send the Transaction.
                    await Sell(wallet, fromAddress, amountOfCoins);
                }
            }
            else
            {
                Console.WriteLine("Amount of coins for transaction must be positive number!");
            }
        }
        
        public static string ReceiveCommandCreateLoad()
        {
            Console.WriteLine("Choose working wallet.");
            Console.WriteLine("Choose [create] to Create new Wallet.");
            Console.WriteLine("Choose [load] to load existing Wallet from file.");
            Console.WriteLine("Enter operation [\"Create\", \"Load\", \"Exit\"]: ");
            string input = ReadLine().ToLower().Trim();
            return input;
        }

        public static string ReceiveCommandForTokensOperations()
        {
            Console.WriteLine("Enter operation [\"Balance\", \"Receive\", \"Send\", \"Buy\", \"Sell\", \"Exit\"]: ");
            string inputCommand = ReadLine().ToLower().Trim();
            return inputCommand;
        }

        /**
        * @desc create wallet
        */
        public static Wallet CreateWallet(string password, string pathfile)
        {
            Wallet wallet = new Wallet(Wordlist.English, WordCount.Twelve);
            string words = string.Join(" ", wallet.Words);

            string fileName = string.Empty;
            try
            {
                fileName = SaveWalletToJsonFile(wallet, password, pathfile);
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR! The file can`t be saved! {e}");
                throw e;
            }

            Console.WriteLine("New Wallet was created successfully!");
            Console.WriteLine("Write down the following mnemonic words and keep them in the save place.");
            // TODO: Display the Words here.
            Console.WriteLine(words);
            Console.WriteLine("Seed: ");
            // TODO: Display the Seed here.
            Console.WriteLine(wallet.Seed);
            Console.WriteLine();
            // TODO: Implement and use PrintAddressesAndKeys to print all the Addresses and Keys.
            PrintAddressesAndKeys(wallet);

            return wallet;
        }

        /**
        * @desc print addresses and private keys in wallet
        */
        private static void PrintAddressesAndKeys(Wallet wallet)
        {
            // TODO: Print all the Addresses and the coresponding Private Keys.
            Console.WriteLine("Addresses:");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(wallet.GetAccount(i).Address);
            }

            Console.WriteLine();
            Console.WriteLine("Private Keys:");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(wallet.GetAccount(i).PrivateKey);
            }

            Console.WriteLine();
        }

        /**
        * @desc save wallet to json file
        */
        private static string SaveWalletToJsonFile(Wallet wallet, string password, string pathfile)
        {
            string words = string.Join(" ", wallet.Words);
            var encryptedWords = Rijndael.Encrypt(words, password, KeySize.Aes256);
            string date = DateTime.Now.ToString();
            //  Anonymous object containing encryptedWords and date will be written in the Json file
            var walletJsonData = new { encryptedWords = encryptedWords, date = date };
            string json = JsonConvert.SerializeObject(walletJsonData);
            Random random = new Random();
            var fileName =
                "Wallet_"
                + DateTime.Now.Year + "-"
                + DateTime.Now.Month + "-"
                + DateTime.Now.Day + "_"
                + DateTime.Now.Hour + "-"
                + DateTime.Now.Minute + "-"
                + DateTime.Now.Second + "-"
                + random.Next(0, 10000) + ".json";
            File.WriteAllText(Path.Combine(pathfile, fileName), json);
            Console.WriteLine($"Wallet saved in file: {fileName}");
            return fileName;
        }

        /**
        * @desc load wallet from json file.
        */
        private static Wallet LoadWalletFromJsonFile(string nameOfWalletFile, string path, string pass)
        {
            string pathToFile = Path.Combine(path, nameOfWalletFile);
            string words = string.Empty;
            // Read from fileName
            Console.WriteLine($"Read from {pathToFile}");
            try
            {
                string line = File.ReadAllText(pathToFile);
                dynamic results = JsonConvert.DeserializeObject<dynamic>(line);
                string encryptedWords = results.encryptedWords;
                words = Rijndael.Decrypt(encryptedWords, pass, KeySize.Aes256);
                string dataAndTime = results.date;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR!" + e);
            }

            return Recover(words);
        }

        /**
        * @desc recover
        */
        private static Wallet Recover(string words)
        {
            // TODO: Recover a Wallet from existing mnemonic phrase (words).
            Wallet wallet = new Wallet(words, null);
            Console.WriteLine("Wallet was successfully recovered.");
            Console.WriteLine("Words: " + string.Join(" ", wallet.Words));
            Console.WriteLine("Seed: " + string.Join(" ", wallet.Seed));
            Console.WriteLine();
            PrintAddressesAndKeys(wallet);
            return wallet;
        }

        public static void Receive(Wallet wallet)
        {
            // TODO: Print all avaiable addresses in Wallet.
            if (wallet.GetAddresses().Count() > 0)
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine(wallet.GetAccount(i).Address);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No addresses found!");
            }
        }
        private static async Task Send(Wallet wallet, string fromAddress, string toAddress, double amountOfCoins)
        {
            // TODO: Generate and Send a transaction.
            Account accountFrom = wallet.GetAccount(fromAddress);
            string privateKeyFrom = accountFrom.PrivateKey;
            if (privateKeyFrom == string.Empty)
            {
                Console.WriteLine("Address sending coins is not from current wallet!");
                throw new Exception("Address sending coins is not from current wallet!");
            }

            var web3 = new Web3(accountFrom, network);
            var interfaceAgriUt = new InterfaceAgriUtCoin();
            var wei = Web3.Convert.ToWei(amountOfCoins);
            try
            {
                await interfaceAgriUt.Send(web3, m_contractAddress, toAddress, wei);
                Console.WriteLine("Transaction has been sent successfully!");

            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR!  The transaction can't be completed!  {e}");
                throw e;
            }
        }

        private static async Task Buy(Wallet wallet, string fromAddress, double amountOfCoins)
        {
            // TODO: Generate and Send a transaction.
            Account accountFrom = wallet.GetAccount(fromAddress);
            string privateKeyFrom = accountFrom.PrivateKey;
            if (privateKeyFrom == string.Empty)
            {
                Console.WriteLine("Address buying coins is not from current wallet!");
                throw new Exception("Address buying coins is not from current wallet!");
            }

            var web3 = new Web3(accountFrom, network);
            var interfaceAgriUt = new InterfaceAgriUtCoin();
            var wei = Web3.Convert.ToWei(amountOfCoins);
            try
            {
                await interfaceAgriUt.Buy(web3, m_contractAddress, wei);
                Console.WriteLine("Transaction has been sent successfully!");

            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR!  The transaction can't be completed!  {e}");
                throw e;
            }
        }

        private static async Task Sell(Wallet wallet, string fromAddress, double amountOfCoins)
        {
            // TODO: Generate and Send a transaction.
            Account accountFrom = wallet.GetAccount(fromAddress);
            string privateKeyFrom = accountFrom.PrivateKey;
            if (privateKeyFrom == string.Empty)
            {
                Console.WriteLine("Address selling coins is not from current wallet!");
                throw new Exception("Address selling coins is not from current wallet!");
            }

            var web3 = new Web3(accountFrom, network);
            var interfaceAgriUt = new InterfaceAgriUtCoin();
            var wei = Web3.Convert.ToWei(amountOfCoins);
            try
            {
                await interfaceAgriUt.Sell(web3, m_contractAddress, wei);
                Console.WriteLine("Transaction has been sent successfully!");

            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR!  The transaction can't be completed!  {e}");
                throw e;
            }
        }

        private static async Task Balance(Web3 web3, Wallet wallet)
        {
            // TODO: Print all addresses and their balance. Print the Total Balance of the Wallet as well.
            decimal totalBalance = 0.0m;
            var interfaceAgriUt = new InterfaceAgriUtCoin();

            for (int i = 0; i < 20; i++)
            {
                var balance = await interfaceAgriUt.GetBalance(web3, m_contractAddress, wallet.GetAccount(i).Address);
                var coinAmount = Web3.Convert.FromWei(balance);
                totalBalance += coinAmount;
                Console.WriteLine(wallet.GetAccount(i).Address + " " + coinAmount);
            }

            Console.WriteLine($"Total balance: {totalBalance} \n");
        }

    }
}