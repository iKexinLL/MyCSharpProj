using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace TestDesktop
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        private PeopleInfo _peopleInfo;
        
        public MainWindow()
        {
            if (_peopleInfo == null)
            {
                if (File.Exists("Info.xml"))
                {
                    using (var stream = File.OpenRead("Info.xml"))
                    {
                        if (stream.Length != 0)
                        {
                            // 这里PeopleInfo的权限需要为public,否则会报错
                            var serializer = new XmlSerializer(typeof(PeopleInfo));
                            _peopleInfo = serializer.Deserialize(stream) as PeopleInfo;
                        }
                        else
                            _peopleInfo = new PeopleInfo();
                    }
                }
                else
                    _peopleInfo = new PeopleInfo();
            }

            DataContext = _peopleInfo;

            InitializeComponent();

            for (int i = 1; i < 200; i++)
            {
                TxtBlockOutpuMessage.Inlines.Add(new Run(i.ToString()));
                // TxtBlockOutpuMessage.Inlines.Add(new LineBreak());
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            using (var stream = File.Open("Info.xml", FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(PeopleInfo));
                serializer.Serialize(stream, _peopleInfo);
            }
            Close();
        }

        private void ButtonCancle_Click(object sender, RoutedEventArgs e)
        {
            _peopleInfo = null;
            Close();
        }

        private void RadioButtonMale_Checked(object sender, RoutedEventArgs e)
        {
            _peopleInfo.Sex = Sexuality.Male;
        }

        private void RadioButtonFemale_Checked(object sender, RoutedEventArgs e)
        {
            _peopleInfo.Sex = Sexuality.Male;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _peopleInfo.Name = "刷新监听";
            _peopleInfo.Age = PeopleInfo.Ag[1];
            _peopleInfo.Password = "刷新未监听";
        }

        private void Button_ClickTest(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button Clicked");
        }
    }
}
