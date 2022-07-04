using Notes.Models;
using Notes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Views
{
    public partial class MoviesPage : ContentPage
    {
        MovieService servico = new MovieService();

        public MoviesPage()
        {
            InitializeComponent();
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(e.NewTextValue.Length > 3)
            {
                List<Movie> filmes = await servico.LocalizarFilmesPorAtor(e.NewTextValue);

                if (filmes == null || filmes.Count == 0)
                {
                    lvwMovies.IsVisible = false;
                    lblmsg.IsVisible = true;
                    lblmsg.Text = "Não foi possivel retornar a lista de filmes";
                    lblmsg.TextColor = Color.Red;

                }
                else
                {
                    lvwMovies.IsVisible = true;
                    lblmsg.IsVisible = false;
                    lvwMovies.ItemsSource = filmes;
                }
            }
            else
            {
                lvwMovies.IsVisible = false;
                lblmsg.IsVisible = true;
                lblmsg.Text = "Digite pelos menos 4 caracteres";
            }
        }

        private async void lvwMovies_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null)
            {
                return;
            }

            var filme = e.SelectedItem as Movie;

            lvwMovies.SelectedItem = null;

            await Navigation.PushAsync(new MovieDetailsPage(filme));
        }
    }
}