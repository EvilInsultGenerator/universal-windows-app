using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace evilinsult
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {

        DataTransferManager dataTransferManager;
        public HomePage()
        {
            this.InitializeComponent();

            dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += dataTransferManager_DataRequested;

            this.Loaded += HomePage_Loaded;
        }

        private void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            loaddata();
        }

        private void button_insult_Click(object sender, RoutedEventArgs e)
        {
            loaddata();
        }

        #region Load data from api

        

        

        string Url = "http://evilinsult.com/generate_insult.php?lang="+App.Lang;
        public async void loaddata()
        {
           

            progressring.Visibility = Visibility.Visible;

            if (!ConnectedToInternet())
            {
                MessageBox("Sorry Networrk Connection is not available.");
                // statustextBlock.Text = "";

            }
            else
            {
                HttpClient _client = new HttpClient();
                try
                {
                    HttpResponseMessage response = await _client.GetAsync(Url);
                    var jsonString = await response.Content.ReadAsStringAsync();


                    progressring.Visibility = Visibility.Collapsed;

                    tbInsult.Text = jsonString.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox("Unable to get data" + ex);

                    progressring.Visibility = Visibility.Collapsed;
                    tbInsult.Text = "";

                }

            }

        }


        #endregion Load data from api


        #region Network Availabiluty Status
        //Network Availabiluty Status
        public bool ConnectedToInternet()
        {
            ConnectionProfile InternetConnectionProfile =
                     NetworkInformation.GetInternetConnectionProfile();

            if (InternetConnectionProfile == null)
            {
                return false;
            }

            var level = InternetConnectionProfile.GetNetworkConnectivityLevel();

            return level == NetworkConnectivityLevel.InternetAccess;
        }


        #endregion Network Availabiluty Status

        #region MessageDialog
        //MessageDialog
        public async void MessageBox(string message)
        {

            var dialog = new MessageDialog(message.ToString());
            await dialog.ShowAsync();

        }


        #endregion MessageDialog


       

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem menu = sender as MenuFlyoutItem;
            if (menu != null)
            {

                if (menu.Text.Equals("English"))
                {
                    App.Lang = "en";
                }

                else if (menu.Text.Equals("German"))
                {

                    App.Lang = "de";
                }

                else if (menu.Text.Equals("French"))
                {

                    App.Lang = "fr";
                }

                else if (menu.Text.Equals("Spanish"))
                {
                    App.Lang = "es";
                }

                else if (menu.Text.Equals("Portuguese"))
                {
                    App.Lang = "pt";
                }
                else if (menu.Text.Equals("Russian"))
                {
                    App.Lang = "ru";
                }

                loaddata();
            }
        }


        #region Share Button

      

        void dataTransferManager_DataRequested(DataTransferManager sender,
    DataRequestedEventArgs args)
        {
            Uri sharedWebLink = new Uri("https://www.microsoft.com/en-gb/store/apps/ocumatic/9nblggh4rh0x");

            if (sharedWebLink != null)
            {
                DataPackage dataPackage = args.Request.Data;
                dataPackage.Properties.Title = "Evil Insult Generator";

                dataPackage.Properties.Description =
                    tbInsult.Text;


                dataPackage.SetWebLink(sharedWebLink);
            }
        }


        private void ShareButton_Click(object sender, RoutedEventArgs e)
        {
          
            DataTransferManager.ShowShareUI();
        }

        #endregion Share Button

    }
}