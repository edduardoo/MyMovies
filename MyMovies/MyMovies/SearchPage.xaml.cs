using MyMovies.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyMovies
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchPage : ContentPage
	{
        //private const string ApiUrl = "https://api.themoviedb.org/3/search/movie?api_key=528c5207f17ce3bded1a31c2f6766e5b&query=Shrek&language=pt-BR";
        private const string ApiUrl = "https://api.themoviedb.org/3/search/movie?api_key=528c5207f17ce3bded1a31c2f6766e5b";

        private const string PosterBaseUrl = "https://image.tmdb.org/t/p/w200";
        private const string BannerBaseUrl = "http://image.tmdb.org/t/p/original";


        private HttpClient _apiClient = new HttpClient();

		public SearchPage ()
		{
			InitializeComponent ();

		}

        async protected override void OnAppearing()
        {
            //var data = await _apiClient.GetStringAsync(ApiUrl);
            //var result = JsonConvert.DeserializeObject<SearchResult>(data);

            //foreach (var movie in result.Movies)
            //{
            //    movie.ImageUrl = ImagePath + movie.ImageUrl;
            //}

            //listMovies.ItemsSource = result.Movies;

            base.OnAppearing();
        }

        private void OnMovieSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listMovies.SelectedItem == null)
                return;

            var move = e.SelectedItem as Movie;
            listMovies.SelectedItem = null;
            var page = new MovieDetails(move);


            Navigation.PushAsync(page);
        }

        async private void OnSearchPressed(object sender, TextChangedEventArgs e)
        {
            listMovies.IsRefreshing = true;
            var searchText = searchBox.Text;
            var searchUrl = ApiUrl + "&query=" + searchText + "&language=pt-BR";

            var data = await _apiClient.GetStringAsync(searchUrl);
            var result = JsonConvert.DeserializeObject<SearchResult>(data);

            if(result.Movies == null || result.Movies.Count == 0)
            {
                listMovies.ItemsSource = new List<Movie>();
                listMovies.IsVisible = false;
                lblNoResults.IsVisible = true;
                listMovies.IsRefreshing = false;
                return;
            }

            listMovies.IsVisible = true;
            lblNoResults.IsVisible = false;

            foreach (var movie in result.Movies)
            {
                movie.PosterUrl = PosterBaseUrl + movie.PosterUrl;
                movie.BannerUrl = BannerBaseUrl + movie.BannerUrl;
            }

            listMovies.ItemsSource = result.Movies;
            listMovies.IsRefreshing = false;
        }
    }
}