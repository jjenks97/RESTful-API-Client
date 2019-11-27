using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using StarWars.Models;
using StarWars.Services;
using Xamarin.Forms;

namespace StarWars.ViewModels
{
    public class SpeciesViewModel : BaseViewModel
    {
        public ObservableCollection<Species> Species { get; set; }
        public Command LoadItemsCommand { get; set; }
        public SpeciesDataStore DataStore => new SpeciesDataStore(); 

        public SpeciesViewModel()
        {
            Title = "Species";
            Species = new ObservableCollection<Species>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Species.Clear();
                var species = await DataStore.GetItemsAsync(true);
                foreach (var species2 in species)
                {
                    Species.Add(species2);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
