using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLib.QueueStack
{
    public class QueueT<T>
    {
        private IList<T> _list;
        
        public QueueT()
        {
            _list = new List<T>();
        }

        public void EnQueue(T t)
        {
            _list.Add(t);
        }

        public T DeQueue()
        {
            if (_list.Count != 0)
            {
                var t = _list[0];     
                _list.RemoveAt(0);
                return t;
            }
            return default (T);
        }

        public T Peek()
        {
            if (_list.Count > 0)
            {
                var t = _list[0];
                _list.RemoveAt(0);
                return t;
            }
            return default(T);
        }

        public int Count
        {
            get
            {
                return _list.Count;
            }
        }
    }
}
