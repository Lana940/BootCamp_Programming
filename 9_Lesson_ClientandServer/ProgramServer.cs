namespace Server //пространство имен, для использования одних и тех же переменных в разных файлах
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("это наш сервер");
            OurServer server = new OurServer();

        }
    }
}