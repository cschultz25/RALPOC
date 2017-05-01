using Xamarin.Forms;

namespace TaskList3.Pages
{
    public partial class TagDetail : ContentPage
    {
        public TagDetail(Models.Tag item = null)
        {
            InitializeComponent();
            BindingContext = new ViewModels.TagDetailViewModel(item);
        }
    }
}
