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
        private int begintijd;
        private int eindtijd;
        private bool kunst;
        private bool natuur;
        private bool architectuur;
        private bool restaurant;
        private bool overige;
        

        public InteressePage(DateTime date, TimeSpan begintijd, TimeSpan eindtijd)
        {
            InitializeComponent();
            this.date = date;
            this.begintijd = (begintijd.Hours*100) + (begintijd.Minutes);
            this.eindtijd = (eindtijd.Hours*100) + (eindtijd.Minutes);
           
        }



        public async void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "Doorgaan")
            {
                await DisplayAlert("begintijd", begintijd.ToString(), "cancel");
                await Navigation.PushModalAsync(new Resultpage(date, begintijd, eindtijd, Museum.IsToggled, Restaurant.IsToggled, Park.IsToggled, Nightclub.IsToggled, Shopping.IsToggled));
                //await DisplayAlert("Clicked", "page: " + button.Text + " bestaat nog niet", "Ok");
                //await DisplayAlert("datum", date.ToString(), "cancel");
                
                //await DisplayAlert("eindtijd", eindtijd.ToString(), "cancel");
                //await DisplayAlert("kunst", Kunst.IsToggled.ToString(), "cancel");
                //await DisplayAlert("natuur", Natuur.IsToggled.ToString(), "cancel");
                //await DisplayAlert("architectuur", Architectuur.IsToggled.ToString(), "cancel");
                //await DisplayAlert("restaurant", Restaurant.IsToggled.ToString(), "cancel");
                //await DisplayAlert("overig", Overige.IsToggled.ToString(), "cancel");
            }
        }
    }
}