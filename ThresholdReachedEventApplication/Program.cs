using System;

namespace ThresholdReachedEventNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new(new Random().Next(10));
            counter.ThresholdReached += c_ThresholdReached;  // The event subscribes to the method c_ThresholdReached.

            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                counter.Add(1);
            }
        }

        // User method which handles the action when the event is reached.
        static void c_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            // sender is the object of type Counter and e the event.
            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
            Environment.Exit(0);
        }
    }

    class Counter
    {
        private int threshold;
        private int total;
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;   // The event.

        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;
        }

        public void Add(int x)
        {
            total += x;
            if (total >= threshold)   // If so, the event is prepared to be raised.
            {
                ThresholdReachedEventArgs args = new()
                {
                    Threshold = threshold,
                    TimeReached = DateTime.Now
                };
                OnThresholdReached(args);
            }
        }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;   // Handler pointing to the event in this class.
            if (handler != null)    // If null, the event is not pointing to any user method yet.
            {
                handler(this, e);   // Event raised sending an instance of this class, plus the event that just happenned.
                // The user method is executed.
            }
        }
    }

    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
}