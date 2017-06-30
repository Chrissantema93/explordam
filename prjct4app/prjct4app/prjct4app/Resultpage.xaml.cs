using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using People.Models;
using System.Collections.ObjectModel;

namespace prjct4app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Resultpage : ContentPage
    {
        private DateTime date;
        private TimeSpan begintijd;
        private TimeSpan eindtijd;
        private bool kunst;
        private bool natuur;
        private bool architectuur;
        private bool restaurant;
        private bool overige;
        public Resultpage(DateTime date, TimeSpan beginstijd, TimeSpan eindtijd, bool kunst, bool natuur, bool architectuur, bool restaurant, bool overige)
        {
            InitializeComponent();

        }

        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            await App.PersonRepo.AddNewPersonAsync(newPerson.Text);
            statusMessage.Text = App.PersonRepo.StatusMessage;
        }

        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            List<Person> pplList = await App.PersonRepo.GetAllPeopleAsync();

            ObservableCollection<Person> pplCollection = new ObservableCollection<Person>(pplList);
            peopleList.ItemsSource = pplCollection;
        }
    }
}