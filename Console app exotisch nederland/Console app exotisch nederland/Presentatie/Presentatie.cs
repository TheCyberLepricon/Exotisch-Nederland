using Console_app_exotisch_nederland.Business;
namespace Console_app_exotisch_nederland.Presentatie
{
    internal class PresentatieProgram
    {
        
        BusinessProgram _business = new BusinessProgram();
        public string Presentatie()
        {
            return _business.Business();
        }


        public string PlantTypeAntwoord()
        {
            Console.WriteLine("Kies een van de volgende mogelijkheden van plantsoorten:");
            Console.WriteLine("\t1. Varenachtigen\n\t2. Mosachtigen");
            Console.WriteLine("\t3. Bloemplanten\n\t4. Naaktzadige");
            Console.WriteLine("\t5. Onbekend/Geen idee");
            string typePlantKeuze = _business.PlantType(Console.ReadLine());
            if(typePlantKeuze == "GGA")
            {
                return PlantTypeAntwoord();
            }
            else
            {
                return typePlantKeuze;
            }
        }
        public string PlantNaamAntwoord(string plantNaam)
        {
            string nullChecked = _business.NullCheck(plantNaam);
            if (nullChecked == "Null")
            {
                Console.WriteLine("Vul iets in!");
                return PlantNaamAntwoord(plantNaam);
            }
            else
            {
                return plantNaam;
            }
        }
        public string PlantAfkomstAntwoord(string afkomstPlantKeuze)
        {
            string afkomstPlant = _business.PlantAfkomst(afkomstPlantKeuze);
            if (afkomstPlant == "GGA")
            {
                return PlantAfkomstAntwoord(afkomstPlantKeuze);
            }
            else
            {
                return afkomstPlant;
            }
        }
        public string PlantOorsprongAntwoord(string oorsprongPlant)
        {
            string plantOorsprong = _business.PlantOorsprong(oorsprongPlant);
            if(plantOorsprong == "GGA")
            {
                return PlantOorsprongAntwoord(oorsprongPlant);
            }
            else
            {
                return plantOorsprong;
            }
        }

        public string DierTypeAntwoord()
        {
            return _business.DierType();
        }
        public string DierNaamAntwoord(string dierNaam)
        {
            string dierNaamChecked = _business.NullCheck(dierNaam);
            if ( dierNaamChecked == "Null")
            {
                return DierNaamAntwoord(dierNaam);
            }
            else
            {
                return dierNaamChecked;
            }

        }
        public string DierOorsprongAntwoord(string oorsprongDier)
        {
            string oorsprongDierChecked = _business.DierOorsprong(oorsprongDier);
            if(oorsprongDierChecked == "GGA")
            {
                return DierOorsprongAntwoord(oorsprongDier);
            }
            else
            {
                return oorsprongDierChecked;
            }
        }
        public string DierAfkomstAntwoord(string afkomstDierKeuze)
        {
            string afkomstDier = _business.PlantAfkomst(afkomstDierKeuze);
            if (afkomstDier == "GGA")
            {
                return PlantAfkomstAntwoord(afkomstDierKeuze);
            }
            else
            {
                return afkomstDier;
            }
        }
    }
}