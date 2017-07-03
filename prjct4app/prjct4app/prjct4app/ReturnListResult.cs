using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjct4app
{
    interface ReturnListResult<T>
    {
        void AddToResultList(WebServiceDetails.Result data);
        Option<List<T>> GetList();
    }

    class ReturnListApiResult : ReturnListResult<Event>
    {
        int Day;
        int Aankomsttijd;
        int Vertektijd;
        int MaxItems;
        public List<Event> datalijst = new List<Event>();
        

        public ReturnListApiResult(int day, int aankomsttijd, int vertrektijd)
        {
            this.Day = day;
            this.Aankomsttijd = aankomsttijd;
            this.Vertektijd = vertrektijd;
            this.MaxItems = 5;
        }

        public void AddToResultList(WebServiceDetails.Result data)
        {
            if (data.opening_hours.periods[Day].open.day == Day )
            {
                if(Convert.ToInt32(data.opening_hours.periods[Day].open.time) <= Aankomsttijd && Convert.ToInt32(data.opening_hours.periods[Day].close.time) >= Vertektijd)
                {
                    Event evnt = new Event(data.name, 0, 0, data.adr_address, data.types[0]);
                    datalijst.Add(evnt);
                }
            }   
        }

        public Option<List<Event>> GetList()
        {
            if(this.datalijst.Count >= MaxItems)
            {
                return new Some<List<Event>>(datalijst);
            }

            else
            {
                return new None<List<Event>>();
            }
        }

    }    

}
