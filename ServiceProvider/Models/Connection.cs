using System.ServiceModel;
using AuthenticatorInterface;

//Done by R.W.A.D.U.Rajapakshe 20547312

namespace ServiceProvider.Models
{
    public class Connection
    {
        //got the idea from worksheet one
        //Make a connection with the authenticator
        private ServiceInterface foob;

        public ServiceInterface getConnection() {
            var chanFactory = new ChannelFactory<ServiceInterface>(new NetTcpBinding(), "net.tcp://localhost:8100/AuthenticationService");
            foob = chanFactory.CreateChannel();
            return foob;
        }
    }
}