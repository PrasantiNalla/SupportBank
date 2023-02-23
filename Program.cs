using SupportBank;
using NLog;
using NLog.Config;
using NLog.Targets;

// Logging setup
var config = new LoggingConfiguration();
var target = new FileTarget { FileName = @"C:\TRAINING\SupportBank\Logs\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
config.AddTarget("File Logger", target);
config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
LogManager.Configuration = config;

// Ask user which file to read.
bool pathselection = true;
string path = " ";
while (pathselection)
{
    Console.WriteLine("Please choose which file to access (type 1-3): \nl 1: Transactions 2014 \nl 2: Transactions 2015");
    string name = Console.ReadLine();
    if(Int32.TryParse(name, out int value) == false ){
     Console.WriteLine("Invalid input. Please select 1-3.");
    }
    else if(Int32.Parse(name) == 1){
         path = "./Transactions2014.csv";
        pathselection = false;
    } else if(Int32.Parse(name) == 2){
         path = "./DodgyTransactions2015.csv";
        pathselection = false;
    } else if(Int32.Parse(name) == 3){
         path = "./Transactions2013.json";
        pathselection = false;
    }

}

// Create CsvReader for relevant file.
CsvReader readfile = new CsvReader(path);