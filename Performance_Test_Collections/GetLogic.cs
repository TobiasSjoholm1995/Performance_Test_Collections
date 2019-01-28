using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using static Performance_Test_Collections.Constants;

namespace Performance_Test_Collections {

    [CsvMeasurementsExporter]
    [RPlotExporter]
    public class GetLogic {
        private Dictionary<int, DataObject> _dictionary;
        private SortedDictionary<int, DataObject> _sortedDirectory;
        private SortedList<int, DataObject> _sortedList;
        private ConcurrentDictionary<int, DataObject> _concurrentDictionary;

        //This needs to create the data, so we hace something to get
        public GetLogic() {
            _dictionary = new Dictionary<int, DataObject>();
            _sortedDirectory = new SortedDictionary<int, DataObject>();
            _sortedList = new SortedList<int, DataObject>();
            _concurrentDictionary = new ConcurrentDictionary<int, DataObject>();

            createData();
        }

        private void createData() {
            for (int i = 0; i < Constants.AMOUNT_OF_ELEMENTS; i++) {
                _dictionary.Add(i, new DataObject() { Value = i });
                _sortedDirectory.Add(i, new DataObject() { Value = i });
                _sortedList.Add(i, new DataObject() { Value = i });
                if (!_concurrentDictionary.TryAdd(i, new DataObject() { Value = i }))
                    Console.WriteLine("Failed to create ConcurrentDictionary in GetLogic");
            }
        }

        [Benchmark]
        public void Dictionary() => getDictionary(AMOUNT_OF_ELEMENTS);

        [Benchmark]
        public void SortedDictionary() => getSortedDictionary(AMOUNT_OF_ELEMENTS);

        [Benchmark]
        public void SortedList() => getSortedList(AMOUNT_OF_ELEMENTS);

        [Benchmark]
        public void ConcurrentDictionary() => getConcurrentDictionary(AMOUNT_OF_ELEMENTS);

        #region Test Logic

        private void getDictionary(int amount) {
            for (int i = 0; i < amount; i++) {
                if (_dictionary[i].Value != i)
                    Console.WriteLine("This should never occur, Directory");
            }
        }

        private void getSortedDictionary(int amount) {
            for (int i = 0; i < amount; i++) {
                if (_sortedDirectory[i].Value != i)
                    Console.WriteLine("This should never occur, SortedDirectory");
            }
        }

        private void getSortedList(int amount) {
            for (int i = 0; i < amount; i++) {
                if (_sortedList[i].Value != i)
                    Console.WriteLine("This should never occur, SortedList");
            }
        }

        private void getConcurrentDictionary(int amount) {
            for (int i = 0; i < amount; i++) {
                DataObject data;
                if (!(_concurrentDictionary.TryGetValue(i, out data) && data.Value == i))
                    Console.WriteLine("This should never occur, ConcurrentDictionary");
            }
        }

        #endregion

    }
}
