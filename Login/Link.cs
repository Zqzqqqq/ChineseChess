using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class Link
    {
        public delegate void LinkHandler();
        
        public static event LinkHandler Succeeded;
        public static event LinkHandler Failed;
        public static event LinkHandler Repeated;
        private SocketClient client;
        
        public Link(SocketClient client)
        {
            this.client = client;
        }

        public void linking(Object src, Object dest)
        {
            string res = client.StartClient((string)src, (string)dest);
            switch (res)
            {
                case "success":
                    Succeeded?.Invoke();

                    break;
                case "failure":
                    Failed?.Invoke();
                    break;
                case "name-repeated":
                    Repeated?.Invoke();
                    break;
            }
        }
    }
}
