using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataViewer_D_v._001.Classes;
using System.Collections.Generic;

namespace TestingProject
{
    [TestClass]
    public class UnitTestSorting
    {
        [TestMethod]
        public void TestSortingFirstStage()
        {
            List<int[]> summirizeMarks = new List<int[]>();
            List<int> duetNumbers = new List<int>();
            //исходные данные
            summirizeMarks.Add(new int[] { 2, 2, 5, 4, 1 });
            //summirizeMarks.Add(new int[] { 4, 4, 2, 3, 4 });
            //summirizeMarks.Add(new int[] { 6, 6, 6, 6, 6 });
            summirizeMarks.Add(new int[] { 1, 5, 1, 1, 2 });
            //summirizeMarks.Add(new int[] { 3, 3, 3, 2, 3 });
            summirizeMarks.Add(new int[] { 5, 1, 4, 5, 5 });

            //duetNumbers = new List<int> { 21, 41, 61, 11, 31, 51 };
            duetNumbers = new List<int> { 21, 11, 51 };
            List<int> expectedDuetList = new List<int> { 11, 21, 51 };//, 41, 51, 61 };

            // получение значения с помощью тестируемого метода
            List<int> actualDuetList = FinalGrading.combSort(ref summirizeMarks, 0, ref duetNumbers);

            // сравнение ожидаемого результата с полученным
            Assert.AreEqual(expectedDuetList, actualDuetList);
        }
    }
}
