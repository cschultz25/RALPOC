using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskList.Abstractions;
using TaskList.Models;
using TaskList.Services;
using Xamarin.Forms;

namespace TaskList.ViewModels
{
	public class TaskListViewModel : BaseViewModel
    { 
        private AzureCloudService CloudService = new AzureCloudService();
        private ICloudTable<TodoItem> CloudTable;

        public TaskListViewModel()
		{
            CloudTable = CloudService.GetTable<TodoItem>();

            Title = "Task List";

            //RefreshCommand = new Command(async () => await Refresh());
            //AddNewItemCommand = new Command(async () => await AddNewItem());
            //LogoutCommand = new Command(async () => await Logout());
            //LoadMoreCommand = new Command<TodoItem>(async (TodoItem item) => await LoadMore(item));

            // Subscribe to events from the Task Detail Page
            //MessagingCenter.Subscribe<TaskDetailViewModel>(this, "ItemsChanged", async (sender) =>
            //{
            //    await Refresh();
            //});

            // Execute the refresh command
            RefreshCommand.Execute(null);
        }

        bool hasMoreItems = true;

        public ICommand LoadMoreCommand { get; }

        ObservableCollection<TodoItem> items = new ObservableCollection<TodoItem>();
		public ObservableCollection<TodoItem> Items
		{
			get { return items; }
			set { SetProperty(ref items, value, "Items"); }
		}

		TodoItem selectedItem;
		public TodoItem SelectedItem
		{
			get { return selectedItem; }
			set
			{
				SetProperty(ref selectedItem, value, "SelectedItem");
				if (selectedItem != null)
				{
					Application.Current.MainPage.Navigation.PushAsync(new Pages.TaskDetail(selectedItem));
					SelectedItem = null;
				}
			}
		}

		Command refreshCmd;
		public Command RefreshCommand => refreshCmd ?? (refreshCmd = new Command(async () => await ExecuteRefreshCommand()));

		async Task ExecuteRefreshCommand()
		{
			if (IsBusy)
				return;
			IsBusy = true;

			try
			{
				var table = App.CloudService.GetTable<TodoItem>();
				var list = await table.ReadAllItemsAsync();
				Items.Clear();
				foreach (var item in list)
					Items.Add(item);
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"[TaskList] Error loading items: {ex.Message}");
			}
			finally
			{
				IsBusy = false;
			}
		}

		Command addNewCmd;
		public Command AddNewItemCommand => addNewCmd ?? (addNewCmd = new Command(async () => await ExecuteAddNewItemCommand()));

		async Task ExecuteAddNewItemCommand()
		{
			if (IsBusy)
				return;
			IsBusy = true;

			try
			{
				await Application.Current.MainPage.Navigation.PushAsync(new Pages.TaskDetail());
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"[TaskList] Error in AddNewItem: {ex.Message}");
			}
			finally
			{
				IsBusy = false;
			}
		}

		async Task RefreshList()
		{
			await ExecuteRefreshCommand();
			MessagingCenter.Subscribe<TaskDetailViewModel>(this, "ItemsChanged", async (sender) =>
			{
				await ExecuteRefreshCommand();
			});
		}
		/*
        async Task LoadMore(TodoItem item)
        {
            if (IsBusy)
            {
                Debug.WriteLine($"LoadMore: bailing because IsBusy = true");
                return;
            }

            // If we are not displaying the last one in the list, then return.
            if (!Items.Last().Id.Equals(item.Id))
            {
                Debug.WriteLine($"LoadMore: bailing because this id is not the last id in the list");
                return;
            }

            // If we don't have more items, return
            if (!hasMoreItems)
            {
                Debug.WriteLine($"LoadMore: bailing because we don't have any more items");
                return;
            }

            IsBusy = true;
            try
            {
                var list = await CloudTable.ReadItemsAsync(Items.Count, 20);
                if (list.Count > 0)
                {
                    Debug.WriteLine($"LoadMore: got {list.Count} more items");
                    Items.AddRange(list);
                }
                else
                {
                    Debug.WriteLine($"LoadMore: no more items: setting hasMoreItems= false");
                    hasMoreItems = false;
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("LoadMore Failed", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task Refresh()
        {
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                var identity = await CloudService.GetIdentityAsync();
                if (identity != null)
                {
                    var name = identity.UserClaims.FirstOrDefault(c => c.Type.Equals("name")).Value;
                    Title = $"Tasks for {name}";
                }
                var list = await CloudTable.ReadItemsAsync(0, 20);
                Items.ReplaceRange(list);
                hasMoreItems = true;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Items Not Loaded", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }*/
    }
}