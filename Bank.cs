using NLog;
namespace SupportBank;

class Bank
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
    public List<Transaction> Transactions;
    public List<Account> Accounts;
    // Constructor
    public Bank()
    {
        Transactions = new List<Transaction>();
        Accounts = new List<Account>();
    }
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
                Console.WriteLine($" From: {tran.From.Name}, To: {tran.To.Name}, Date sent: {tran.TDate}, Reference: {tran.Narrative}, Amount: {tran.Amount}");
            }
        }

    }
}