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
    }
}