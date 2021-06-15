using System.Windows;

namespace ClientGUIApplication
{
    //Done by R.W.A.D.U.Rajapakshe 20547312
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Navigate to the xaml page for register 
            var register = new UserRegistration();
            Main.NavigationService.Navigate(register);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Navigate to the xaml page for login
            Main.Content = new UserLogin();
        }
    }
}
