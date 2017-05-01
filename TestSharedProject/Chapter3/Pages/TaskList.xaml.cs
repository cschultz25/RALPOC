using Xamarin.Forms;

namespace TaskList3.Pages
{
    public partial class TaskList3 : ContentPage
    {
        public TaskList3()
        {
            InitializeComponent();
            BindingContext = new ViewModels.TaskList3ViewModel();
        }
    }
}
