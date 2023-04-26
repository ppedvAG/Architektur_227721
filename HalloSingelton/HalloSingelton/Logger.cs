namespace HalloSingelton
{
    internal class Logger
    {
        private static Logger instance;
        private static object instanceLock = new object();

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                    lock (instanceLock)
                    {
                        if (instance == null)
                            instance = new Logger();
                    }

                return instance;
            }
        }

        private Logger()
        {
            Console.WriteLine("Logger gestartet");
        }

        public void Info(string msg)
        {
            Console.WriteLine($"[INFO] {DateTime.Now:G} {msg}");
        }

        public void Error(string msg)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now:G} {msg}");
        }
    }
}
