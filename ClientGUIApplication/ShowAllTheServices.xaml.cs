using System.Collections.Generic;
using System.Windows.Controls;
using Newtonsoft.Json;
using RestSharp;

namespace ClientGUIApplication
{
    //Done by R.W.A.D.U.Rajapakshe 20547312
    public partial class ShowAllTheServices : Page
    {
        public ShowAllTheServices(int token)
        {
            InitializeComponent();
            var client = new RestClient("https://localhost:44327/AllServices/getAllServices/" + token);
            var request = new RestRequest();
            var response = client.Get(request);
            List<string> val = new List<string>();
            val= JsonConvert.DeserializeObject<List<string>>(response.Content.ToString());
            foreach(string line in val)
            {
                ServiceModel obj = new ServiceModel();
                obj = JsonConvert.DeserializeObject<ServiceModel>(line);
            }
            
        }


    }
}
