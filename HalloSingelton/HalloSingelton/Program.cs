using HalloSingelton;

Console.WriteLine("Hello, World!");

//var logger = new Logger();

for (int i = 0; i < 20; i++)
{
    Task.Run(() => Logger.Instance.Info(i.ToString()));
}

Logger.Instance.Info("Moin Logger");
Logger.Instance.Error("PANIK!");

Logger.Instance.Info("Mehr Logger");
