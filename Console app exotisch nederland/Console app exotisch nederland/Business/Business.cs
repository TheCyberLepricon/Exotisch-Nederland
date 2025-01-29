using Console_app_exotisch_nederland.Data;
using Console_app_exotisch_nederland.Models;
namespace Console_app_exotisch_nederland.Business
{
    public class BusinessProgram
    {
        DataProgram _dal = new DataProgram();
        
        public void VoegDierToe(Organisme.Dier dier)
        {
            _dal.VoegDierToe(dier);
        }
        public void VoegPlantToe(Organisme.Plant plant)
        {
            _dal.VoegPlantToe(plant);
        }
        public List<Organisme.TotaalOrganismes> AlleOrganismes()
        {
            return _dal.HaalAlleOrganismeSoortenOp();
        }

        public string NullCheck(string woord)
        {
            if(woord == null)
            {
                return "Null";
            }
            else
            {
                return woord;
            }
        }
        public string PlantType(string type)
        {
            if (type.ToLower() == "varenachtigen" | type == "1")
            {
                Console.WriteLine("Varenachtige Toegevoegd!");
                return "Varenachtige";
            }
            else if (type.ToLower() == "mosachtigen" | type == "2")
            {
                Console.WriteLine("Mosachtige Toegevoegd!");
                return "Mosachtige";
            }
            else if (type.ToLower() == "bloemplanten" | type == "3")
            {
                Console.WriteLine("Bloemplant Toegevoegd!");
                return "Bloemplant";
            }
            else if (type.ToLower() == "naaktzadige" | type == "4")
            {
                Console.WriteLine("Naaktzadige Toegevoegd!");
                return "Naaktzadige";
            }
            else if (type.ToLower() == "onbekend" | type == "5" | type.ToLower() == "geen idee" | type.ToLower() == "onbekend/geen idee")
            {
                Console.WriteLine("Onbekend! Toegevoegd!");
                return "Onbekend";
            }
            else
            {
                Console.WriteLine("Geef een geldig antwoord!");
                return "GGA";
                //Geen Geldig Antwoord
            }
        }
        public string PlantAfkomst(string afkomstPlant)
        {
            if (afkomstPlant.ToLower() == "inheems" | afkomstPlant == "1")
            {
                return "Inheems";
            }
            else if (afkomstPlant.ToLower() == "exoot" | afkomstPlant == "2")
            {
                return "Exoot";
            }
            else if (afkomstPlant.ToLower() == "onbekend" | afkomstPlant == "3")
            {
                return "Onbekend";
            }
            else
            {
                Console.WriteLine("Vul \"Inheems\", \"Exoot\" of \"Onbekend\" in!");
                return "GGA";
                //Geen Geldig Antwoord
            }
        }
        public string PlantOorsprong(string plantOorsprong)
        {
            if (plantOorsprong.ToLower() != "europa" | plantOorsprong.ToLower() != "afrika" | plantOorsprong.ToLower() != "azie" | plantOorsprong.ToLower() != "zuid amerika" |
                plantOorsprong.ToLower() != "noord amerika" | plantOorsprong.ToLower() != "antartica" | plantOorsprong.ToLower() != "oceanie")
            {
                return plantOorsprong;
            }
            else
            {
                Console.WriteLine("Voer een continent in!");
                return "GGA";
                //Geen Geldig Antwoord
            }
        }
        public string DierType()
        {
            bool dierTypeVraagCheck = true;
            while (dierTypeVraagCheck)
            {
                Console.WriteLine("Kies een van de volgende mogelijkheden voor dier soorten");
                Console.WriteLine("\t1. Gewerveld\n\t2. Ongwerveld\n\t3. Onbekend/Geen idee");
                string typeDierKeuzeTemp = Console.ReadLine();
                if (typeDierKeuzeTemp.ToLower() == "onbekend" | typeDierKeuzeTemp == "3" | typeDierKeuzeTemp.ToLower() == "geen idee" |
                    typeDierKeuzeTemp.ToLower() == "onbekend/geen idee")
                {
                    Console.WriteLine("Onbekend Toegevoegd!");
                    dierTypeVraagCheck = false;
                    return "Onbekend";
                }
                else if (typeDierKeuzeTemp.ToLower() == "gewerveld" | typeDierKeuzeTemp == "1")
                {
                    bool typeDierKeuzeCheck = true;
                    while (typeDierKeuzeCheck)
                    {
                        Console.WriteLine("Kies een van de volgende mogelijkheden voor dier soorten");
                        Console.WriteLine("\t1. Vis\n\t2. Amfibie\n\t3. Zoogdier" +
                            "\n\t4. Vogels\n\t5. Reptiel\n\t6. Obekend/Geen idee");
                        string typeDierKeuze = Console.ReadLine();
                        if (typeDierKeuze.ToLower() == "onbekend" | typeDierKeuze == "6" | typeDierKeuze.ToLower() == "geen idee" |
                        typeDierKeuze.ToLower() == "onbekend/geen idee")
                        {
                            Console.WriteLine("Gewerveld Toegevoegd!");
                            typeDierKeuzeCheck = false;
                            return "Gewerveld";
                        }
                        else if (typeDierKeuze.ToLower() == "vis" | typeDierKeuze == "1")
                        {
                            Console.WriteLine("Vis toegevoegd!");
                            typeDierKeuzeCheck = false;
                            return "Vis";
                        }
                        else if (typeDierKeuze.ToLower() == "amfibie" | typeDierKeuze == "2")
                        {
                            Console.WriteLine("Amfibie Toegevoegd!");
                            typeDierKeuzeCheck = false;
                            return "Amfibie";
                        }
                        else if (typeDierKeuze.ToLower() == "zoogdier" | typeDierKeuze == "3")
                        {
                            Console.WriteLine("Zoogdier Toegevoegd!");
                            typeDierKeuzeCheck = false;
                            return "Zoogdier";
                        }
                        else if (typeDierKeuze.ToLower() == "vogels" | typeDierKeuze == "4")
                        {
                            Console.WriteLine("Vogel Toegevoegd!");
                            typeDierKeuzeCheck = false;
                            return "Vogel";
                        }
                        else if (typeDierKeuze.ToLower() == "reptiel" | typeDierKeuze == "5")
                        {
                            Console.WriteLine("Reptiel Toegevoegd!");
                            typeDierKeuzeCheck = false;
                            return "Reptiel";
                        }
                        else
                        {
                            Console.WriteLine("Voer een gelidge optie in!");
                        }

                    }
                    dierTypeVraagCheck = false;


                }
                else if (typeDierKeuzeTemp.ToLower() == "ongewerveld" | typeDierKeuzeTemp == "2")
                {
                    bool typeDierKeuzeCheck = true;
                    while (typeDierKeuzeCheck)
                    {
                        Console.WriteLine("Kies een van de volgende mogelijkheden voor dier soorten");
                        Console.WriteLine("\t1. Spons\n\t2. Neteldier\n\t3. Weekdier" +
                            "\n\t4. Ringworm\n\t5. Platworm\n\t6. Stekelhuidig" +
                            "\n\t7. Geleedpotig\n\t8. Onbekend/Geen idee");
                        string typeDierKeuze = Console.ReadLine();
                        if (typeDierKeuze.ToLower() == "onbekend" | typeDierKeuze == "8" | typeDierKeuze.ToLower() == "geen idee" |
                        typeDierKeuze.ToLower() == "onbekend/geen idee")
                        {
                            Console.WriteLine("Ongewerveld Toegevoegd!");
                            typeDierKeuzeCheck = false;
                            return "Ongewerveld";
                        }
                        else if (typeDierKeuze.ToLower() == "spons" | typeDierKeuze == "1")
                        {
                            Console.WriteLine("Spons toegevoegd!");
                            typeDierKeuzeCheck = false;
                            return "Spons";
                        }
                        else if (typeDierKeuze.ToLower() == "neteldier" | typeDierKeuze == "2")
                        {
                            Console.WriteLine("Neteldier Toegevoegd!");
                            typeDierKeuzeCheck = false;
                            return "Neteldier";
                        }
                        else if (typeDierKeuze.ToLower() == "weekdier" | typeDierKeuze == "3")
                        {
                            Console.WriteLine("Weekdier Toegevoegd!");
                            typeDierKeuzeCheck = false;
                            return "Weekdier";
                        }
                        else if (typeDierKeuze.ToLower() == "ringworm" | typeDierKeuze == "4")
                        {
                            Console.WriteLine("Ringworm Toegevoegd!");
                            typeDierKeuzeCheck = false;
                            return "Ringworm";
                        }
                        else if (typeDierKeuze.ToLower() == "platworm" | typeDierKeuze == "5")
                        {
                            Console.WriteLine("Platworm Toegevoegd!");
                            typeDierKeuzeCheck = false;
                            return "Platworm";
                        }
                        else if (typeDierKeuze.ToLower() == "stekelhuidig" | typeDierKeuze == "6")
                        {
                            Console.WriteLine("Stekelhuidig Toegevoegd!");
                            typeDierKeuzeCheck = false;
                            return "Stekelhuidig";
                        }
                        else if (typeDierKeuze.ToLower() == "geleedpotig" | typeDierKeuze == "7")
                        {
                            Console.WriteLine("Geleedpotig Toegevoegd!");
                            typeDierKeuzeCheck = false;
                            return "Geleedpotig";
                        }
                        else
                        {
                            Console.WriteLine("Voer een gelidge optie in!");
                        }

                    }
                    dierTypeVraagCheck = false;
                }

            }

            return "";
        }
        public string DierOorsprong(string oorsprongDier)
        {
            if (oorsprongDier.ToLower() != "europa" | oorsprongDier.ToLower() != "afrika" | oorsprongDier.ToLower() != "azie" | oorsprongDier.ToLower() != "zuid amerika" |
                oorsprongDier.ToLower() != "noord amerika" | oorsprongDier.ToLower() != "antartica" | oorsprongDier.ToLower() != "oceanie")
            {
                return oorsprongDier;
            }
            else
            {
                Console.WriteLine("Voer een geldige optie in!");
                return "GGA";
                //Geen Geldig Antwoord
            }
        }
        public string DierAfkomst(string afkomstDier)
        {
            if (afkomstDier.ToLower() == "inheems" | afkomstDier == "1")
            {
                return "Inheems";
            }
            else if (afkomstDier.ToLower() == "exoot" | afkomstDier == "2")
            {
                return "Exoot";
            }
            else if (afkomstDier.ToLower() == "onbekend" | afkomstDier == "3")
            {
                return "Onbekend";
            }
            else
            {
                Console.WriteLine("Vul \"Inheems\", \"Exoot\" of \"Onbekend\" in!");
                return "GGA";
                //Geen Geldig Antwoord
            }
        }
        public string GeenGeldigeKeuze()
        {
            Console.WriteLine("Geen geldige keuze!");
            return "GGA";
        }






        

    }
}
