using Newtonsoft.Json;

namespace SupportBank;
public class FileReader
{
    // Logging setup for CsvReader class.
    private static readonly NLog.ILogger Logger = NLog.LogManager.GetCurrentClassLogger();

    // Getter
    public string InputFile { get; set; }

    // Constructor (setter)
    public FileReader(string inputFile)
    {
        Logger.Info("Successfully started loading .csv file");
        InputFile = inputFile;
        // Create bank object.
        Bank bank = new Bank();

        string fileExt = Path.GetExtension(inputFile);
        if (fileExt == ".csv")
        {    // Read all data in CSV file and put into string array. 
            string[] lines = System.IO.File.ReadAllLines(inputFile);

            // Generate list of transactions for array of CSV data.

            // Loop through each line and split the line by comma to access all data entries.
            for (int i = 1; i < lines.Length; i++)
            {
                //  Logger.Info($"Parsing line {i}.");
                string[] columns = lines[i].Split(',');
                try
                {
                    if (!Decimal.TryParse(columns[4], out decimal valueAmount))
                    {
                        Logger.Error($"Filling of Transactions list unsuccessful at line {i} due to a faulty amount.");
                        continue;
                    }
                    if (!DateOnly.TryParse(columns[0], out DateOnly valueDate))
                    {
                        Logger.Error($"Filling of Transactions list unsuccessful at line {i} due to a faulty date.");
                        continue;
                    }
                    // Populating data into Transactions (list of transactions in bank object).
                    Account from = new Account(columns[1]);
                    Account to = new Account(columns[2]);
                    string dateEntry = columns[0];
                    string narrative = columns[3];
                    decimal amountEntry = Decimal.Parse(columns[4]);
                    bank.Transactions.Add(new Transaction(dateEntry, from, to, narrative, amountEntry));
                }
                catch
                {
                    Logger.Error($"Filling of Transactions list unsuccessful at line {i}.");
                }
            }
        }
        else if (fileExt == ".json")
        {
            Logger.Info("Successfully started loading .json file");
            // read .json file into a string and deserialise the object.
            List<TransactionJson> TransactionJsonList = new List<TransactionJson>();
            TransactionJsonList = (JsonConvert.DeserializeObject<List<TransactionJson>>(File.ReadAllText(inputFile)));
            foreach (TransactionJson tran in TransactionJsonList)
            {
                string Date = tran.Date.Split("T")[0];
                Decimal Amount = tran.Amount;
                string Narrative = tran.Narrative;
                Account From = new Account(tran.FromAccount);
                Account To = new Account(tran.ToAccount);
                bank.Transactions.Add(new Transaction(Date, From, To, Narrative, Amount));

            }
        }
        // Add names of users to Accounts (list of account names in bank object).
        foreach (Transaction name in bank.Transactions)
        {
            if (!bank.Accounts.Any(account => account.Name == name.From.Name))
            {
                bank.Accounts.Add(new Account(name.From.Name));
            }
            if (!bank.Accounts.Any(account => account.Name == name.To.Name))
            {
                bank.Accounts.Add(new Account(name.To.Name));
            }
        }

        Console.WriteLine("Please select one of the following options: \n 1.ListAll Accounts \n 2.List Details of Specific Account");
        string selectedinput = Console.ReadLine();

        if (selectedinput == "1")
        {
            // Call method to calculate total owe and owed for all accounts.
            bank.AllTransactions(bank.Transactions, bank.Accounts);
        }

        else if (selectedinput == "2")
        {
            // Call method to list all transactions of a particular account (name).
            bank.AccountDetails(bank.Transactions, bank.Accounts);
        }

    }
}