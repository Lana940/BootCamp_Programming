using System.Net.Sockets; // usingi для подключения уже заготовленных( разрабами c#) библиотек
using System.Net;
using System.Text; // для работы с TCP протоколом обмена между клиентом и сервером

        
namespace Server
{
    class OurServer
    {
        TcpListener server; // слушатель приглашения от клиента на сервере

        public OurServer()
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5555);
            server.Start();

            LoopClients(); //метод для ловли клиентов
        }

        void LoopClients() // каждого отдельного клиента в отдельный поток положить 
        {
            while (true)
            {
                TcpClient client = server.AcceptTcpClient(); //как только к серверу TcpListener подключается какой-либо клиент, создается клиент который будет обрябатываться на сервере
                //обрабатываем и запускаем в отдельныо thread поток
                Thread thread = new Thread(() => HandClient(client)); // в этом потоке выполняется функция удержания клиента
                thread.Start();//запуск потока

            }

        }
      //для клиента только один поток, а вот у сервера для каждого отдельного клиента свой поток
        void HandClient(TcpClient client) //нужно держать соединение с обеих сторон от клиента к серверу и обратно тоже
        // клиент отправлял сообщение, а сервер считывает
        {
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.UTF8);//от конкретного соединения получаем поток
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.UTF8); // для передачи сообщения с сервера на клиент

            while (true) //здесь нужен для того чтобы работать с клиентом бесконечно и слушать соединение(ожидать клиентов)
            {
                string message = sReader.ReadLine(); //обращаемся(считываем) к отдельному потоку, который держит сервер с клиентом 
                Console.WriteLine($"Клиент написал - {message} ");

                 Console.WriteLine("Дайте сообщение клиенту: ");
                string answer = Console.ReadLine();
                sWriter.WriteLine(answer);
                sWriter.Flush();

            }
        }
    }
}