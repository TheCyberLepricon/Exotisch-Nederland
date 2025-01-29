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


        public void HoofdDatabaseWaarnemingenInzien()
        {
            _business.HaalWaarnemingenOp();
            int AantalWaarnemingen = _business.AantalWaarnemingen();

           if (AantalWaarnemingen == 0)
            {
                Console.WriteLine("Er zijn geen waarnemingen in de database");
                Console.WriteLine("U wordt terug gestuurd naar het hoofdmenu \n");
            }
            else
            {
                _business.WaarnemingenBekijken();
            }
        }

        public void RegistratiesAanpassen()
        {
            _business.PasRegistratiesAan();
        }

        public void HoofdDatabaseRegistratiesInzien()
        {
            int AantalWaarnemingen = _business.AantalWaarnemingen();
            if (AantalWaarnemingen == 0)
            {
                Console.WriteLine("Er zijn geen waarnemingen in de database");
                Console.WriteLine("U wordt terug gestuurd naar het hoofdmenu\n");
            }
            else
            {
                Console.WriteLine("Van welke waarneming wil u de registraties inzien?");
                Console.WriteLine("Voer het getal hiervan in");
                foreach (var waarneming in _business.HaalWaarnemingenOp())
                {
                    Console.WriteLine($"{waarneming.WaarnemingId}: {waarneming.WaarnemingNaam}");
                }
                bool IncorrecteInvoer = true;
                while (IncorrecteInvoer)
                {
                    if (!int.TryParse(Console.ReadLine(), out int keuze))
                    {
                        Console.WriteLine("Ongeldige invoer, voer a.u.b. de getal in van uw keuze");
                    }
                    else
                    {
                        IncorrecteInvoer = false;
                        foreach (var registratie in _business.ZieRegistratiesHoofdDb(keuze))
                        {
                            registratie.RegistratieInformatie();
                        }
                    }
                }
            }
        }
            
        public void RegistratieToevoegenAanHoofdDb()
        {
           _business.TussenRegistratieVerwijderenOfToevoegen();
        }
           
        }
    }

