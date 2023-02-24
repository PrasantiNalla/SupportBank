using Newtonsoft.Json;
namespace SupportBank;

public class JsonReader
{
    private static readonly NLog.ILogger Logger = NLog.LogManager.GetCurrentClassLogger();

    // Getter
    public string Path { get; set; }

    // Constructor (setter)
    public JsonReader(string path)
    {
        Logger.Info("Successfully started JsonReader");
        Path = path;
        Bank bank = new Bank();
        using (StreamReader r = new StreamReader(path))
        {
            string json = r.ReadToEnd();
            bank.Transactions = JsonConvert.DeserializeObject<List<Transaction>>(json);
        }
        Console.WriteLine(bank.Transactions[1].Amount);

    }

}
