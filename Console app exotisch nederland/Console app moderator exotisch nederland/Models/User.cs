using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_app_moderator_exotisch_nederland.Models
{
    internal class User
    {
        public string Gebruikersnaam {  get; set; }
        public string Wachtwoord {  get; set; }

        public User(string gebruikersnaam, string wachtwoord)
        {
            Gebruikersnaam = gebruikersnaam;
            Wachtwoord = wachtwoord;
        }
    }
}
