using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Console_SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            WebApp.Start<Startup>("http://localhost:8282/");
            Console.WriteLine("SignalR is running under http://localhost:8282");
            Console.Read();
        }
    }
}
