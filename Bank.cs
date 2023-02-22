namespace SupportBank;

class Bank
{
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
}