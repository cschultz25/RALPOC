using Xamarin.Forms;

namespace TaskList3.Pages
{
    public partial class TagsList : ContentPage
    {
        public TagsList()
        {
            InitializeComponent();
            BindingContext = new ViewModels.TagsListViewModel();
        }
    }
}
