namespace SupportBank;

class Bank
{
    // Logging setup for CsvReader class.
    private static readonly NLog.ILogger Logger = NLog.LogManager.GetCurrentClassLogger();

    // Getters
    public List<Transaction> Transactions;
    public List<Account> Accounts;

    // Constructor (setter)
    public Bank()
    {
        Logger.Info("Successfully started Bank");
        Transactions = new List<Transaction>();
        Accounts = new List<Account>();
    }

    // Method to calculate total owe and owed for all accounts.
    public void AllTransactions(List<Transaction> Transactions, List<Account> Accounts)
    {
        decimal total = 0;
        Console.WriteLine("The total owed for each individual is:");
        foreach (Account person in Accounts)
        {
            foreach (Transaction trans in Transactions)
            {
                if (person.Name == trans.To.Name)
                {
                    total += trans.Amount;
                }
                if (person.Name == trans.From.Name)
                {
                    total -= trans.Amount;
                }
            }
            Console.WriteLine($"{person.Name} : {total}");
        }
    }

    // Method to list all transactions of a particular account (name).
    public void AccountDetails(List<Transaction> Transactions, List<Account> Accounts)
    {
        Console.WriteLine($"Please provide an account name from the following list:");
        foreach (Account acc in Accounts)
        {
            Console.WriteLine(acc.Name);
        }
        string name = Console.ReadLine();

        foreach (Transaction tran in Transactions)
        {
            if (tran.To.Name == name || tran.From.Name == name)
            {
                Console.WriteLine($" From: {tran.From.Name}, To: {tran.To.Name}, Date sent: {tran.Date}, Reference: {tran.Narrative}, Amount: {tran.Amount}");
            }
        }

    }
}