using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace prjct4app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InteressePage : ContentPage
    {
        private DateTime date;
        private TimeSpan begintijd;
        private TimeSpan eindtijd;
        private bool kunst;
        private bool natuur;
        private bool architectuur;
        private bool restaurant;
        private bool overige;
        

        public InteressePage(DateTime date, TimeSpan begintijd, TimeSpan eindtijd)
        {
            InitializeComponent();
            this.date = date;
            this.begintijd = begintijd;
            this.eindtijd = eindtijd;
           
        }

        async void StartPageVisitor(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            if (button.Text == "Doorgaan")
            {
                //await Navigation.PushModalAsync(new InteressePage());
                await DisplayAlert("Clicked", "page: " + button.Text + " bestaat nog niet", "Ok");
                await DisplayAlert("datum", date.DayOfWeek.ToString(), "cancel");
                await DisplayAlert("begintijd", begintijd.ToString(), "cancel");
                await DisplayAlert("eindtijd", eindtijd.ToString(), "cancel");
                await DisplayAlert("kunst", Kunst.IsToggled.ToString(), "cancel");
                await DisplayAlert("natuur", Natuur.IsToggled.ToString(), "cancel");
                await DisplayAlert("architectuur", Architectuur.IsToggled.ToString(), "cancel");
                await DisplayAlert("restaurant", Restaurant.IsToggled.ToString(), "cancel");
                await DisplayAlert("overig", Overige.IsToggled.ToString(), "cancel");
            }
        }
    }
}