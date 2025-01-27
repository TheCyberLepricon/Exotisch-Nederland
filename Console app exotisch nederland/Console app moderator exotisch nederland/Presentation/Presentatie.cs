using System;
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
            _business.HaalTussenDbOp();
            int TussenRegistraties = _business.AantalTempRegistraties();
                        
            Console.WriteLine($"Er zijn {TussenRegistraties} registraties in de tussendatabase");
            if ( TussenRegistraties == 0)
            {
                Console.WriteLine("U wordt terug gestuurd naar het hoofdmenu");
            }
            else
            {

                NieuweRegistratiesBekijken();
                    
                
            }
                
        }
        
        
        
        public void NieuweRegistratiesBekijken()
        {
            _business.TempRegistratiesBekijken();
        }


        public void HoofdDatabaseInzien()
        {

        }

        public void RegistratiesAanpassen()
        {
            _business.PasRegistratiesAan();
        }
    }
}
