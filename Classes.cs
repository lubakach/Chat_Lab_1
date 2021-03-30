using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class User
    {
        public string Username { get; set; }
        public int Port { get; set; }
    }

    public class Message
    {
        public Message()
        {

        }
        public string Username { get; set; }
        public int Id { get; set; }
        public string Messagetext { get; set; }
        public DateTime Time { get; set; }


    }
}
