using Console_app_exotisch_nederland.Presentatie;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
using System.Threading.Tasks;
public class LocationResponse
{
    public string ip { get; set; }
    public string country_code { get; set; }
    public string country_name { get; set; }
    public string region_code { get; set; }
    public string region_name { get; set; }
    public string city { get; set; }
    public string zip_code { get; set; }
    public string time_zone { get; set; }
    public decimal latitude { get; set; }
    public decimal longitude { get; set; }
    public int metro_code { get; set; }
}

namespace Console_app_exotisch_nederland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime currentDateTime = DateTime.Now;
            bool klaar = false;
            PresentatieProgram _presentatie = new PresentatieProgram();
            while(!klaar)
            {
                Console.WriteLine("Kies een optie:\n\t1. Nieuwe Organisme toevoegen\n\t2. Alle organismen bekijken\n\t" +
                    "3. Filteren op ...\n\t4. Afsluiten");
                int keuze;
                while(true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out keuze))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Voer een geldig getal in!");
                    }
                }
                if (keuze == 1)
                {
                    void DatumKrijgen()
                    {
                        Console.WriteLine(currentDateTime);
                        Console.ReadLine();
                    }
                    async void OrganismeLocatie()
                    {
                        using HttpClient client = new HttpClient();

                        try
                        {
                            string url = "https://freegeoip.app/json/";

                            Console.WriteLine("Locatie opvragen...");
                            string response = await client.GetStringAsync(url);

                            var locationData = JsonSerializer.Deserialize<LocationResponse>(response);

                            if (true)
                            {
                                Console.WriteLine($"Latitude: {locationData.latitude}");
                                Console.WriteLine($"Longitude: {locationData.longitude}");
                                Console.WriteLine($"Stad: {locationData.city}");
                                Console.WriteLine($"Land: {locationData.country_name}");

                            }
                        }
                        catch (HttpRequestException ex)
                        {
                            Console.WriteLine($"Netwerkfout: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Onverwachte fout: {ex.Message}");
                        }
                    }
                    Console.WriteLine("Is het een dier of plant?");
                    string dierOfPlant = Console.ReadLine();
                    if (dierOfPlant.ToLower() == "plant")
                    {
                        string PlantTypeVraag()
                        {
                            Console.WriteLine("Kies een van de volgende mogelijkheden van plantsoorten:");
                            Console.WriteLine("\t1. Varenachtigen\n\t2. Mosachtigen");
                            Console.WriteLine("\t3. Bloemplanten\n\t4. Naaktzadige");
                            Console.WriteLine("\t5. Onbekend/Geen idee");
                            string typePlantKeuze = Console.ReadLine();
                            if (typePlantKeuze.ToLower() == "varenachtigen" | typePlantKeuze == "1")
                            {
                                Console.WriteLine("Varenachtige Toegevoegd!");
                                return "Varenachtige";
                            }
                            else if (typePlantKeuze.ToLower() == "mosachtigen" | typePlantKeuze == "2")
                            {
                                Console.WriteLine("Mosachtige Toegevoegd!");
                                return "Mosachtige";
                            }
                            else if (typePlantKeuze.ToLower() == "bloemplanten" | typePlantKeuze == "3")
                            {
                                Console.WriteLine("Bloemplant Toegevoegd!");
                                return "Bloemplant";
                            }
                            else if (typePlantKeuze.ToLower() == "naaktzadige" | typePlantKeuze == "4")
                            {
                                Console.WriteLine("Naaktzadige Toegevoegd!");
                                return "Naaktzadige";
                            }
                            else if (typePlantKeuze.ToLower() == "onbekend" | typePlantKeuze == "5" | typePlantKeuze.ToLower() == "geen idee" | typePlantKeuze.ToLower() == "onbekend/geen idee")
                            {
                                Console.WriteLine("Onbekend! Toegevoegd!");
                                return "Onbekend";
                            }
                            else
                            {
                                Console.WriteLine("Geef een geldig antwoord!");
                                return PlantTypeVraag();
                            }
                        }
                        string PlantNaamVraag()
                        {
                            Console.WriteLine("Wat is de naam van de plant?");
                            Console.WriteLine("Vul de alledaagse term in of de wetenschappelijke term voor de plant.");
                            Console.WriteLine("Vul \"Onbekend\" als U geen idee heeft!");
                            string naamPlantKeuzeTemp = Console.ReadLine();
                            return naamPlantKeuzeTemp;
                        }
                        string PlantAfkomstVraag()
                        {
                            Console.WriteLine("Is de plant \"Inheems\" of \"Exoot\"?");
                            string afkomstPlantKeuze = Console.ReadLine();
                            if(afkomstPlantKeuze.ToLower() == "inheems")
                            {
                                return "Inheems";
                            }
                            else if (afkomstPlantKeuze.ToLower() == "exoot")
                            {
                                return "Exoot";
                            }
                            else
                            {
                                Console.WriteLine("Vul \"Inheems\" of \"Exoot\" in!");
                                return PlantAfkomstVraag();
                            }
                        }

                        PlantTypeVraag();
                        PlantNaamVraag();
                        PlantAfkomstVraag();
                        DatumKrijgen();
                        OrganismeLocatie();



                    }
                    else if (dierOfPlant.ToLower() == "dier")
                    {
                        string DierTypeVraag()
                        {
                            bool dierTypeVraagCheck = true;
                            while (dierTypeVraagCheck) {
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
                                else if(typeDierKeuzeTemp.ToLower() == "ongewerveld" | typeDierKeuzeTemp == "2")
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
                        string DierNaamVraag()
                        {
                            Console.WriteLine("Wat is de naam van het dier?");
                            Console.WriteLine("Vul de alledaagse term in of de wetenschappelijke term voor het dier.");
                            Console.WriteLine("Vul \"Onbekend\" als U geen idee heeft!");
                            string naamDierKeuzeTemp = Console.ReadLine();
                            return naamDierKeuzeTemp;
                        }
                        string DierAfkomstVraag()
                        {
                            Console.WriteLine("Is het dier \"Inheems\" of \"Exoot\"?");
                            string afkomstDierKeuze = Console.ReadLine();
                            if (afkomstDierKeuze.ToLower() == "inheems")
                            {
                                return "Inheems";
                            }
                            else if (afkomstDierKeuze.ToLower() == "exoot")
                            {
                                return "Exoot";
                            }
                            else
                            {
                                Console.WriteLine("Vul \"Inheems\" of \"Exoot\" in!");
                                return DierAfkomstVraag();
                            }
                        }
                        DierTypeVraag();
                        DierNaamVraag();
                        DierAfkomstVraag();
                        DatumKrijgen();
                        OrganismeLocatie();
                    }
                }
            }
        }
        
    }
}
