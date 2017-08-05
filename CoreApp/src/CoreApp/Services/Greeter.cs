using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    public class Greeter : IGreeter
    {
        private IConfiguration _configuration;

        public Greeter(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetGreeting()
        {
            return _configuration["Greeting"];
        }
    }
}
