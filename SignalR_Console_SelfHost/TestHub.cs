using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Console_SelfHost
{
    public class TestHub:Hub
    {      

        public void SendMessage(string message)
        {
            Clients.All.PushMessage(message);
        }
    }
}
