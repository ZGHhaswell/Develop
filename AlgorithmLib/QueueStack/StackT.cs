using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLib.QueueStack
{
    public class StackT<T> : IEnumerable<T>
    {
        private IList<T> _list;

        public StackT()
        {
            _list = new List<T>();
        }

        public void Push(T t)
        {
            _list.Add(t);
        }

        public T Pop()
        {
            if (_list.Count != 0)
            {
                var t = _list.Last();
                _list.RemoveAt(_list.Count - 1);
                return t;
            }
            return default (T);
        }

        public T Peek()
        {
            if (_list.Count != 0)
            {
                return _list.Last();
            }
            return default (T);
        }

        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnumerator<T>(_list);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class StackEnumerator<T> : IEnumerator<T>
    {
        private IList<T> _orginalList;

        private int _index = -1;

        public StackEnumerator(IList<T> t)
        {
            _orginalList = t;
        }

        

        public T Current
        {
            get
            {
                try
                {
                    return _orginalList[_index];
                }
                catch (Exception)
                {
                    
                    throw new InvalidOperationException();
                }
            }
        }

        public void Dispose()
        {
            
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            _index++;
            if (_index >= _orginalList.Count)
                return false;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}
