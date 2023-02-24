namespace SupportBank;
class Transaction
{
    // Getters
    public string Date { get; set; }
    public Account From { get; set; }
    public Account To { get; set; }
    public string Narrative { get; set; }
    public decimal Amount { get; set; }

    // Constructor (setters)
    public Transaction(string date, Account from, Account to, string narrative, decimal amount)
    {
        Date = date;
        From = from;
        To = to;
        Narrative = narrative;
        Amount = amount;
    }
}