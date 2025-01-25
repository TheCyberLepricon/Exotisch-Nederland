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
                Console.WriteLine("1. Nieuwe Registraties bekijken" +
                    "\n2. Hoofddatabase inzien" +
                    "\n3. Afsluiten");

                if(!int.TryParse(Console.ReadLine(), out keuze) && keuze > 3 && keuze < 1) { Console.WriteLine("Voert u a.u.b een geldig getal in");}

                switch (keuze)
                {
                    case 1:
                        _presentatie.TussenDatabaseInzien();
                    break;
                    case 2:
                        Console.WriteLine("hoi");
                    break;
                    case 3:
                        klaar = true;
                    break;

                }
            }
        }
    }
}
