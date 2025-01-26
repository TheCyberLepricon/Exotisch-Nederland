﻿using System;
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

        public int AantalTempRegistraties()
        {
            int AantalRegistraties = _data.TussenDatabaseOrganismenLijst().Count();
            return AantalRegistraties;
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
                Console.WriteLine("1.\"Naam\" \n2.\"Type\" \n3.\"Oorsprong\" \n4.\"Afkomst\" \n5.\"Beschrijving\" \n6. Geen");
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
                                registratie.HernoemOrganisme(NieuweNaam); // this is the lil bitch
                                Console.WriteLine($"Nieuwe naam van registratie: {registratie.NaamOrganisme}");

                            break;
                        case 2:
                                IncorrecteInvoer = false;
                                Console.WriteLine("Work in progress");
                            break;
                        case 3:
                                IncorrecteInvoer = false;
                                Console.WriteLine("Work in progress");
                            break;
                        case 4:
                            IncorrecteInvoer = false;
                            Console.WriteLine("Work in progress");
                            break;
                        case 5:
                                IncorrecteInvoer= false;
                                Console.WriteLine("Work in progress");
                            break;
                        case 6:
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
    }
}
