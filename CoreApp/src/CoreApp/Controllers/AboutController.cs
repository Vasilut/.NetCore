using Microsoft.AspNetCore.Mvc;

namespace CoreApp
{
    public class AboutController
    {
        public string Phone()
        {
            return "555-111-122";
        }

        public string Adress()
        {
            return "Usa";
        }
    }
}
