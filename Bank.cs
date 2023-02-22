namespace SupportBank;

class Bank
{
    public List<Transaction> Transactions = new List<Transaction>();
    public List<Account> Accounts = new List<Account>();

    // public List<Account> Accounts
    // {
    //     get
    //     {
    //         foreach (Transaction name in Transactions)
    //         {
    //             if (accounts.Any(account => account.Name != name.From.Name))
    //             {
    //                 accounts.Add(name.From);
    //             }
    //             if (accounts.Any(account => account.Name != name.To.Name))
    //             {
    //                 accounts.Add(name.To);
    //             }

    //         }

    //         return accounts;
    //     }
    //     set
    //     {
    //         accounts = Accounts;
    //     }

    // }

    // public void AccountDetails()
    // {

    // }
    // Constructor
    public Bank()
    {
        Transactions = new List<Transaction>();
        Accounts = new List<Account>();
    }

    // public AllTransactions()
    // {
    //    foreach()
    // }
}