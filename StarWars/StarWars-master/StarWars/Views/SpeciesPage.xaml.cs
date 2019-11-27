using System;
using System.Collections.Generic;
using StarWars.ViewModels;
using Xamarin.Forms;

namespace StarWars.Views
{
    public partial class SpeciesPage : ContentPage
    {
        SpeciesViewModel viewModel;

        public SpeciesPage()
        {
            InitializeComponent();

            viewModel = new SpeciesViewModel();

            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Species.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}


