using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using prjct4app.WebServiceDetails;


namespace prjct4app
{
    class RefineResults
    {
        int aankomsttijd { get; set; }
        int vertrektijd { get; set; }
        int day { get; set; }
        int totaletijd { get; set; }
        int huidigetijd { get; set; }
        RootObject rootobject { get; set; }
        bool museum = true;
        bool park = true;
        bool shopping = true;
        bool restaurant = true;
        bool nightclub = true;
        PlaceDetails placedetails = new PlaceDetails();

        public RefineResults(int aankomsttijd, int vertrektijd, int day)
        {
            this.day = day;
            this.aankomsttijd = aankomsttijd;
            this.vertrektijd = vertrektijd;
            this.totaletijd = vertrektijd - aankomsttijd;
            this.huidigetijd = aankomsttijd;
        }

        public async Task FilterAsync(List<Resultaat> resultaatlijst, RootObject rootobject) //List<string> placeids)
        {

            //foreach (string placeid in placeids)
            //{
            //    rootobject = await placedetails.PlaceDetailsWebRequest(placeid);
                


                try
                {
                    Debug.WriteLine(Convert.ToInt32(rootobject.result.opening_hours.periods[0].open.time).ToString() + " " + aankomsttijd.ToString());
                    Debug.WriteLine(Convert.ToInt32(rootobject.result.opening_hours.periods[0].close.time).ToString() + " " + vertrektijd.ToString());
                    if (aankomsttijd <= Convert.ToInt32(rootobject.result.opening_hours.periods[day].open.time) || Convert.ToInt32(rootobject.result.opening_hours.periods[0].close.time) >= vertrektijd)
                    {

                        foreach (string type in rootobject.result.types)
                        {
                            Debug.WriteLine(rootobject.result.name + " " + type);

                            if (type == "park" || type == "art_galary" && park)
                            {
                                park = false;

                                resultaatlijst.Add(new Resultaat(rootobject));

                            }

                            else if (type == "museum" && museum)
                            {
                                museum = false;

                                resultaatlijst.Add(new Resultaat(rootobject));
                            }

                            if (type == "shopping" && shopping)
                            {
                                shopping = false;
                                resultaatlijst.Add(new Resultaat(rootobject));


                            }

                            if (type == "restaurant" && restaurant)
                            {
                                restaurant = false;

                                resultaatlijst.Add(new Resultaat(rootobject));

                            }

                            if (type == "nightclub" && nightclub)
                            {
                                nightclub = false;

                                resultaatlijst.Add(new Resultaat(rootobject));

                            }
                        }

                    }
                }

                catch { }
            //}
        }
    }
}