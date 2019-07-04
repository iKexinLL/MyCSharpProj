using System.Windows;
using System.Windows.Input;

namespace ClassicDesktop
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonTwo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ButtonTwo_Click");
        }

        private void ButtonTwo_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("ButtonTwo_OnPreviewKeyDown");
            e.Handled = true;
        }

        private void ButtonTwo_OnKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("ButtonTwo_OnKeyDown");
        }

        // 下钻事件
        private void UIElement_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("UIElement_OnPreviewKeyDown");
            //e.Handle = true //可以停止下钻事件
        }

        private void ButtonOne_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ButtonOne_OnMouseDoubleClick");
        }

        private void ButtonOne_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ButtonOne_Click");
        }

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Panel");
        }

        // 冒泡事件
        private void YesTB_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("button");
            //e.Handled = true;
        }
    }
}
