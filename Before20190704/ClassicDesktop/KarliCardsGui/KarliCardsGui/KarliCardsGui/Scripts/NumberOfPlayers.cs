using System;
using System.Collections.ObjectModel;

namespace KarliCardsGui
{
    // 静态数据绑定
    public class NumberOfPlayers : ObservableCollection<int>
    {
        public NumberOfPlayers() : base()
        {
            Add(2);
            Add(3);
            Add(4);
        }
    }
}
