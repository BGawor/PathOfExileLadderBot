using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PathOfExileLadderBot
{
    class MessageReader
    {
        public string CzytajOdKogo(string message)
        {
            string senderName = message;
            string[] messageTable = message.Split();
            int index = Array.IndexOf(messageTable, "PRIVMSG");
            if (index >= 0)
            {
                string[] messageTable2 = messageTable.Skip(index).ToArray();
                string wiadomosc = "";

                foreach (var item in messageTable2)
                {
                    if (item.StartsWith("#"))
                    {
                        wiadomosc += item.Substring(1);
                    }
                    if (item.Equals(messageTable2.Last()))
                    {
                        // do something different with the last item
                    }
                    else
                    {
                        wiadomosc += " ";
                        // do something different with every item but the last
                    }
                }
                return "Wiadomosc odczytana: " + wiadomosc;
            }
            else return "";
        }

        public string CzytajKonto(string message)
        {
            string senderName = message;
            string[] messageTable = message.Split();
            int index = Array.IndexOf(messageTable, "PRIVMSG");
            if (index >= 0)
            {
                string[] messageTable2 = messageTable.Skip(index).ToArray();
                string wiadomosc = "";
                var previous = "";
                foreach (var item in messageTable2)
                {
                    
                    if (previous.StartsWith(":"))
                    {
                        wiadomosc += item;
                    }
                    if (item.Equals(messageTable2.Last()))
                    {
                        // do something different with the last item
                    }
                    else
                    {
                        wiadomosc += " ";
                        // do something different with every item but the last
                    }
                    previous = item;
                }
                return Regex.Replace(wiadomosc, @"\s+", "");
            }
            else return "";
        }
    }
}
