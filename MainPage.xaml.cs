using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace XAMLMarkup
{
    public partial class MainPage : ContentPage
    {
        string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

        public MainPage()
        {
            InitializeComponent();
            if (File.Exists(_fileName))
            {
                editor.Text = File.ReadAllText(_fileName);
            }
            SaveButton.Background = DeviceInfo.Platform == DevicePlatform.WinUI ? Colors.Red : Colors.Pink;
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("> Save button is clicked <");
            File.WriteAllText(_fileName, editor.Text);
        }
        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("> Delete button is clicked <");
            if (File.Exists(_fileName)) { File.Delete(_fileName); }
            File.Delete(_fileName);
            editor.Text = string.Empty;
            
        }
    }

}
