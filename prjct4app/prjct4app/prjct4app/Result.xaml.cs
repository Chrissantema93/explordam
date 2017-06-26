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
    public partial class Result : ContentPage
    {
        public Result(DateTime datum1, TimeSpan begintijd1, TimeSpan eindtijd1)
        {
            

            InitializeComponent();

            datum.Text = datum1.ToString("d");
            begintijd.Text = begintijd1.ToString();
            eindtijd.Text = eindtijd1.ToString();
        }
    }
}