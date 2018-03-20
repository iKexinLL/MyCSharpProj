using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAll
{
    // ReSharper disable once InconsistentNaming
    class IEnumeratorAndIEnumerableTwo : IEnumerable
    {
        // 装载字符串的数组
        private readonly string[] _elements;

        private IList<string> s = new List<string>();
        
        // 下标
        private readonly int _ctr;

        public IEnumeratorAndIEnumerableTwo(params string[] initialStrings)
        {
            // 初始化
            _elements = new string[8];

            foreach (var element in initialStrings)
            {
                _elements[_ctr++] = element;
            }
        }

        public IEnumeratorAndIEnumerableTwo(string initialStrings, char[] delimeters)
        {
            _elements = initialStrings.Split(delimeters);
        }

        //实现接口中得方法
        public IEnumerator GetEnumerator()
        {
            return new ForeachTestEnumerator(this);
        }

        private class ForeachTestEnumerator : IEnumerator
        {
            private int _position = -1;
            private IEnumeratorAndIEnumerableTwo t;

            public ForeachTestEnumerator(IEnumeratorAndIEnumerableTwo t)
            {
                this.t = t;
            }

            public bool MoveNext()
            {
                if (_position < t._elements.Length - 1)
                {
                    _position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                _position = -1;
            }

            public object Current => t._elements[_position];
        }

        public static void TestAll()
        {
            // f初始化为8个长度
            IEnumeratorAndIEnumerableTwo f = new IEnumeratorAndIEnumerableTwo("This", "is", "a", "sample", "sentence.");
            foreach (string item in f)
            {
                if (!String.IsNullOrWhiteSpace(item))
                    Console.WriteLine(item);
            }
        }
    }
}