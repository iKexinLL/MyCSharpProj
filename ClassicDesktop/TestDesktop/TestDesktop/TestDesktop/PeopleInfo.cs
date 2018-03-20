using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using TestDesktop.Annotations;


namespace TestDesktop
{

    // 静态数据绑定
    public class AgeGroup : ObservableCollection<string>
    {
        public AgeGroup() : base()
        {
            Add("0-15");
            Add("16-25");
            Add("26-35");
            Add("36-45");
            Add("46-55");
            Add("56-65");
        }

        //public static List<string> GetData()
        //{
        //    return 
        //}
    }

    public enum Sexuality
    {
        Male,
        Female
    }

    [Serializable]
    public class PeopleInfo : INotifyPropertyChanged
    {
        public static readonly AgeGroup Ag = new AgeGroup();
        private string _name = "测试";
        private string _age = Ag[0];
        private Sexuality _sex = Sexuality.Male;
        private string _password = "";

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            } 
        }

        public string Age
        {
            get => _age;
            set => _age = value;
        }

        public Sexuality Sex
        {
            get => _sex;
            set
            {
                _sex = value;
                OnPropertyChanged(nameof(Sex));
            } 
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                // 如果注释这块,则点击"刷新"按钮,内容不会有变化
                // 如果没有注释这块,点击"刷新按钮",内容会变化,跟Name一样
                // OnPropertyChanged(nameof(Password));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
