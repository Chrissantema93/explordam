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
        private int begintijd { get; set; }
        private int eindtijd { get; set; }
        private List<string> intresses;
        private RefineResults refine { get; set; }


        

        public Resultpage(DateTime date, int begintijd, int eindtijd, bool museum, bool restaurant, bool park, bool nightclub, bool shopping)
        {
            this.begintijd = begintijd;
            this.eindtijd = eindtijd;
            intresses = new List<string>();
            if (museum) { intresses.Add("Museum"); }
            if (park) { intresses.Add("Park"); }
            if (shopping) { intresses.Add("Shopping"); }
            if (restaurant) { intresses.Add("Restaurant"); }
            if (nightclub) { intresses.Add("Nightclub"); }

            
    


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
            List<Resultaat> UneListeDuResults = new List<Resultaat>();
            PlaceDetails DetailGetter = new PlaceDetails();
            List<string> placeids = new List<string>();
            refine = new RefineResults(begintijd, eindtijd, DaytoInt.daytoint(date.DayOfWeek));
            placeids.Add("ChIJvQBNdJ80xEcRmNuMeHpljHw");
            //placeids.Add("ChIJvQBNdJ80xEcRmNuMeHpljHw");
            placeids.Add("ChIJ5URIl6I0xEcRdDTjK9tVy0Q");
            placeids.Add("ChIJxwEpkI00xEcRrRc-GRDUc0M");
            

            foreach (string placeid in placeids)
            {
                //var item = (await DetailGetter.PlaceDetailsWebRequest(placeid)).result;
                //if (Filter(item)) //filter maken die true of false returned aan de hand van of die hem wel of niet add aan de viewlist
                //{
                //    UneListeDuResults.Add(item);
                //}
                System.Diagnostics.Debug.WriteLine(placeid);
                refine.FilterAsync(UneListeDuResults, await DetailGetter.PlaceDetailsWebRequest(placeid));


            }
            for (int i = 0; i < UneListeDuResults.Count - 1; i++)
            {
                await UneListeDuResults[i].afstandresultaatAsync(UneListeDuResults[i+1]);
                System.Diagnostics.Debug.WriteLine("POPO" + UneListeDuResults[i].afstandvolgende);
            }
            ObservableCollection<Resultaat> UneListeDuResultsCollection = new ObservableCollection<Resultaat>(UneListeDuResults);
            peopleList.ItemsSource = UneListeDuResultsCollection;
        }
    }
}