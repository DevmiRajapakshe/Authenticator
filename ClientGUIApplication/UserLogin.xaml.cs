using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using AuthenticatorInterface;
using System.ServiceModel;

namespace ClientGUIApplication
{
    //Done by R.W.A.D.U.Rajapakshe 20547312
    public partial class UserLogin : Page
    {
        private ServiceInterface foob;
        public UserLogin()
        {
            InitializeComponent();

            var channelFactory = new ChannelFactory<ServiceInterface>(new NetTcpBinding(), "net.tcp://localhost:8100/AuthenticationService");
            foob = channelFactory.CreateChannel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int response = foob.Login(Username.Text, Password.Password);
            if (response == -1)
            {
                Message.Text = "Unsuccessful Login";
                Username.Text = "";
                Password.Password = "";
            }
            else
            {
                Message.Text = "Login Successful";
                var show = new ShowAllTheServices(response);
                NavigationService.Navigate(show,response);
            }

        }
    }
}
