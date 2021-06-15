using System;
using System.Threading;
using System.ServiceModel;
using AuthenticatorInterface;

//Done by R.W.A.D.U.Rajapakshe 20547312
namespace Authenticator
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceServer sv = new ServiceServer();
            //run the thread made in ClearTokenThread
            ClearTokenThread clear = new ClearTokenThread();
            Thread t1 = new Thread(new ThreadStart(clear.clearTokens));
            t1.Start();
            //making the server
            Console.WriteLine("Start Server");
            
            var host = new ServiceHost(typeof(ServiceServer));
            host.AddServiceEndpoint(typeof(ServiceInterface), new NetTcpBinding(), "net.tcp://0.0.0.0:8100/AuthenticationService");
            host.Open();
            Console.WriteLine("Hold server open");
            Console.ReadLine();
            host.Close();
        }
    }
}
