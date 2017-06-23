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
    public partial class InteressePage : ContentPage
    {
        public InteressePage()
        {
            InitializeComponent();
        }

        async void StartPageVisitor(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            if (button.Text == "Doorgaan")
            {
                //await Navigation.PushModalAsync(new InteressePage());
                await DisplayAlert("Clicked", "page: " + button.Text + " bestaat nog niet", "Ok");
            }
        }
    }
}