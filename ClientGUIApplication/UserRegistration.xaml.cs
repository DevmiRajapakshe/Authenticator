using System;
using System.Windows;
using System.Windows.Controls;
using AuthenticatorInterface;
using System.ServiceModel;

namespace ClientGUIApplication
{
    //Done by R.W.A.D.U.Rajapakshe 20547312
    public partial class UserRegistration : Page
    {
        private ServiceInterface foob;
        public UserRegistration()
        {
            InitializeComponent();

            var channelFactory = new ChannelFactory<ServiceInterface>(new NetTcpBinding(), "net.tcp://localhost:8100/AuthenticationService");
            foob = channelFactory.CreateChannel();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            String response = foob.Register(Username.Text, Password.Password);
            Message.Text = response;
            Username.Text = "";
            Password.Password = null;
        }
    }
}
