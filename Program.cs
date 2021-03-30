using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1
{   
    class Program
    {

        private const string Adress = "127.1.1.1";
        static private User MyUser;
        static private int SecondPort;

        static private string GetFromStream(NetworkStream streamFromOutside)
        {
            byte[] data = new byte[64];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = streamFromOutside.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (streamFromOutside.DataAvailable);

            return builder.ToString();
        }

        static public int ConnectionToDialog()
        {
            TcpListener listener = new TcpListener(IPAddress.Parse(Adress), MyUser.Port);
            listener.Start();
            TcpClient myClient = null;
            byte[] data;

            while (true)
            {
                try
                {
                    if (listener.Pending())
                    {
                        TcpClient anotherClient = listener.AcceptTcpClient();
                        NetworkStream streamFromOutside = anotherClient.GetStream();
                        User AnotherUser = JsonSerializer.Deserialize<User>(GetFromStream(streamFromOutside));
                        listener.Stop();
                        return AnotherUser.Port;
                    }

                    myClient = new TcpClient(Adress, SecondPort);
                    NetworkStream streamFromInside = myClient.GetStream();
                    data = Encoding.Unicode.GetBytes(JsonSerializer.Serialize<User>(MyUser));
                    streamFromInside.Write(data, 0, data.Length);
                    streamFromInside.Close();
                    myClient.Close();
                    return SecondPort;
                }
                catch (SocketException)
                {
                    Console.WriteLine("Ожидается подключение!");
                    Thread.Sleep(1000);

                }
            }
        }

        static void Main(string[] args)
        {
            MyUser = new User();
            Console.WriteLine("Ваше Имя :");
            MyUser.Username = Console.ReadLine();
            Console.WriteLine("Ваш порт:");
            MyUser.Port = int.Parse(Console.ReadLine());
            Console.WriteLine("Порт собеседника:");
            SecondPort = int.Parse(Console.ReadLine());
            ConnectionToDialog();
            Dialog messager = new Dialog(Adress, MyUser, SecondPort);
            Thread.Sleep(500);
            messager.ChangeMessages();
        }     
    }
}
