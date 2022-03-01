using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class Link
    {
        public delegate void LinkSuccessHandler(object o, LinkResultArguments e);
        public delegate void LinkHandler();
        public static event LinkSuccessHandler Succeeded;
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
                case "0":
                    Succeeded?.Invoke(null,new LinkResultArguments(0));
                    break;
                case "1":
                    Succeeded?.Invoke(null, new LinkResultArguments(1));
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
