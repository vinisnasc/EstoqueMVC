using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.MVC.Models.EmailSender
{
    public class TemplateData
    {
        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Weblink")]
        public string Weblink { get; set; }
    }
}
