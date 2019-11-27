using System;
using System.Collections.Generic;
using StarWars.ViewModels;
using Xamarin.Forms;

namespace StarWars.Views
{
    public partial class PlanetPage : ContentPage
    {
        PlanetViewModel viewModel;

        public PlanetPage()
        {
            InitializeComponent();

            viewModel = new PlanetViewModel();

            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Planets.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}