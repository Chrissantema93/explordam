using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace prjct4app
{
    class RefineResults
    {
        private Iterator<WebServiceDetails.Result> iterator;
        private ListIterator<Event> ListEvents = new ListIterator<Event>();
        WebServiceDetails.Result result;
        int aankomstijd;
        int vertrektijd;
        int totaletijd;
        int huidigetijd;
        bool museum;
        bool park;
        bool shopping;
        bool restaurant;
        bool nightclub;

        public RefineResults(Iterator<WebServiceDetails.Result> iterator, int aankomstijd, int vertrektijd)
        {
            this.aankomstijd = aankomstijd;
            this.vertrektijd = vertrektijd;
            this.totaletijd = vertrektijd - aankomstijd;
            this.huidigetijd = aankomstijd;
            this.iterator = iterator;
        }

        public Iterator<Event> Refine()
        {
            while (iterator.GetCurrent().Visit(() => false, (result) => true))
            {
                iterator.GetCurrent().Visit(() => { }, (result) => { this.result = result; });

                if (huidigetijd < (vertrektijd - 200))
                {
                    if (0 <= huidigetijd && huidigetijd < 1000)
                    {
                        foreach (string type in result.types)
                        {
                            if (type == "Park" && park)
                            {
                                park = false;

                                ListEvents.Add(new Event(result.name, huidigetijd, huidigetijd + 200, result.adr_address, type));

                            }
                        }
                    }

                    
                    if (1000 <= huidigetijd && huidigetijd < 1800)
                    {
                        foreach (string type in result.types)
                        {
                            if (type == "Museum" && museum)
                            {
                                museum = false;

                                ListEvents.Add(new Event(result.name, huidigetijd, huidigetijd + 200, result.adr_address, type));

                            }

                            if (type == "Shopping" && shopping)
                            {
                                shopping = false;

                                ListEvents.Add(new Event(result.name, huidigetijd, huidigetijd + 200, result.adr_address, type));

                            }

                            if (type == "Park" && park)
                            {
                                park = false;

                                ListEvents.Add(new Event(result.name, huidigetijd, huidigetijd + 200, result.adr_address, type));

                            }
                        }
                    }


                    if (1800 <= huidigetijd && huidigetijd < 2000)
                    {
                        foreach (string type in result.types)
                        {
                            if (type == "Restaurant" && restaurant)
                            {
                                restaurant = false;

                                ListEvents.Add(new Event(result.name, huidigetijd, huidigetijd + 200, result.adr_address, type));

                            }
                        }
                    }

                    if (2000 < huidigetijd)
                    {
                        foreach (string type in result.types)
                        {
                            if (type == "Restaurant" && restaurant)
                            {
                                restaurant = false;

                                ListEvents.Add(new Event(result.name, huidigetijd, huidigetijd + 200, result.adr_address, type));

                            }

                            if (type == "Nightclub" && nightclub)
                            {
                                nightclub = false;

                                ListEvents.Add(new Event(result.name, huidigetijd, huidigetijd + 200, result.adr_address, type));

                            }
                        }


                    }


                }
                huidigetijd = huidigetijd + 200;
            }
            return ListEvents;
        }
    }
}