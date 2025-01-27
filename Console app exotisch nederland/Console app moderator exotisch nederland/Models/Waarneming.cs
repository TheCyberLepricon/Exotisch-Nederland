using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_app_moderator_exotisch_nederland.Models
{
    internal class Waarneming
    {
        public int WaarnemingId { get; private set; }
        public string WaarnemingNaam { get; private set; }
        public string DierOfPlant {  get; private set; }
        public string Soort {  get; private set; }
        public string Afkomst { get; private set; }
        public string Oorsprong { get; private set; }
        public int AantalRegistraties { get; private set; }

        public Waarneming(int waarnemingId, string waarnemingNaam, string dierOfPlant, string soort, string afkomst, string oorsprong, int aantalRegistraties)
        {
            WaarnemingId = waarnemingId;
            WaarnemingNaam = waarnemingNaam;
            DierOfPlant = dierOfPlant;
            Soort = soort;
            Afkomst = afkomst;
            Oorsprong = oorsprong;
            AantalRegistraties = aantalRegistraties;
        }

        public void InformatieWaarneming()
        {
            Console.WriteLine("Gegevens organisme:");
            Console.WriteLine($"|Waarneming id: {WaarnemingId}\n" +
                $"| Naam: {WaarnemingNaam}\n" +
                $"| Type organisme: {DierOfPlant}\n" +
                $"| Soort: {Soort}\n" +
                $"| Oorsprong: {Oorsprong}\n" +
                $"| Afkomst: {Afkomst}\n" +
                $"| Aantal registraties: {AantalRegistraties}\n");
        }

    }
}
