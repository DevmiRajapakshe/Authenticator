using System.ServiceModel;
using AuthenticatorInterface;

namespace Registry.Models
{
    //Done by R.W.A.D.U.Rajapakshe 20547312
    public class Connection
    {
        
        private ServiceInterface foob;

        //Make the connection with the authenticator
        public ServiceInterface getConnection()
        {
            var chanFactory = new ChannelFactory<ServiceInterface>(new NetTcpBinding(), "net.tcp://localhost:8100/AuthenticationService");
            foob = chanFactory.CreateChannel();
            return foob;
        }
    }
}