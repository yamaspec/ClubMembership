using System;
using System.Threading;

namespace AsyncFinancialTradingPlatformApplication
{
    public class StockMarketTechnicalAnalysisData
    {
        public StockMarketTechnicalAnalysisData(string stockSymbol, DateTime dateTimeStart, DateTime dateTimeEnd)
        {
            // Code here gets the stock market data from remote server.
        }

        public decimal[] GetOpeningPrices()
        {
            decimal[] data = new decimal[] { };
            Console.WriteLine($"Method name: {nameof(GetOpeningPrices)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep( 1000 ); // Represent the time it takes for the operation to complete.
            return data;  // Data variable would contain real decimal data.
        }

        public decimal[] GetClosingPrices()
        {
            decimal[] data = new decimal[] { };
            Console.WriteLine($"Method name: {nameof(GetClosingPrices)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000); // Represent the time it takes for the operation to complete.
            return data;  // Data variable would contain real decimal data.
        }

        public decimal[] GetPriceHighs()
        {
            decimal[] data = new decimal[] { };
            Console.WriteLine($"Method name: {nameof(GetPriceHighs)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000); // Represent the time it takes for the operation to complete.
            return data;  // Data variable would contain real decimal data.
        }

        public decimal[] GetPriceLows()
        {
            decimal[] data = new decimal[] { };
            Console.WriteLine($"Method name: {nameof(GetPriceLows)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000); // Represent the time it takes for the operation to complete.
            return data;  // Data variable would contain real decimal data.
        }

        // Overboard or over sold => buy/sell.
        public decimal[] CalculateStockastics()
        {
            decimal[] data = new decimal[] { };
            Console.WriteLine($"Method name: {nameof(CalculateStockastics)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(10000); // Represent the time it takes for the operation to complete.
            return data;  // Data variable would contain real decimal data.
        }

        public decimal[] CalculateFastMovingAverage()
        {
            decimal[] data = new decimal[] { };
            Console.WriteLine($"Method name: {nameof(CalculateFastMovingAverage)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(6000); // Represent the time it takes for the operation to complete.
            return data;  // Data variable would contain real decimal data.
        }

        public decimal[] CalculateSlowMovingAverage()
        {
            decimal[] data = new decimal[] { };
            Console.WriteLine($"Method name: {nameof(CalculateSlowMovingAverage)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(7000); // Represent the time it takes for the operation to complete.
            return data;  // Data variable would contain real decimal data.
        }

        public decimal[] CalculateUpperBoundBollingerBand()
        {
            decimal[] data = new decimal[] { };
            Console.WriteLine($"Method name: {nameof(CalculateUpperBoundBollingerBand)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(5000); // Represent the time it takes for the operation to complete.
            return data;  // Data variable would contain real decimal data.
        }

        public decimal[] CalculateLowerBoundBollingerBand()
        {
            decimal[] data = new decimal[] { };
            Console.WriteLine($"Method name: {nameof(CalculateLowerBoundBollingerBand)}, ThreadId: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(5000); // Represent the time it takes for the operation to complete.
            return data;  // Data variable would contain real decimal data.
        }
    }
}
