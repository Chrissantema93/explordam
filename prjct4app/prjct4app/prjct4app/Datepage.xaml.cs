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
    public partial class Datepage : ContentPage
    {
        DateTime date;
        TimeSpan begintijd;
        TimeSpan eindtijd;

        public Datepage()
        {
            InitializeComponent();
            DatumSelector.MinimumDate = DateTime.Now.ToLocalTime();
            DatumSelector.Date = DateTime.Now.ToLocalTime();
        }
        //async void OnButtonClicked(object sender, EventArgs args)
        //{
        //    Button button = (Button)sender;
        //    await DisplayAlert("Clicked", "page: " + button.Text + " bestaat nog niet", "Ok");
        //}

        async void StartPageVisitor(object sender, EventArgs args)
        {
            Button button = (Button)sender;
<<<<<<< HEAD
            if (button.Text == "Doorgaan")
            {
                await Navigation.PushModalAsync(new InteressePage());
            }
=======
            await Navigation.PushAsync(new Results(date, begintijd, eindtijd));
            //await DisplayAlert("Clicked", "page: " + button.Text + " bestaat nog niet", "Ok");
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            date = e.NewDate;
        }

        //PropertyChanged wordt te vaak aangeroepen maar kan geen functie vinden voor alleen tijdchanged
        private void BeginTijd_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            begintijd = BeginTijd.Time;
        }

        private void EindTijd_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            eindtijd = EindTijd.Time;
>>>>>>> refs/remotes/origin/Functionality
        }
    }
}