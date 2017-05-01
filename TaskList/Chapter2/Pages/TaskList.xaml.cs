using Xamarin.Forms;

namespace TaskList2.Pages
{
    public partial class TaskList2 : ContentPage
    {
        public TaskList2()
        {
            InitializeComponent();
            BindingContext = new ViewModels.TaskList2ViewModel();
        }
    }
}
