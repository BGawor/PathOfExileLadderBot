using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PathOfExileLadderBot
{

    class LadderAPI
    {
        
        public string GetPlayerLevel(string name) // returns all characters belonging to target account name
        {

            var url = new Uri($"http://api.pathofexile.com/ladders/Hardcore%20Bestiary?accountName=" +name);
            WebClient webClient = new WebClient();
            var json = new WebClient().DownloadString(url);
            json = json.Replace("class", "klasa");
            dynamic level = JsonConvert.DeserializeObject<dynamic>(json);

            //Console.WriteLine(level);
            //Console.WriteLine("Character " + level.entries[0].character.name + " is at level " + level.entries[0].character.level + ".");
            string characters = "Lista postaci: ";
            foreach (var item in level.entries)
            {
                characters += item.character.name + " lvl" + item.character.level + " " + item.character.klasa + " ";
            }
            return characters;
        }





    }
}
