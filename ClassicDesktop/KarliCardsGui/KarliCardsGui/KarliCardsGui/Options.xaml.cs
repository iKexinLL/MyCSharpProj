using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace KarliCardsGui
{
    /// <summary>
    /// Options.xaml 的交互逻辑
    /// </summary>
    public partial class Options : Window
    {
        private GameOptions _gameOptions;
        public Options()
        {
            if (_gameOptions == null)
            {
                if (File.Exists("GameOptions.xml"))
                {
                    using (var stream = File.OpenRead("GameOptions.xml"))
                    {
                        if (stream.Length != 0)
                        {
                            // 这里GameOptions的权限需要为public,否则会报错
                            var serializer = new XmlSerializer(typeof(GameOptions));
                            _gameOptions = serializer.Deserialize(stream) as GameOptions;
                        }
                        else
                            _gameOptions = new GameOptions();
                    }
                }
                else
                    _gameOptions = new GameOptions();
            }

            DataContext = _gameOptions;
            
            InitializeComponent();
            //NumberOfPlayersComboBox.IsEnabled = false;
        }

        private void DumbAiRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            _gameOptions.ComputerSkill = ComputerSkillLevel.Dumb;
        }

        private void GoodAiRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            _gameOptions.ComputerSkill = ComputerSkillLevel.Good;
        }

        private void CheatingAiRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            _gameOptions.ComputerSkill = ComputerSkillLevel.Cheats;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            using (var stream = File.Open("GameOptions.xml", FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(GameOptions));
                serializer.Serialize(stream, _gameOptions);
            }
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameOptions = null;
            Close();
        }
    }
}
