using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_app_moderator_exotisch_nederland.Data;
using Console_app_moderator_exotisch_nederland.Models;

namespace Console_app_moderator_exotisch_nederland.Business
{
    internal class BusinessLogin
    {
        DataLogin _dataLogin = new DataLogin();

        public string BusinessLoginCheck(User gebruiker) {

            if (string.IsNullOrEmpty(gebruiker.Gebruikersnaam) || string.IsNullOrEmpty(gebruiker.Wachtwoord)){
                return "Vul alle velden in";
            }

            return "Login poging wordt verwerkt. \nEen moment geduld a.u.b.";
            
        }

        
    }
}
