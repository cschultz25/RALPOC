using TaskList.Models;
using TaskList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskList.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaskDetail : ContentPage
	{
		public TaskDetail(TodoItem item = null)
		{
			InitializeComponent();
			BindingContext = new TaskDetailViewModel(item);
		}
	}
}
