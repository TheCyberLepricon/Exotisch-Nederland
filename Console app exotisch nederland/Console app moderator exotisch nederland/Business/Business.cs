using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_app_moderator_exotisch_nederland.Data;
using Console_app_moderator_exotisch_nederland.Models;
using Console_app_moderator_exotisch_nederland.Presentation;

namespace Console_app_moderator_exotisch_nederland.Business
{
    internal class BusinessProgram
    {
        DataProgram _data = new DataProgram();


        public List<TussenDbOrganisme> HaalTussenDbOp()
        {
            return _data.HaalTussenDatabaseOp();
        }

        public List<Waarneming> HaalWaarnemingenOp()
        {
            return _data.HaalWaarnemingenOp();
        }

        public int AantalTempRegistraties()
        {
            int AantalRegistraties = _data.TussenDatabaseOrganismenLijst().Count();
            return AantalRegistraties;
        }

        public int AantalWaarnemingen()
        {
            int AantalWaarnemingen = _data.HaalWaarnemingenOp().Count();
            return AantalWaarnemingen;
        }

        public void WaarnemingenBekijken()
        {
            foreach (var waarneming in _data.HaalWaarnemingenOp())
            {
                waarneming.InformatieWaarneming();
                Console.WriteLine("\n Klik op enter om de volgende waarneming te bekijken \n");
                Console.ReadKey();
            }
        }
        public void TempRegistratiesBekijken()
        {
            foreach (var registratie in _data.TussenDatabaseOrganismenLijst())
            {
                registratie.InformatieOrganisme();
                Console.WriteLine("\nKlik op enter om de volgende registratie te bekijken \n");
                Console.ReadKey();
            }
        }

        public void PasRegistratiesAan()
        {
            var registraties = _data.TussenDatabaseOrganismenLijst();
            List<TussenDbOrganisme> tussenlijst = new List<TussenDbOrganisme>();
            foreach (var registratie in registraties)
            {
                registratie.InformatieOrganisme();
                bool IncorrecteInvoer = true;
                Console.WriteLine("Welke stukje data wil u aanpassen, voer hiervan het getal in:");
                Console.WriteLine("1.\"Naam\" \n2.\"Type\" \n3. \"Soort\" \n4.\"Oorsprong\" \n5.\"Afkomst\" \n6.\"Beschrijving\" \n7. Geen");
                while (IncorrecteInvoer)
                if (!int.TryParse(Console.ReadLine(), out int keuze))
                {
                    Console.WriteLine("Voer a.u.b een getal in");
                }
                else
                {
                    switch (keuze)
                    {
                        case 1:
                                IncorrecteInvoer = false;
                                Console.WriteLine($"Momentele naam van registratie: {registratie.NaamOrganisme}");
                                Console.WriteLine("Voer de nieuwe naam in de van de registratie:");
                                string NieuweNaam = Console.ReadLine();
                                registratie.HernoemOrganisme(NieuweNaam);
                                Console.WriteLine($"Nieuwe naam van registratie: {registratie.NaamOrganisme}");

                            break;
                        case 2:
                                IncorrecteInvoer = false;
                                Console.WriteLine($"Momentele type van registratie: {registratie.DierOfPlant}");
                                Console.WriteLine("Voer de nieuwe type in van de registratie:");
                                string NieuweType = Console.ReadLine();
                                registratie.VeranderType(NieuweType);
                                Console.WriteLine($"De nieuwe type van de registratie: {registratie.DierOfPlant}");
                            break;
                        case 3:
                                IncorrecteInvoer = false;
                                Console.WriteLine($"Momentele type van registratie: {registratie.Type}");
                                Console.WriteLine("Voer de nieuwe type in van de registratie:");
                                string NieuweSoort = Console.ReadLine();
                                registratie.VeranderSoort(NieuweSoort);
                                Console.WriteLine($"De nieuwe type van de registratie: {registratie.Type}");
                           break;
                        case 4:
                                IncorrecteInvoer = false;
                                Console.WriteLine($"Momentele type van registratie: {registratie.Oorsprong}");
                                Console.WriteLine("Voer de nieuwe type in van de registratie:");
                                string NieuweOorsprong = Console.ReadLine();
                                registratie.VeranderOorsprong(NieuweOorsprong);
                                Console.WriteLine($"De nieuwe type van de registratie: {registratie.Oorsprong}");
                           break;
                        case 5:
                            IncorrecteInvoer = false;
                                Console.WriteLine($"Momentele type van registratie: {registratie.Afkomst}");
                                Console.WriteLine("Voer de nieuwe type in van de registratie:");
                                string NieuweAfkomst = Console.ReadLine();
                                registratie.VeranderAfkomst(NieuweAfkomst);
                                Console.WriteLine($"De nieuwe type van de registratie: {registratie.Afkomst}");
                                break;
                        case 6:
                                IncorrecteInvoer= false;
                                Console.WriteLine($"Momentele type van registratie: {registratie.Beschrijving}");
                                Console.WriteLine("Voer de nieuwe type in van de registratie:");
                                string NieuweBeschrijving = Console.ReadLine();
                                registratie.VeranderBeschrijving(NieuweBeschrijving);
                                Console.WriteLine($"De nieuwe type van de registratie: {registratie.Beschrijving}");
                                break;
                        case 7:
                                IncorrecteInvoer = false;
                                Console.WriteLine("Volgende registratie wordt weergegeven");
                            break;
                    }

                }
                tussenlijst.Add(registratie);
                


            }
            _data.TussenDbAanpassen(tussenlijst);

            _data.HaalTussenDatabaseOp();
        }

