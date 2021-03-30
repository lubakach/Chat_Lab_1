using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1
{
    public class Dialog
    {
        private readonly int SecondPort;
        private readonly string Ip;
        private readonly User MyUser;

        private readonly List<Message> DialogList;


        private void MessagesFromOut()
        {
            UdpClient client = new UdpClient(MyUser.Port);
            IPEndPoint remoteIp = null;
            try
            {
                while (true)
                {
                    byte[] data = client.Receive(ref remoteIp);
                    string json = Encoding.Unicode.GetString(data);

                    Message message = JsonSerializer.Deserialize<Message>(json.ToString());

                    DialogList.Add(message);
                    DialogList.Sort((a, b) => a.Time.CompareTo(b.Time));
                    DisplayMessages();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }

        private void DisplayMessages()
        {
            Console.Clear();
            foreach (Message message in DialogList)
            {
                Console.WriteLine(message.Username + ": " + message.Messagetext + " (" + message.Time.ToString("hh:mm") + ")");
                Console.WriteLine();
            }

            Console.WriteLine("Сообщение:");
        }

        public Dialog(string _ip, User _myUser, int _SecondPort)
        {
            Ip = _ip;
            MyUser = _myUser;
            SecondPort = _SecondPort;
            DialogList = new List<Message>();
        }

        public void ChangeMessages()
        {
            UdpClient client = new UdpClient();
            Thread receiveThread = new Thread(new ThreadStart(MessagesFromOut));
            receiveThread.Start();
            try
            {
                while (true)
                {
                    DisplayMessages();

                    string text = Console.ReadLine();

                    Message message = new Message() {
                        Username = MyUser.Username,
                        Messagetext = text,
                        Time = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now)
                    };

                    byte[] data = Encoding.Unicode.GetBytes(JsonSerializer.Serialize<Message>(message));
                    client.Send(data, data.Length, Ip, SecondPort);

                    DialogList.Add(message);
                    DialogList.Sort((a, b) => a.Time.CompareTo(b.Time));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }
    }
}
