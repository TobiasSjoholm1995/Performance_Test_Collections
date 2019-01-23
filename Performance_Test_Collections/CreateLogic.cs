using BenchmarkDotNet.Attributes;
using System.Collections.Concurrent;
using System.Collections.Generic;
using static Performance_Test_Collections.Constants;

namespace Performance_Test_Collections {

    [CsvMeasurementsExporter]
    [RPlotExporter]
    public class CreateLogic {

        [Benchmark]
        public Dictionary<int, DataObject> CreateDictionary() => createDictionary(AMOUNT_OF_ELEMENTS);

        [Benchmark]
        public SortedDictionary<int, DataObject> CreateSortedDictionary() => createSortedDirectory(AMOUNT_OF_ELEMENTS);

        [Benchmark]
        public SortedList<int, DataObject> CreateSortedList() => createSortedList(AMOUNT_OF_ELEMENTS);

        [Benchmark]
        public ConcurrentDictionary<int, DataObject> CreateConcurrentDictionary() => createConcurrentDictionary(AMOUNT_OF_ELEMENTS);

        #region Test Logic

        private Dictionary<int, DataObject> createDictionary(int amount) {
            Dictionary<int, DataObject> dictionary = new Dictionary<int, DataObject>();
            return dictionary;
        }

        private SortedDictionary<int, DataObject> createSortedDirectory(int amount) {
            SortedDictionary<int, DataObject> sortedDirectory = new SortedDictionary<int, DataObject>();
            return sortedDirectory;
        }

        private SortedList<int, DataObject> createSortedList(int amount) {
            SortedList<int, DataObject> sortedList = new SortedList<int, DataObject>();
            return sortedList;
        }

        private ConcurrentDictionary<int, DataObject> createConcurrentDictionary(int amount) {
            ConcurrentDictionary<int, DataObject> sortedList = new ConcurrentDictionary<int, DataObject>();
            return sortedList;
        }

        #endregion
    }
}
