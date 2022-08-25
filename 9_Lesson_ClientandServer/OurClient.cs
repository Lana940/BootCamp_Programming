using System.Net.Sockets; // usingi для подключения уже заготовленных( разрабами c#) библиотек
using System.Text;        // для работы с TCP протоколом обмена между клиентом и сервером

namespace Client
{
    class OurClient
    {
         private TcpClient client; // переменная_client позволяет работать с Тср
         private StreamWriter sWriter; // поток для передачи с клиента на сервер
         private StreamReader sReader; // поток для передачи с сервера клиенту(чтения сообщения от клиента)

         public OurClient()   // (string ipAdress, int portNum) // ipaddress, portNum - адреса сервера, port - номер "гавани" куда пришвар корабль, у одного IP мб несколько портов
         {
            client = new TcpClient("127.0.0.1", 5555);
            sWriter = new StreamWriter(client.GetStream(), Encoding.UTF8); // вытащили поток из клиента
            sReader = new StreamReader(client.GetStream(), Encoding.UTF8);

            HandleCommunication(); //держим соединение
         }

         //для удержания подключения:
         void HandleCommunication()
         {
            while (true) // этот цикл работает непрерывно - бесконечен
            {
                Console.Write("> "); // для клиента > ..text  тут будет смс для клиента 
                string message = Console.ReadLine();
                sWriter.WriteLine(message);  //отправляем смс серверу по вытянутому потоку, подготовили смс 
                sWriter.Flush();// нужно оправить смс немедленно, * отправили смс

                string answerServer = sReader.ReadLine();
                Console.WriteLine($"Сервер ответил -> {answerServer}");
            }
         }
    }


}