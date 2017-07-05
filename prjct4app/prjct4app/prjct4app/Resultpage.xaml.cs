using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using People.Models;
using System.Collections.ObjectModel;
using prjct4app.WebServiceDetails;

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
        private RefineResults refine;
        private Iterator<WebServiceDetails.Result> resultlist;
        private Iterator<Event> eventlist;
        

        public Resultpage(DateTime date, int begintijd, int eindtijd, bool museum, bool restaurant, bool park, bool nightclub, bool shopping)
        {
            intresses = new List<string>();
            if (museum) { intresses.Add("Museum"); }
            if (park) { intresses.Add("Park"); }
            if (shopping) { intresses.Add("Shopping"); }
            if (restaurant) { intresses.Add("Restaurant"); }
            if (nightclub) { intresses.Add("Nightclub"); }

            
            ApiResult = new ReturnListApiResult(DaytoInt.daytoint(date.DayOfWeek), begintijd, eindtijd);


            //foreach (string intresse in intresses)
            //{
            //    //while (ApiResult.GetList().Visit(() => true, results => false))
            //    //{
            //    //    //ApiResult.AddToResultList()
            //    //}
            //}

            //ApiResult.GetList().Visit(() => { }, (results) => resultlist = results);

            //refine = new RefineResults(resultlist, begintijd, eindtijd);
            //eventlist = refine.Refine();


            InitializeComponent();
            OnGetButtonClicked(this, null);

        }

        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            //statusMessage.Text = "";

            //await App.PersonRepo.AddNewPersonAsync(newPerson.Text);
            //statusMessage.Text = App.PersonRepo.StatusMessage;
        }

        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            List<Result> UneListeDuResults = new List<Result>();
            PlaceDetails DetailGetter = new PlaceDetails();
            List<string> placeids = new List<string>();
            placeids.Add("ChIJvQBNdJ80xEcRmNuMeHpljHw");
            placeids.Add("ChIJ5URIl6I0xEcRdDTjK9tVy0Q");
            placeids.Add("ChIJxwEpkI00xEcRrRc-GRDUc0M");

            foreach (string placeid in placeids)
            {
                //var item = (await DetailGetter.PlaceDetailsWebRequest(placeid)).result;
                //if (Filter(item)) //filter maken die true of false returned aan de hand van of die hem wel of niet add aan de viewlist
                //{
                //    UneListeDuResults.Add(item);
                //}
                UneListeDuResults.Add((await DetailGetter.PlaceDetailsWebRequest(placeid)).result);
            }

            ObservableCollection<Result> UneListeDuResultsCollection = new ObservableCollection<Result>(UneListeDuResults);
            peopleList.ItemsSource = UneListeDuResultsCollection;
        }
    }
}