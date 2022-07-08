using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using azure_m.Models.RequestModels.Activitylog.List;
using azure_m.Models.ResponseModels;
using azure_m.Models;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;
using azure_m.Services;

namespace azure_m.ViewModels
{
    public class ActivitylogViewModel : BaseViewModel
    {
        public ActivitylogOperations activitylogOperations => DependencyService.Get<ActivitylogOperations>();
        public Dictionary<string, string> ImgMap = new Dictionary<string, string>()
        {
            ["Succeeded"] = "success.png",
            ["Failed"] = "failure.png",
            ["Started"]="success.png",
            ["Accepted"]="success.png",
        };
        public ObservableCollection<Activitylog> Activitylogs { get; }
        
        public Command LoadCommand { get; }
        public ActivitylogViewModel()
        {
            Title = "Activitylog";
            Activitylogs = new ObservableCollection<Activitylog>();

            LoadCommand = new Command(async () => await ExecuteLoadResourcesCommand());
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
        async Task ExecuteLoadResourcesCommand()
        {
            IsBusy = true;
            try
            {
                Activitylogs.Clear();
                await activitylogOperations.getActivitylogs();
                var activitylogs = activitylogOperations.Activitylogs;
                foreach (var activitylog in activitylogs)
                {
                    activitylog.imgUrl = ImgMap[activitylog.stautsValue];
                    Activitylogs.Add(activitylog);
                }
            }
            catch (Exception ex) { 
                Debug.WriteLine(ex);
            } 
            finally
            {
                IsBusy = false;
            }
        }
    }
}
