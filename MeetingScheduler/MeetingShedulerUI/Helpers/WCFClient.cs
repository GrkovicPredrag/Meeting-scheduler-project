using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MeetingShedulerUI.Helpers
{
    public class WCFClient<T> : IDisposable
        where T : class
    {
        private T _proxy;
        private ChannelFactory<T> _factory;

        public T Proxy
        { 
            get { return _proxy; } 
            set { _proxy = value; }       
        }

        public WCFClient(string servicePath)
        {
            _factory = new ChannelFactory<T>(new NetTcpBinding(), new EndpointAddress(servicePath));
            Proxy = _factory.CreateChannel();
        }

        public void Dispose()
        {
            _factory.Close();
        }
    }
}
