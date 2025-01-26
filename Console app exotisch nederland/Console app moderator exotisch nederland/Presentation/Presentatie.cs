﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_app_moderator_exotisch_nederland.Business;

namespace Console_app_moderator_exotisch_nederland.Presentation
{
    internal class PresentatieProgram
    {
        BusinessProgram _business = new BusinessProgram();

        public void TussenDatabaseInzien()
        {
            int TussenRegistraties = _business.AantalTempRegistraties();
                        
            Console.WriteLine($"Er zijn {TussenRegistraties} registraties in de tussendatabase");
            if ( TussenRegistraties == 0)
            {
                Console.WriteLine("U wordt terug gestuurd naar het hoofdmenu");
            }
            else
            {
                string keuze;
                bool Loop = false;
                while (!Loop){
                    Console.WriteLine("Wilt u de bekijken of toevoegen aan hoofddatabase?");
                    Console.WriteLine("Kies \"bekijken\" of \"toevoegen\"");
                    keuze = Console.ReadLine();

                    switch (keuze.ToLower())
                    {
                        case "bekijken":
                            Loop = true;
                            NieuweRegistratiesBekijken();
                            break;
                        case "toevoegen":
                            Loop = true;
                            RegistratiesToevoegen();
                            break;
                        default:
                            Console.WriteLine("Ongeldig antwoord");
                            break;
                            


                    }
                    
                }
            }
                
        }
        
        
        
        public void NieuweRegistratiesBekijken()
        {
            _business.TempRegistratiesBekijken();
        }


        public void HoofdDatabaseInzien()
        {

        }

        public void RegistratiesToevoegen()
        {

        }
    }
}
