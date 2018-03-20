using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShowAllPage : Page
    {
        public ShowAllPage()
        {
            this.InitializeComponent();
        }

        private void GoTo_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ButtonBackground));
        }

        private void GoToTextPass_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TextPassPartOne));
        }
    }
}
