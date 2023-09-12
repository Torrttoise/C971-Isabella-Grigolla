using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971_Isabella_Grigolla.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseInfo : ContentPage
    {
        public CourseInfo()
        {
            InitializeComponent();
        }

        async void AddNotes_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(page: new NotesAdd());
        }



    }
}