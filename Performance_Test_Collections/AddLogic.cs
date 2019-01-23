using BenchmarkDotNet.Attributes;
using System.Collections.Concurrent;
using System.Collections.Generic;
using static Performance_Test_Collections.Constants;

namespace Performance_Test_Collections {

    [CsvMeasurementsExporter]
    [RPlotExporter]
    public class AddLogic {

        [Benchmark]
        public Dictionary<int, DataObject> AddDictionary() => addDictionary(AMOUNT_OF_ELEMENTS);

        [Benchmark]
        public SortedDictionary<int, DataObject> AddSortedDictionary() => addSortedDirectory(AMOUNT_OF_ELEMENTS);

        [Benchmark]
        public SortedList<int, DataObject> AddSortedList() => addSortedList(AMOUNT_OF_ELEMENTS);

        [Benchmark]
        public ConcurrentDictionary<int, DataObject> AddConcurrentDictionary() => addConcurrentDictionary(AMOUNT_OF_ELEMENTS);


        #region Test Logic

        private Dictionary<int, DataObject> addDictionary(int amount) {
            Dictionary<int, DataObject> dictionary = new Dictionary<int, DataObject>();

            for (int i = 0; i < amount; i++)
                dictionary.Add(i, new DataObject() { Value = i });

            return dictionary;
        }

        private SortedDictionary<int, DataObject> addSortedDirectory(int amount) {
            SortedDictionary<int, DataObject> sortedDirectory = new SortedDictionary<int, DataObject>();

            for (int i = 0; i < amount; i++)
                sortedDirectory.Add(i, new DataObject() { Value = i });

            return sortedDirectory;
        }

        private SortedList<int, DataObject> addSortedList(int amount) {
            SortedList<int, DataObject> sortedList = new SortedList<int, DataObject>();

            for (int i = 0; i < amount; i++)
                sortedList.Add(i, new DataObject() { Value = i });

            return sortedList;
        }


        private ConcurrentDictionary<int, DataObject> addConcurrentDictionary(int amount) {
            ConcurrentDictionary<int, DataObject> concurrentDictionary = new ConcurrentDictionary<int, DataObject>();

            for (int i = 0; i < amount; i++)
                if(!concurrentDictionary.TryAdd(i, new DataObject() { Value = i }))
                    System.Console.WriteLine("Failed to add concurrentDictionary, index = " + i.ToString());

            return concurrentDictionary;
        }

        #endregion

    }
}
