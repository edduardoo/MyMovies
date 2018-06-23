using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyMovies
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieDetails : ContentPage
	{
		public MovieDetails (Movie movie)
		{
			InitializeComponent ();

            BindingContext = movie;
		}
	}
}