using System;
using Newtonsoft.Json;
using RestSharp;
using AuthenticatorInterface;
using System.ServiceModel;

//Done by R.W.A.D.U.Rajapakshe 20547312
namespace ServicePublishing
{
    public class Program
    {
        private ServiceInterface foob;
        static int token = -1;

        public ServiceInterface getConnection() {
            var chanFactory = new ChannelFactory<ServiceInterface>(new NetTcpBinding(), "net.tcp://localhost:8100/AuthenticationService");
            foob = chanFactory.CreateChannel();
            return foob;
        }
        public static void Main(string[] args)
        {
             getPublishData();
            //unPublishData();
            //Program p = new Program();
            //p.login();
        }

        //make an object of the Publish model which will be serialized later for publishing
        public PublishModel getObject() {
            string serviceName,description,endPoint,operandType;
            Uri APIEndpoint;
            int noOfOperands;

            Console.WriteLine("Enter the service name: ");
            serviceName = Console.ReadLine();

            Console.WriteLine("Enter the description");
            description = Console.ReadLine();

            APIEndpoint = new Uri("https://localhost:44327/");
            Console.WriteLine("Enter the Api Endpoint");
            try
            {
                endPoint = Console.ReadLine();
                APIEndpoint = new Uri(endPoint);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            noOfOperands = -1;
            Console.WriteLine("Enter the number of operands");
            try
            {
                noOfOperands = Int16.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Enter the operand type");
            operandType = Console.ReadLine();

            PublishModel pm = new PublishModel();
            pm.serviceName = serviceName;
            pm.description = description;
            pm.apiEndpoint = APIEndpoint;
            pm.noOfOperands = noOfOperands;
            pm.operandType = operandType;

            return pm;
        }

        //publish the data after making the connection with asp.net
        public static void getPublishData()
        {
            var getDetails = new Program();

            string value = JsonConvert.SerializeObject(getDetails.getObject());

            var client = new RestClient("https://localhost:44327/Service/getDetails/?token="+token+"&result=" + value);
            var request = new RestRequest();
            var response = client.Get(request);
            Console.WriteLine(response.Content.ToString());
            Console.ReadLine();
        }


        //unpublish the data according to the uri
        public static void unPublishData()
        {
            String endPoint;
            Uri APIEndpoint = new Uri("https://localhost:44327/Unpublish");
            Console.WriteLine("Enter the Api Endpoint to unpublish");
            try
            {
                endPoint = Console.ReadLine();
                APIEndpoint = new Uri(endPoint);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            var client = new RestClient("https://localhost:44327/Unpublish/unpublishData/?token="+token+"&val=" + APIEndpoint.ToString());
            var request = new RestRequest();
            var response = client.Get(request);
            Console.WriteLine(response.Content.ToString());
            Console.ReadLine();
        }


        //invoke registration in the service interface by making a connection
        public void registration()
        {
            string name, password;

            Console.WriteLine("Enter the userName: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter the password");
            password = Console.ReadLine();

            Program p = new Program();
            ServiceInterface sInterface = p.getConnection();
            sInterface.Register(name, password);
        }


        //invoke login in the service interface by making a connection
        public void login()
        {
            string name, password;

            Console.WriteLine("Enter the userName: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter the password");
            password = Console.ReadLine();

            Program p = new Program();
            ServiceInterface sInterface = p.getConnection();
            token = sInterface.Login(name, password);

        }

    }
}