using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;


namespace azure_m.ViewModels
{
    using Models.RequestModels.VN.CreateOrUpdate;
    using azure_m.Helpers;
    using Services;

    public class VNDetailsViewModel : BaseViewModel
    {
        #region 数据结构
        public Guid UID = Guid.NewGuid();

        public ObservableDictionary<string, string> subscribes { get; set; }

        public ObservableCollection<string> subscribesNames { get; set; }

        public string subscribeID;

        public ObservableCollection<string> resourceGroups { get; set; }


        public Command vnNameComplete { get; set; }

        public Command IPAddressComplete { get; set; }

        public ObservableCollection<string> AreaSources { get; set; }

        public Command CreateOrUpdateVN { get; set; }

        // public CreateOrUpdateVNRequest vn = new CreateOrUpdateVNRequest();
        #endregion

        #region 绑定

        public string ResourceGroup
        {
            get => vn.uri.resourceGroupName ?? string.Empty;
            set => vn.uri.resourceGroupName = value;
        }

        public string VNName
        {
            get => vn.uri.virtualNetworkName ?? string.Empty;
            set => vn.uri.virtualNetworkName = value;
        }

        public string AreaSource
        {
            get => vn.body.location ?? string.Empty;
            set => vn.body.location = value;
        }

        public string IPAddress
        {
            get => vn.body.properties.addressSpace.addressPrefixes[0] ?? string.Empty;
            set
            {
                vn.body.properties.addressSpace.addressPrefixes[0] = value;
                vn.body.properties.subnets[0].properties.addressPrefix = value;
            }
        }

        public string SubNetIPAddress
        {
            get => vn.body?.properties?.subnets[0]?.properties?.addressPrefix ?? string.Empty;
            set => vn.body.properties.subnets[0].properties.addressPrefix = value;
        }
        private CreateOrUpdateVNRequest vn = CreateOrUpdateVNRequest.create();
        #endregion

        public VNDetailsViewModel()
        {
#if DEBUG

            subscribes = new ObservableDictionary<string, string> { { "免费试用", "123" } };
            ////resourceGroups = new ObservableCollection<string> { "wfpres", "wfpppres" };
            //AreaSources = new ObservableCollection<string> { "Japaneast" };
#endif

            subscribesNames = new ObservableCollection<string>();

            resourceGroups = new ObservableCollection<string>();

            AreaSources = new ObservableCollection<string>();

            foreach (var key in subscribes.Keys)
            {
                subscribesNames.Add(key);
            }
            
            foreach(var val in QueryInfo.resourceGroups)
            {
                resourceGroups.Add(val.name);
            }

        }

        //public void OnAppearing(Object sender, EventArgs e)
        //{
        //    ResourceGroupOperations resourceGroupOperations = new ResourceGroupOperations();
        //    List<ResourceGroup> resourceGroupsRes = null;
        //    try
        //    {
        //        resourceGroupsRes = resourceGroupOperations.ListResourceGroup().Result;
        //    }
        //    catch (Exception ex)
        //    {
        //        Utils.error(ex);
        //    }
        //    foreach(var val in resourceGroupsRes)
        //    {
        //        resourceGroups.Add(val.name);
        //    }
        //}


        private void ChangeSubID(object sender, int i)
        {
            subscribes.TryGetValue(subscribesNames[i], out subscribeID);
        }
    }
}
