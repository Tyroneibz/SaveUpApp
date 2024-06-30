using System.Collections.ObjectModel;
using System.Windows.Input;
using SaveUp.Models;
using Microsoft.Maui.Controls;

namespace SaveUp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<SavedItem> Items { get; }
        public ICommand AddNewEntryCommand { get; }
        public ICommand DeleteItemCommand { get; }

        private string _totalSaved;
        public string TotalSaved
        {
            get => _totalSaved;
            set => SetProperty(ref _totalSaved, value);
        }

        public MainViewModel()
        {
            Items = new ObservableCollection<SavedItem>();
            AddNewEntryCommand = new Command(OnAddNewEntry);
            DeleteItemCommand = new Command<SavedItem>(OnDeleteItem);

            LoadItemsAsync(); // Load entries when initializing ViewModel

            // Subscribe to the "AddItem" message from EntryViewModel
            MessagingCenter.Subscribe<EntryViewModel, SavedItem>(this, "AddItem", (sender, newItem) =>
            {
                Items.Add(newItem);
                UpdateTotalSaved();
            });
        }

        private async void LoadItemsAsync()
        {
            // Example: Add some dummy entries
            Items.Add(new SavedItem { Description = "Item 1", Price = 10.50m });
            Items.Add(new SavedItem { Description = "Item 2", Price = 25.75m });

            // Calculate the total saved amount
            UpdateTotalSaved();
        }

        private void UpdateTotalSaved()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Price;
            }
            TotalSaved = $"Total Saved: CHF {total:0.00}";
        }

        private async void OnAddNewEntry()
        {
            await Shell.Current.GoToAsync(nameof(Views.EntryPage));
        }

        private void OnDeleteItem(SavedItem item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
                UpdateTotalSaved();
            }
        }
    }
}
