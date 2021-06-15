using System;

namespace ClientGUIApplication
{
    //Done by R.W.A.D.U.Rajapakshe 20547312
    class ServiceModel
    {
        public ServiceModel()
        {
            this.serviceName = "";
            this.description = "";
            this.apiEndpoint = new Uri("https://localhost:44374/");
            this.noOfOperands = 0;
            this.operandType = "";
        }

        public ServiceModel(string serviceName, string description, string apiEndpoint, int noOfOperands, string operandType)
        {
            this.serviceName = serviceName;
            this.description = description;
            this.apiEndpoint = new Uri(apiEndpoint);
            this.noOfOperands = noOfOperands;
            this.operandType = operandType;
        }

        public string serviceName { get; set; }
        public string description { get; set; }
        public Uri apiEndpoint { get; set; }
        public int noOfOperands { get; set; }
        public string operandType { get; set; }
    }
}
