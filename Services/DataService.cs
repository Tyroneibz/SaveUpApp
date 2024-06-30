using SaveUp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveUp.Services
{
    internal class DataService
    {
        internal static async Task<IEnumerable<object>> LoadItemsAsync()
        {
            throw new NotImplementedException();
        }

        internal static async Task SaveItemsAsync(ObservableCollection<SavedItem> items)
        {
            throw new NotImplementedException();
        }
    }
}
