using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace KarliCardsGui
{
    /// <summary>
    /// StartGame.xaml 的交互逻辑
    /// </summary>
    public partial class StartGame : Window
    {
        private GameOptions _gameOptions;

        public StartGame()
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

            if (_gameOptions.PlayAgainstComputer)
                PlayerNameListBox.SelectionMode = SelectionMode.Single;
            else
                PlayerNameListBox.SelectionMode = SelectionMode.Extended;
        }

        private void AddNewPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NewPlayerBox.Text))
                _gameOptions.AddPlayer(NewPlayerBox.Text);
            NewPlayerBox.Text = string.Empty;
        }

        private void PlayerNameListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_gameOptions.PlayAgainstComputer)
                OkButton.IsEnabled = (PlayerNameListBox.SelectedItems.Count == 1);
            else
                OkButton.IsEnabled = (PlayerNameListBox.SelectedItems.Count == _gameOptions.NumberOfPlayersThisOne);

            // OkButton.IsEnabled = true;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (string item in PlayerNameListBox.SelectedItems)
            {
                _gameOptions.SelectedPlayers.Add(item);
            }
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