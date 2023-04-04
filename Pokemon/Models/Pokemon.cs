using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Models
{
   public class Pokemon
    {
        [JsonProperty("name")]
        public string nombrePokemon { get; set; }
        [JsonProperty("url")]
        public Uri link { get; set; }

        public Image GetImagen()
        {
            string dir = link.ToString();
            dir = dir.Substring(0, dir.Length - 1);
            dir = dir.Substring(dir.LastIndexOf("/"));

            dir = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/"+dir + ".png";

            var request = WebRequest.Create(dir);

            using (var response = request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    return Bitmap.FromStream(stream);

                }
            }
        }
    }
}
