using System;
namespace Registry.Models
{
    //Done by R.W.A.D.U.Rajapakshe 20547312
    public class ServiceModel
    {
        public string serviceName { get; set; }
        public string description { get; set; }
        public Uri apiEndpoint { get; set; }
        public int noOfOperands { get; set; }
        public string operandType { get; set; }
    }
}