        public List<Registratie> ZieRegistratiesHoofdDb(int id)
        {
            List<Registratie> _gekozenRegistraties = new List<Registratie>();
            foreach (var registratie in _data.HaalHoofdDatabaseRegistratiesOp())
            {
                if(registratie.WaarnemingId == id)
                {
                    _gekozenRegistraties.Add(registratie);
                }
            }
            return _gekozenRegistraties;

            
        }

        public void TussenRegistratieVerwijderenOfToevoegen()
        {
            
            
                var tussenregistraties = _data.TussenDatabaseOrganismenLijst();
                foreach ( var registratie in tussenregistraties)
                {
                    registratie.InformatieOrganisme();

                    Console.WriteLine("Wil u deze registratie toevoegen aan de hoofddatabase? j/n");
                    string keuze = Console.ReadLine();
                    bool IncorrecteInvoer = true;
                    while (IncorrecteInvoer)
                    {
                        switch (keuze.ToLower())
                        {


                            case "j":
                                IncorrecteInvoer = false;
                                int n = 0;
                                Waarneming gevondenWaarneming = null;
                                foreach (var waarneming in _data.HaalWaarnemingenOp())
                                {
                                    gevondenWaarneming = waarneming;

                                    if (waarneming.WaarnemingNaam == registratie.NaamOrganisme)
                                    {
                                        n++;
                                    }




                                }
                                if (n == 1)
                                {
                                    Console.WriteLine("Organisme staat al geregistreerd");
                                    Console.WriteLine("Registratie informatie wordt toegevoegd");
                                    _data.TussenRegistratieToevoegenAanHoofdDatabase(registratie, gevondenWaarneming);
                                    _data.RegistratieVerwijderenUitTussenDb(registratie);

                                }
                                else
                                {
                                    Console.WriteLine("Registratie is nog niet bekend binnen de database");
                                    Console.WriteLine("Waarneming en registratie informatie wordt toegevoegd aan database");
                                    _data.WaarnemingToevoegen(registratie);
                                    _data.TussenRegistratieToevoegenAanHoofdDatabase(registratie, gevondenWaarneming);
                                    _data.RegistratieVerwijderenUitTussenDb(registratie);

                                }
                                break;





                            case "n":
                                IncorrecteInvoer = false;

                                Console.WriteLine("Wil u deze registratie verwijderen uit de tussendatabase? j/n");
                                string Besluit = Console.ReadLine();
                                bool VerkeerdeInput = true;
                                while (VerkeerdeInput)
                                {
                                    switch (Besluit.ToLower())
                                    {
                                        case "j":
                                            VerkeerdeInput = false;
                                            _data.RegistratieVerwijderenUitTussenDb(registratie);
                                            Console.WriteLine("Registratie is verwijderd uit tussendatabase");
                                            break;
                                        case "n":
                                            VerkeerdeInput = false;
                                            Console.WriteLine("Volgende registratie wordt weergegeven");
                                            break;
                                        default:
                                            Console.WriteLine("Voer a.u.b");
                                            break;
                                    }
                                }

                                break;

                            default:

                                Console.WriteLine("Voer a.u.b. \"j\" of \"n\" in");
                                break;
                        }
                    }
                }
            }
    }
}
