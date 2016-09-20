using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.Email;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace evilinsult
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage(Frame frame)
        {
            this.InitializeComponent();
            this.ShellSplitView.Content = frame;
        }


        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            // ShellSplitView.CompactPaneLength = 48;
            this.ShellSplitView.IsPaneOpen = !this.ShellSplitView.IsPaneOpen;

        }
        private void HamburgerRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            // don't let the radiobutton check
            (sender as RadioButton).IsChecked = false;

            // toggle the splitview pane
            this.ShellSplitView.IsPaneOpen = !this.ShellSplitView.IsPaneOpen;
        }


        private void Home_Click(object sender, RoutedEventArgs e)
        {
            ((Frame)ShellSplitView.Content).Navigate(typeof(HomePage));

        }

        async private void Website_Click(object sender, RoutedEventArgs e)
        {
            // The URI to launch
            var uri = new Uri(@"http://evilinsult.com/");

            //// Set the option to show a warning
            //var promptOptions = new Windows.System.LauncherOptions();
            //promptOptions.TreatAsUntrusted = true;

            // Launch the URI
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        async private void Conact_Click(object sender, RoutedEventArgs e)
        {
            // Send an Email 

            EmailMessage email = new EmailMessage();

            email.To.Add(new EmailRecipient("marvin@evilinsult.com"));

            email.Subject = "Evil Insult Generator Contact";

            await EmailManager.ShowComposeNewEmailAsync(email);

        }

        async private void Facebook_Click(object sender, RoutedEventArgs e)
        {
            // The URI to launch
            var uri = new Uri(@"https://www.facebook.com/EvilInsultGenerator/");

            // Launch the URI
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        async private void Twitter_Click(object sender, RoutedEventArgs e)
        {
            // The URI to launch
            var uri = new Uri(@"https://twitter.com/__E__I__G__");

            // Launch the URI
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        async private void NewsLetter_Click(object sender, RoutedEventArgs e)
        {
            // The URI to launch
            var uri = new Uri(@"http://evilinsult.com/newsletter/");

            // Launch the URI
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }

       async private void Legal_Click(object sender, RoutedEventArgs e)
        {
            // The URI to launch
            var uri = new Uri(@"http://evilinsult.com/legal.pdf");

            // Launch the URI
            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
        }

       async private void Proposal_Click(object sender, RoutedEventArgs e)
        {
            // Send an Email 

            EmailMessage email = new EmailMessage();

            email.To.Add(new EmailRecipient("marvin@evilinsult.com"));

            email.Subject = "Evil Insult Generator Proposal";

            email.Body = "Hej fuckers,\n please add this beauty:\n \n insult: ...\n \n language: ... \n \n comment(optional): ... \n \n";

            await EmailManager.ShowComposeNewEmailAsync(email);
        }
    }
}
