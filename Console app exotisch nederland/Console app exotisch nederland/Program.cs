using Console_app_exotisch_nederland.Presentatie;
using Console_app_exotisch_nederland.Models;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.Tracing;

namespace Console_app_exotisch_nederland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PresentatieProgram _presentatie = new PresentatieProgram();
            string words = _presentatie.Presentatie();
            void Test()
            {

                Console.WriteLine(words);
            }
            Test();
        }
        
    }
}
