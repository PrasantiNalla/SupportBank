using NLog;
namespace SupportBank;
public class CsvReader
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

    public string Path { get; set; }
    public CsvReader(string path)
    {
        Path = path;

        Bank bank = new Bank();

        // Read all data in CSV file and put into string array. 
        string[] lines = System.IO.File.ReadAllLines(path);

        // Generate list of transactions for lines
        for (int i = 1; i < lines.Length; i++)
        {
            // loop through each line and split the line by comma to access all data entries
            string[] columns = lines[i].Split(',');
            // populating data into transactions
            Account from = new Account(columns[1]);
            Account to = new Account(columns[2]);
            DateOnly dateEntry = DateOnly.Parse(columns[0]);
            string narrative = columns[3];
            decimal amountEntry = Decimal.Parse(columns[4]);
            bank.Transactions.Add(new Transaction(dateEntry, from, to, narrative, amountEntry));
        }

        // add name to accounts list for lines
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


        // call method to caluclate total owe and owed
        bank.AllTransactions(bank.Transactions, bank.Accounts);


        // call method to list all transactions of a particular account
        bank.AccountDetails(bank.Transactions, bank.Accounts);





    }
}