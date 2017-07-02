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
        private int begintijd;
        private int eindtijd;
        private List<string> intresses;
        private ReturnListApiResult ApiResult;
        private Iterator<WebServiceDetails.Result> resultlist;

        public Resultpage(DateTime date, int begintijd, int eindtijd, bool museum, bool restaurant, bool park, bool nightclub, bool shopping)
        {
            intresses = new List<string>();
            if (museum) { intresses.Add("Museum"); }
            if (restaurant) { intresses.Add("Restaurant"); }
            if (park) { intresses.Add("Park"); }
            if (nightclub) { intresses.Add("Nightclub"); }
            if (shopping) { intresses.Add("Shopping"); }

            ApiResult = new ReturnListApiResult(DaytoInt.daytoint(date.DayOfWeek), begintijd, eindtijd);

            foreach (string intresse in intresses)
            {
                while (ApiResult.GetList().Visit(() => true, results => false))
                {
                    //ApiResult.AddToResultList()
                }
            }

            ApiResult.GetList().Visit(() => { } , (results) => resultlist = results);
            
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