using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewer_D_v._001
{
    public class sortController
    {
        static void Swap(Duet x, Duet y)
        {
            var t = x;
            x = y;
            y = t;
        }

        //метод возвращающий индекс опорного элемента
        static int Partition(List<Duet> array, int minIndex, int maxIndex)
        {
            var privot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i].mark < array[maxIndex].mark)
                {
                    privot++;
                    Swap(array[privot], array[i]);
                }
            }
            privot++;
            Swap(array[privot], array[maxIndex]);
            return privot;
        }

        //быстрая сортировка
        static List<Duet> QuickSort(List<Duet> array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        public static List<Duet> QuickSort(List<Duet> array)
        {
            return QuickSort(array, 0, array.Count - 1);
        }

        ///////////////////////////////////
        public int Compare(Duet o1, Duet o2)
        {
            if (o1.mark > o2.mark)
            {
                return 1;
            }
            else if (o1.mark < o2.mark)
            {
                return -1;
            }

            return 0;
        }
    }
}