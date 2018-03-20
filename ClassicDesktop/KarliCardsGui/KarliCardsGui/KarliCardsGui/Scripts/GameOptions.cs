using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace KarliCardsGui
{
    // 这里GameOptions的权限需要为public,否则会报错
    [Serializable]
    public class GameOptions : INotifyPropertyChanged
    {
        private ObservableCollection<string> _playerNames =
            new ObservableCollection<string>();
        public List<string> SelectedPlayers { get; set; }
        
        private bool _playAgainstComputer = true;
        private int _numberOfPlayers = 2;
        private ComputerSkillLevel _computerSkill = ComputerSkillLevel.Cheats;

        public GameOptions()
        {
            SelectedPlayers = new List<string>();
        }

        public ObservableCollection<string> PlayerNames
        {
            get => _playerNames;
            set
            {
                _playerNames = value;
                OnPropertyChanged("PlayerNames");
            } 
        }

        public void AddPlayer(string playerName)
        {
            if (_playerNames.Contains(playerName))
                return;
            _playerNames.Add(playerName);
            OnPropertyChanged("PlayerNames");
        }

        public bool PlayAgainstComputer
        {
            get => _playAgainstComputer;
            set
            {
                _playAgainstComputer = value;
                OnPropertyChanged(nameof(PlayAgainstComputer));
            }
        }

        public int NumberOfPlayersThisOne
        {
            get => _numberOfPlayers;
            set
            {
                _numberOfPlayers = value;
                OnPropertyChanged(nameof(NumberOfPlayers));
            }
        }

        public ComputerSkillLevel ComputerSkill
        {
            get => _computerSkill;
            set
            {
                _computerSkill = value;
                OnPropertyChanged(nameof(ComputerSkill));
            }
        }

        public int MinutesBeforeLoss { get; set; }

        // 它实现了INotifyPropertyChanged接口，也就是说，当属性值发生变化时，这个类就会通知WPF。
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum ComputerSkillLevel
    {
        Dumb,
        Good,
        Cheats
    }
}