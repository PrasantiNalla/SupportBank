namespace SupportBank;
public class CsvReader
{
    string path = "./Transactions2014.csv"; // csv file path
    string path2 = "./DodgyTransactions2015.csv";
    public CsvReader()
    {
        Bank bank = new Bank();
        Bank bank2 = new Bank();
        // Read all data in CSV file and put into string array. 
        string[] lines = System.IO.File.ReadAllLines(path);
        string[] lines2 = System.IO.File.ReadAllLines(path2);

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

        // Generate list of transactions for lines2
        for (int i = 1; i < lines2.Length; i++)
        {
            // loop through each line and split the line by comma to access all data entries
            string[] columns2 = lines2[i].Split(',');
            // populating data into transactions
            Account from2 = new Account(columns2[1]);
            Account to2 = new Account(columns2[2]);
            DateOnly dateEntry2 = DateOnly.Parse(columns2[0]);
            string narrative2 = columns2[3];
            decimal amountEntry2 = Decimal.Parse(columns2[4]);
            bank2.Transactions.Add(new Transaction(dateEntry2, from2, to2, narrative2, amountEntry2));
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

        // add name to accounts list for lines2
        foreach (Transaction name in bank2.Transactions)
        {
            if (!bank2.Accounts.Any(account => account.Name == name.From.Name))
            {
                bank2.Accounts.Add(new Account(name.From.Name));
            }
            if (!bank2.Accounts.Any(account => account.Name == name.To.Name))
            {
                bank2.Accounts.Add(new Account(name.To.Name));
            }
        }

        // call method to caluclate total owe and owed
      //  bank.AllTransactions(bank.Transactions, bank.Accounts);
        bank2.AllTransactions(bank2.Transactions, bank2.Accounts);

        // call method to list all transactions of a particular account
      //  bank.AccountDetails(bank.Transactions, bank.Accounts);
        bank2.AccountDetails(bank2.Transactions, bank2.Accounts);




    }
}