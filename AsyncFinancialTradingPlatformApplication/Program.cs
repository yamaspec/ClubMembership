using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncFinancialTradingPlatformApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Method name: Main, ThreadId: {Thread.CurrentThread.ManagedThreadId}");
            StockMarketTechnicalAnalysisData stockMarketTechnicalAnalysisData = new("STKZA", new DateTime(2020, 11, 30), new DateTime(2023, 11, 30));

            DateTime dateTimeStartProcess = DateTime.Now;

            List<decimal[]> data = new();
            data.Add(stockMarketTechnicalAnalysisData.GetOpeningPrices());
            data.Add(stockMarketTechnicalAnalysisData.GetClosingPrices());
            data.Add(stockMarketTechnicalAnalysisData.GetPriceHighs());
            data.Add(stockMarketTechnicalAnalysisData.GetPriceLows());
            data.Add(stockMarketTechnicalAnalysisData.CalculateStockastics());
            data.Add(stockMarketTechnicalAnalysisData.CalculateFastMovingAverage());
            data.Add(stockMarketTechnicalAnalysisData.CalculateSlowMovingAverage());
            data.Add(stockMarketTechnicalAnalysisData.CalculateUpperBoundBollingerBand());
            data.Add(stockMarketTechnicalAnalysisData.CalculateLowerBoundBollingerBand());

            DateTime dateTimeEndProcess = DateTime.Now;
            TimeSpan timeSpan = dateTimeEndProcess.Subtract(dateTimeStartProcess);
            // All Thread Ids are = 1 and took 37 seconds.
            Console.WriteLine($"Time for synchronous operations to complete took {timeSpan.Seconds} {(timeSpan.Seconds > 1 ? "seconds" : "second")}.");
            Console.WriteLine();
            Console.WriteLine();

            dateTimeStartProcess = DateTime.Now;
            List<Task<decimal[]>> tasks = new();
            tasks.Add(Task.Run(() => stockMarketTechnicalAnalysisData.GetOpeningPrices()));
            tasks.Add(Task.Run(() => stockMarketTechnicalAnalysisData.GetClosingPrices()));
            tasks.Add(Task.Run(() => stockMarketTechnicalAnalysisData.GetPriceHighs()));
            tasks.Add(Task.Run(() => stockMarketTechnicalAnalysisData.GetPriceLows()));
            tasks.Add(Task.Run(() => stockMarketTechnicalAnalysisData.CalculateStockastics()));
            tasks.Add(Task.Run(() => stockMarketTechnicalAnalysisData.CalculateFastMovingAverage()));
            tasks.Add(Task.Run(() => stockMarketTechnicalAnalysisData.CalculateSlowMovingAverage()));
            tasks.Add(Task.Run(() => stockMarketTechnicalAnalysisData.CalculateUpperBoundBollingerBand()));
            tasks.Add(Task.Run(() => stockMarketTechnicalAnalysisData.CalculateLowerBoundBollingerBand()));

            Task.WaitAll(tasks.ToArray());
            data = new();
            data.Add(tasks[0].Result);
            data.Add(tasks[1].Result);
            data.Add(tasks[2].Result);
            data.Add(tasks[3].Result);
            dateTimeEndProcess = DateTime.Now;
            timeSpan = dateTimeEndProcess.Subtract(dateTimeStartProcess);
            // All Thread Ids are different among them and took 10 second.
            Console.WriteLine($"Time for Asynchronous operations to complete took {timeSpan.Seconds} {(timeSpan.Seconds > 1 ? "seconds" : "second")}.");
            Console.WriteLine();

            DisplayDataOnChart( data );
            Console.ReadKey();

        }

        public static void DisplayDataOnChart(List<decimal[]> data)
        {
            Console.WriteLine("Several charts displayed on the screen");
        }
    }
}
