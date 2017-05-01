using Xamarin.Forms;

namespace TaskList2.Pages
{
    public partial class TaskDetail : ContentPage
    {
        public TaskDetail(Models.TodoItem item = null)
        {
            InitializeComponent();
            BindingContext = new ViewModels.TaskDetailViewModel(item);
        }
    }
}
