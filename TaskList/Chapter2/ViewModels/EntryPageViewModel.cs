﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TaskList2.Abstractions;
using TaskList2.Helpers;
using TaskList2.Models;
using Xamarin.Forms;

namespace TaskList2.ViewModels
{
    public class EntryPageViewModel : BaseViewModel
    {
        public EntryPageViewModel()
        {
            Title = "Task List";
            User = new Models.User { Username = "", Password = "" };
            AppService = Locations.AppServiceUrl;

            LoginCommand = new Command(async () => await ExecuteLoginCommand());
        }

        public Command LoginCommand { get; } 
        public Models.User User { get; set; }
        public string AppService { get; set; }

        async Task ExecuteLoginCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                var cloudService = ServiceLocator.Instance.Resolve<ICloudService>();
                //await cloudService.LoginAsync(User);
                await cloudService.LoginAsync();
                Application.Current.MainPage = new NavigationPage(new Pages.TaskList2());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Login Failed", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
