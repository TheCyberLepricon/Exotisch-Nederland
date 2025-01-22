using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_app_moderator_exotisch_nederland.Business;
using Console_app_moderator_exotisch_nederland.Models;

namespace Console_app_moderator_exotisch_nederland.Presentation
{
    internal class PresentationLogin
    {
        BusinessLogin _businessLogin = new BusinessLogin();

        public void Login()
        {
            Console.WriteLine("Gebruikersnaam: ");
            string InputGebruikersnaam = Console.ReadLine();
            Console.WriteLine("Wachtwoord: ");
            string InputWachtwoord = Console.ReadLine();

            User gebruiker = new User(InputGebruikersnaam, InputWachtwoord);


            string terugvoer = _businessLogin.BusinessLoginCheck(gebruiker);

            Console.WriteLine(terugvoer);
        }
    }
}
