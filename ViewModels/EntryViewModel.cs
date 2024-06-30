using System.Threading.Tasks;
using System.Windows.Input;
using SaveUp.Models;
using Microsoft.Maui.Controls;

namespace SaveUp.ViewModels
{
    public class EntryViewModel : BaseViewModel
    {
        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private string _price;
        public string Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public EntryViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
        }

        private async void OnSave()
        {
            if (decimal.TryParse(Price, out decimal price))
            {
                var newItem = new SavedItem
                {
                    Description = Description,
                    Price = price
                };

                // Publish the new item using MessagingCenter
                MessagingCenter.Send(this, "AddItem", newItem);

                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid price", "OK");
            }
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
