using Console_app_moderator_exotisch_nederland.Presentation;

namespace Console_app_moderator_exotisch_nederland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PresentatieProgram _presentatie = new PresentatieProgram();
            int keuze;
            bool klaar = false;
            while (!klaar)
            {
                Console.WriteLine("Kies een optie:");
                Console.WriteLine("1. Nieuwe registraties bekijken" +
                    "\n2. Nieuwe registraties aanpassen" +
                    "\n3. Hoofddatabase inzien" +
                    "\n4. Afsluiten");

                if(!int.TryParse(Console.ReadLine(), out keuze) && keuze > 3 && keuze < 1) { Console.WriteLine("Voert u a.u.b een geldig getal in");}

                switch (keuze)
                {
                    case 1:
                        _presentatie.TussenDatabaseInzien();
                    break;
                    case 2:
                        _presentatie.RegistratiesAanpassen();
                    break;
                    case 3:
                        Console.WriteLine("Functie moet nog komen");
                    break;
                    case 4:
                        klaar = true;
                        break;

                }
            }
        }
    }
}
