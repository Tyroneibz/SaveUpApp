using SaveUp.Models;
using SaveUp.ViewModels;
using Microsoft.Maui.Controls;

namespace SaveUp.Views
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as SavedItem;
            var viewModel = BindingContext as MainViewModel;

            if (item != null && viewModel != null)
            {
                bool confirmDelete = await DisplayAlert(
                    "Confirm Delete",
                    $"Do you want to delete '{item.Description}'?",
                    "Yes",
                    "No"
                );

                if (confirmDelete)
                {
                    viewModel.DeleteItemCommand.Execute(item);
                }
            }
        }
    }
}
