using Xamarin.Forms;

namespace TaskList3.Pages
{
    public partial class EntryPage : ContentPage
    {
        public EntryPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.EntryPageViewModel();
        }
    }
}
