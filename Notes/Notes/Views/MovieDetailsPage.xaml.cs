using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Views
{
    public partial class MovieDetailsPage : ContentPage
    {
        public MovieDetailsPage(Movie filmes )
        {
            if(filmes == null)
                throw new ArgumentNullException(nameof(filmes));

            InitializeComponent();

            BindingContext = filmes;
        }
    }
}