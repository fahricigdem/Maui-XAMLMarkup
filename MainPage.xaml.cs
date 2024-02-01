using System.Diagnostics;

namespace XAMLMarkup
{
    public partial class MainPage : ContentPage
    {

        string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
        Editor editor;

        public MainPage()
        {
            Debug.WriteLine("-->" + _fileName);

            var notesHeading = new Label() { Text="Notes", HorizontalOptions=LayoutOptions.Center, FontAttributes=FontAttributes.Bold };
            editor = new Editor() { Placeholder="Enter your note", HeightRequest=100};
            editor.Text = File.Exists(_fileName) ? File.ReadAllText(_fileName) : string.Empty;

            var buttonsGrid = new Grid() { HeightRequest= 40.0 };
            buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Auto) });
            buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(30.0, GridUnitType.Absolute) });
            buttonsGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.0, GridUnitType.Auto) });

            var saveButton = new Button() { Text ="Save", WidthRequest=100 };
            saveButton.Clicked += OnSaveButtonClicked;
            Grid.SetColumn(saveButton, 0);
            buttonsGrid.Children.Add(saveButton);

            var deleteButton = new Button() { Text ="Delete", WidthRequest=100 };
            deleteButton.Clicked += OnDeleteButtonClicked;
            Grid.SetColumn(deleteButton, 2);
            buttonsGrid.Children.Add(deleteButton);

            var stackLayout = new VerticalStackLayout
            {
                Padding = new Thickness(30, 60, 60, 30),
                Children = {notesHeading, editor, buttonsGrid}
            };

            this.Content = stackLayout;
        }

        private void OnSaveButtonClicked(object? sender, EventArgs e)
        {
            File.WriteAllText(_fileName, editor.Text);
        }
        private void OnDeleteButtonClicked(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }

}
