using Console_app_exotisch_nederland.Data;
namespace Console_app_exotisch_nederland.Business
{
    internal class BusinessProgram
    {
        DataProgram _dal = new DataProgram();
        public string Business()
        {
            return _dal.Testing();
        }
    }
}
