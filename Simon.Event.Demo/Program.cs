using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simon.Event.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Case1()
            //Case2();
            Case3();
            Console.ReadKey();
        }

        static void Case1()
        {
            Service s = new Service();
            s.OnOpened += new Service.OpenEventHandler(Opened);//注册事件，在事件中绑定了触发事件时调用的方法

            Console.WriteLine("ready");
            s.Open(true);//调用对象的一个方法
        }

        static void Opened(bool isOpened)
        {
            if(isOpened)
                Console.WriteLine("door is opened.");
        }

        static void Case2()
        {
            EventHandlerDemo ehd = new EventHandlerDemo();
            ehd.Name = "Event Handler Demo";
            ehd.OnOpen += new EventHandler(ehd_OnOpened);
            ehd.Open(true);
        }

        static void ehd_OnOpened(object sender, EventArgs e)
        {
            Console.WriteLine("sender:{0}, value:{1}", 
                (sender as EventHandlerDemo).Name,
                (e as EventHandlerArgs).IsOpened.ToString());
        }

        static void Case3()
        {
            Counter counter = new Counter(new Random().Next(10));
            counter.ThresholdReached += counter_Threshold;
            counter.ThresholdReached += counter_Threshold2;
            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                counter.Add(1);
            }
        }

        static void counter_Threshold(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
            throw new ArgumentException("e");
        }

        static void counter_Threshold2(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
        }
    }
}
