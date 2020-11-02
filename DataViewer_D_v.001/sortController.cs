using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewer_D_v._001
{
    public class sortController
    {
        static void Swap(DuetInTour x, DuetInTour y)
        {
            var t = x;
            x = y;
            y = t;
        }

        //метод возвращающий индекс опорного элемента
        static int Partition(List<DuetInTour> array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i].mark < array[maxIndex].mark)
                {
                    pivot++;
                    Swap(array[pivot], array[i]);
                }
            }

            pivot++;
            Swap( array[pivot], array[maxIndex]);
            return pivot;
        }

        //быстрая сортировка
        static List<DuetInTour> QuickSort(List<DuetInTour> array, int minIndex, int maxIndex)
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

        public static List<DuetInTour> QuickSort(List<DuetInTour> array)
        {
            return QuickSort(array, 0, array.Count - 1);
        }


        ///////////////////////////////////

        public int Compare(DuetInTour o1, DuetInTour o2)
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
