namespace SupportBank;
class Transaction
{
    public DateOnly TDate { get; set; }
    public Account From { get; set; }
    public Account To { get; set; }
    public decimal Amount { get; set; }
    // constructor
    public Transaction(DateOnly tdate, Account from, Account to, decimal amount)
    {
        TDate = tdate;
        From = from;
        To = to;
        Amount = amount;
    }
}