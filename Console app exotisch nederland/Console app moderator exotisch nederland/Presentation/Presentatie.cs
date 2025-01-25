using System;
using System.Collections.Generic;
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
                bool IncorrecteInvoer = false;
                while (!IncorrecteInvoer){
                    Console.WriteLine("Wilt u deze bekijken? j/n");
                    keuze = Console.ReadLine();
                    if (keuze.ToLower() == "j" || keuze.ToLower() == "n")
                    {
                        IncorrecteInvoer = true;
                        if (keuze == "j")
                        {
                            NieuweRegistratiesBekijken();
                        }
                        else if (keuze == "n")
                        {
                            Console.WriteLine("U wordt terug gestuurd naar het hoofdmenu");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Voer a.u.b 'j' of 'n' in.");
                    }
                }
            }
                
        }
        
        
        
        public void NieuweRegistratiesBekijken()
        {
            Console.WriteLine("Yippie het werkt tot nu toe");
        }


        public void HoofdDatabaseInzien()
        {

        }
    }
}
