using Console_app_moderator_exotisch_nederland.Presentation;

namespace Console_app_moderator_exotisch_nederland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PresentationLogin _presentationLogin = new PresentationLogin();

            _presentationLogin.Login();
        }
    }
}
