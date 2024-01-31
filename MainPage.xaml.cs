using System.Diagnostics;

namespace XAMLMarkup
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void LoginButton_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Clicked !");
        }


    }

}
