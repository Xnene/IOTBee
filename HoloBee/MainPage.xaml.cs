using Windows.System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using System.Net;
using Windows.Networking.Connectivity;
using System;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IOTBee
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // globalni ticker pro cas 
        DispatcherTimer timer = new DispatcherTimer();

        private string GetLocalIp()
        {
            var icp = NetworkInformation.GetInternetConnectionProfile();

            if (icp?.NetworkAdapter == null) return "IP not set";
            var hostname =
                NetworkInformation.GetHostNames()
                    .SingleOrDefault(
                        hn =>
                            hn.IPInformation?.NetworkAdapter != null && hn.IPInformation.NetworkAdapter.NetworkAdapterId
                            == icp.NetworkAdapter.NetworkAdapterId);

            // the ip address
            return hostname?.CanonicalName;
        }

        private void dispatcherTimer_Tick()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
            // code goes here
        }
        void timer_Tick(object sender, object e)
        {
            TimeTextBlock.Text = DateTime.Now.ToString(" dd.MM.yyyy H:mm:ss");
        }


        public MainPage()
        {

            
            this.InitializeComponent();
            // pustime hodiny
            dispatcherTimer_Tick();
            // dame si sem IP adresu
            IPTextBlock.Text = GetLocalIp();
            WebBrowser.Navigate(new Uri("https://app.sunware.cz/datalogger/maxfreq"));
            IpTogleSwitch.IsOn = true;


        }

   


        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            WebBrowser.Navigate(new Uri("https://app.sunware.cz/datalogger/vcely_teplota"));

        }


        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            WebBrowser.Navigate(new Uri("https://app.sunware.cz/datalogger/dashboard.php?id=17"));

        }

        private void Button_Click_maxFreq(object sender, RoutedEventArgs e)
        {            WebBrowser.Navigate(new Uri("https://app.sunware.cz/datalogger/maxfreq"));
            
        }

        private void ButtonBeeEvent_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser.Navigate(new Uri("http://beeevent.netsecure.cz"));
        }

     

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser.Navigate(new Uri("http://www.sunware.cz"));
        }

        private void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e)
        {
            WebBrowser.Navigate(new Uri("http://www.netsecure.cz"));
        }

        private void MenuFlyoutItem_Click_2(object sender, RoutedEventArgs e)
        {
            WebBrowser.Navigate(new Uri("http://beeevent.netsecure.cz"));
        }

        private void ButtonF24_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser.Navigate(new Uri("https://app.sunware.cz/datalogger/vcely_frekvence1"));
        }

        private void ButtonF242_Click(object sender, RoutedEventArgs e)
        {
            WebBrowser.Navigate(new Uri("https://app.sunware.cz/datalogger/vcely_frekvence2"));
        }

        private void OnOffIP(bool enabledisable)
        {
            if (enabledisable == true)
            {
                IPTextBlock.Visibility = Visibility.Visible;
                IPTextBlock.Text = GetLocalIp();
                IpTogleSwitch.IsOn = true;
                ShowIP.IsChecked = true;
            }
            else
            {
                IPTextBlock.Visibility = Visibility.Collapsed;
                IPTextBlock.Text = "";
                IpTogleSwitch.IsOn = false;
                ShowIP.IsChecked = false;
            }
        }


        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                OnOffIP(toggleSwitch.IsOn);
            }
        }

        private void ShowTime_Click(object sender, RoutedEventArgs e)
        {
            if (ShowTime.IsChecked == true)
            {
                TimeTextBlock.Visibility = Visibility.Visible;
                timer.Tick += timer_Tick;
            }
            else
            {
                TimeTextBlock.Visibility = Visibility.Collapsed;
                timer.Tick -= timer_Tick;
            }
        }

        private void ShowIP_Click(object sender, RoutedEventArgs e)
        {
            OnOffIP(ShowIP.IsChecked);
        }
    }
    }
    
    
    
    

