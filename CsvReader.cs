namespace SupportBank;

public class CsvReader
{
    // path to the csv file
    string path = "./Transactions2014.csv";
    //constructor
    public CsvReader()
    {
        Bank bank = new Bank();
        //  List<Account> accounts = new List<Account>();

        // Read all data in CSV file and put into string array. 
        string[] lines = System.IO.File.ReadAllLines(path);
        // loop through each line and split the line by comma to access all data entries
        // populating data into transactions
        for (int i = 1; i < lines.Length; i++)
        {
            string[] columns = lines[i].Split(',');

            Account from = new Account(columns[1]);
            Account to = new Account(columns[2]);
            DateOnly dateEntry = DateOnly.Parse(columns[0]);
            decimal amountEntry = Decimal.Parse(columns[4]);

            bank.Transactions.Add(new Transaction(dateEntry, from, to, amountEntry));


        }
        // add name to accounts list, but if name already exists, dont' add
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

      



    }
}