using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace PathOfExileLadderBot
{
    class Program
    {
        static void Main(string[] args)
        {

            string adressURL = "irc.chat.twitch.tv";
            int port = 6667;

            //string pw = File.ReadAllText("pw.txt");
            string pw = "oauth:qln7yw28vz3isvnfudr9z7f8d6t9dh";
            TcpClient tcpClient = new TcpClient(adressURL, port);

            StreamReader reader = new StreamReader(tcpClient.GetStream());
            StreamWriter writer = new StreamWriter(tcpClient.GetStream());

            writer.WriteLine($"PASS {pw}");
            writer.Flush();
            writer.WriteLine("NICK bargaw");
            writer.Flush();
            writer.WriteLine("JOIN #bargaw");
            writer.Flush();
           // writer.WriteLine("PRIVMSG #bargaw :Hello World!");
         //   writer.Flush();

            MessageReader Rysio = new MessageReader();
            LadderAPI test = new LadderAPI();

           

            while (tcpClient.Connected)
            {
                string msg = reader.ReadLine();
                Console.WriteLine(msg);
                if (msg.Contains("!etup"))
                {
                    string characters = test.GetPlayerLevel("Etup");
                    writer.WriteLine("PRIVMSG #bargaw :" + characters);
                    writer.Flush();
                }
                if (msg.Contains("!level"))
                {
                    //string characters = test.GetPlayerLevel("Etup");
                    writer.WriteLine("PRIVMSG #bargaw :" + "Szukam postaci na koncie: " + Rysio.CzytajKonto(msg) + " ... ");
                    writer.Flush();
                    Thread.Sleep(500);
                    writer.WriteLine("PRIVMSG #bargaw :" + test.GetPlayerLevel(Rysio.CzytajKonto(msg)));
                    writer.Flush();
                }
                if (msg.Contains("PING"))
                {
                    //string characters = test.GetPlayerLevel("Etup");Regex.Replace(XML, @"\s+", "")
                    writer.WriteLine("PONG tmi.twitch.tv\r\n");
                    writer.Flush();
                    
                }
                Thread.Sleep(100);
            }


        }
    }
}
