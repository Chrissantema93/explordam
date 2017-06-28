using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarindb.WebServiceDetails;
using Xamarindb.WebServiceDistance;


namespace Xamarindb
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            PlaceDetails placedetails = new PlaceDetails();
            PlaceDistance placedistance = new PlaceDistance();

            placedetails.PlaceDetailsWebRequest();
            placedistance.PlaceDistanceWebRequest();

            MainPage = new Xamarindb.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
