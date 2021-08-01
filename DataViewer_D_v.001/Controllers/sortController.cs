using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewer_D_v._001
{
    public class sortController
    {
        public static int system = 0;
        static void Swap(ref Duet x, ref Duet y)
        {
            var t = x;
            x = y;
            y = t;
        }

        //метод возвращающий индекс опорного элемента
        static int Partition(Duet[] array, int minIndex, int maxIndex)
        {
            var privot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (system == 0)
                {
                    if (array[i].mark > array[maxIndex].mark)
                    {
                        privot++;
                        Swap(ref array[privot], ref array[i]);
                    }
                }
                else
                {
                    if (array[i].markSum > array[maxIndex].markSum)
                    {
                        privot++;
                        Swap(ref array[privot], ref array[i]);
                    }
                }
            }
            privot++;
            Swap(ref array[privot],ref array[maxIndex]);
            return privot;
        }

        //быстрая сортировка
        static List<Duet> QuickSort(Duet[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array.ToList<Duet>();
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array.ToList<Duet>();
        }

        public static List<Duet> QuickSort(Duet[] array, int sys)
        {
            system = sys;
            return QuickSort(array, 0, array.Length - 1);
        }

        ///////////////////////////////////
        public int Compare(Duet o1, Duet o2)
        {
            if (system == 0)
            {
                if (o1.mark > o2.mark)
                {
                    return 1;
                }
                else if (o1.mark < o2.mark)
                {
                    return -1;
                }
            }
            else
            {
                if (o1.markSum > o2.markSum)
                {
                    return 1;
                }
                else if (o1.markSum < o2.markSum)
                {
                    return -1;
                }
            }
            return 0;
        }
    }
}