using System;
using System.ServiceModel;

////Done by R.W.A.D.U.Rajapakshe 20547312
namespace AuthenticatorInterface
{
    //public interface for the .Net Server
    [ServiceContract]
    public interface ServiceInterface
    {
        [OperationContract]
        String Register(String name, String password);

        [OperationContract]
        int Login(String name, String password);

        [OperationContract]
        String validate(int token);
    }
}
