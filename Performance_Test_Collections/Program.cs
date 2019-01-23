using BenchmarkDotNet.Running;
using System;
using System.Diagnostics;
using static Performance_Test_Collections.Constants;

namespace Performance_Test_Collections {
    public class Program {

        /// <summary>
        /// Test of all associative collection classes in C#
        /// The result can be viewed in /bin/Release/BenchmarkDotNet.Artifacts
        /// </summary>
        public static void Main(string[] args) {
            Console.WriteLine("Amount of elements: " + AMOUNT_OF_ELEMENTS);
            
            using (Process p = Process.GetCurrentProcess())
                p.PriorityClass = ProcessPriorityClass.High;

            BenchmarkRunner.Run<CreateLogic>();
            BenchmarkRunner.Run<AddLogic>();
            BenchmarkRunner.Run<ReadLogic>();

            Console.ReadKey();
        }
    }
}
