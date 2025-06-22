using System;
public sealed class Logger
{
    private static readonly

    Lazy<Logger> instance = new

    Lazy<Logger>(() => new Logger());

    private Logger() {}

    public static Logger

    Instance => instance.Value;

    public void

    Log(string message){

        Console.WriteLine(message);

    }
}


class Program{

    static void Main(){

        Logger.Instance.Log("Singleton pattern example with Logger.");

        var anotherLogger = Logger.Instance;

        anotherLogger.Log("This is the same Logger instance.");

        Console.WriteLine(object.ReferenceEquals(Logger.Instance, anotherLogger) ? "Only one instance exists." : "Multiple instances exist.");
        
    }
}