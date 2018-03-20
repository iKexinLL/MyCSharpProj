using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ButtonBackground : Page
    {
        public ButtonBackground()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await new Windows.UI.Popups.MessageDialog("Hello World").ShowAsync();
            TextBlockShow.Text = "Hello World";
            TextBlockShow.FontSize = 40;
        }

        private void MainPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            //Button myBotton = new Button();
            //myBotton.Name = "ClickMeButton";
            //myBotton.Content = "Click Me";
            //myBotton.Width = 200;
            //myBotton.Height = 100;
            //myBotton.Margin = new Thickness(20, 20, 0, 0);
            //myBotton.HorizontalAlignment = HorizontalAlignment.Left;
            //myBotton.VerticalAlignment = VerticalAlignment.Top;
            
            //myBotton.Background = new SolidColorBrush(Colors.Red);
            //myBotton.Click += Button_Click;

            //LayoutGrid.Children.Add(myBotton);
        }

        private void GoBack_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ShowAllPage));
        }
    }
}
