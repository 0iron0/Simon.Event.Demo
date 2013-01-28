using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simon.Event.Demo
{
    public class Counter
    {
        private int mThreshold;
        private int total;
        private object mSyncRoot;

        public EventHandler<ThresholdReachedEventArgs> ThresholdReached;
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReachedInvoke
        {
            add
            {
                lock (mSyncRoot)
                {
                    this.ThresholdReached += value;
                }
            }
            remove
            {
                lock (mSyncRoot)
                {
                    this.ThresholdReached -= value;
                }
            }
        }

        public Counter(int threshold)
        {
            this.mThreshold = threshold;
        }

        public void Add(int x)
        {
            total += x;
            if (total > mThreshold)
            {
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs
                {
                    Threshold = mThreshold,
                    TimeReached = DateTime.Now
                };
                OnThresholdReached(args);//invoke event handler
            }
        }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;
            if (handler != null)
            {
                Array.ForEach<Delegate>(handler.GetInvocationList(), (item) =>
                {
                    try
                    {
                        item.DynamicInvoke(this, e);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                });

                //handler(this, e);
            }
        }
    }

    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
}
