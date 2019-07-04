using System;
using System.Collections;
using System.Collections.Generic;


namespace TestAll
{
    // ReSharper disable once InconsistentNaming
    class IEnumeratorAndIEnumerableTwoT : IEnumerable<string>
    {
        private readonly string[] _strings;
        private int _crt = 0;

        public IEnumeratorAndIEnumerableTwoT(params string[] initalStrings)
        {
            _strings = new string[8];

            foreach (var s in initalStrings)
            {
                _strings[_crt++] = s;
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (var s in _strings)
            {
                yield return s;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(string newString)
        {
            _strings[_crt] = newString;
            _crt++;
        }

        // 允许数组式的访问 
        public string this[int index]
        {
            get
            {
                if (index < 0 || index > _strings.Length)
                {
                    // 处理不良索引
                }
                return _strings[index];
            }
            set
            {
                _strings[index] = value;
            }
        }

        // 发布拥有的字符串数  
        public int GetNumEntries()
        {
            return _crt;
        }

        public static void TestAll()
        {
            IEnumeratorAndIEnumerableTwoT ieet 
                    = new IEnumeratorAndIEnumerableTwoT("Hello", "World");

            ieet.Add("Xu");

            foreach (var s in ieet)
            {
                if (!string.IsNullOrWhiteSpace(s))
                    Console.WriteLine(s);
            }
        }
    }
}
