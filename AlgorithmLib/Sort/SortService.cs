using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLib.Sort
{
    public class SortService<T>
    {
        private IList<T> _list;

        private Func<T, T, bool> _comparer;

        public SortService(IList<T> list, Func<T,T, bool> comparer)
        {
            _list = list;
            _comparer = comparer;
        }

        private void CheckError()
        {
            if (_list == null || _comparer == null)
                throw new Exception("SortService(IList<T> list, Func<T,T, bool> comparer), list 不能为空，comparer不能为空！");
        }

        public IList<T> GetOriginalList()
        {
            CheckError();
            return _list.ToList();
        }

        public IList<T> GetSortedListByPopSort()
        {
            CheckError();

            var sortedList = _list.ToList();

            var length = sortedList.Count;

            for (int i = 1; i <= length - 1; i++)
            {
                //归置length - 1个数
                for (int j = 0; j < length - i; j++)
                {
                    if (_comparer(sortedList[j], sortedList[j + 1]))
                    {
                        var t = sortedList[j];
                        sortedList[j] = sortedList[j + 1];        
                        sortedList[j + 1] = t;
                    }
                }
            }
            return sortedList;
        }

        public IList<T> GetSortedListByQuickSort()
        {
            CheckError();

            var sortedList = _list.ToList();

            QuickSort(sortedList, 0 , sortedList.Count - 1);

            return sortedList;
        }

        private void QuickSort(IList<T> list, int left, int right)
        {
            if (left > right)
                return;

            var tempValue = list[left];
            var i = left;
            var j = right;

            while (i != j)
            {
                while (!_comparer(list[j], tempValue) && i < j)
                {
                    j--;
                }
                while (!_comparer( tempValue, list[i]) && i< j)
                {
                    i++;
                }
                if (i < j)
                {
                    var t = list[i];
                    list[i] = list[j];
                    list[j] = t;
                }
            }

            list[left] = list[i];
            list[i] = tempValue;

            QuickSort(list, left, i -1);
            QuickSort(list, i+ 1, right);
        }
    }
}
