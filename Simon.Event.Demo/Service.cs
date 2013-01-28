using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simon.Event.Demo
{
    //********************************//
    //delegate是method的签名，相当于指向method的指针，可以作为参数传递
    //事件是对委托的封装
    //********************************//
    public class Service
    {
        public delegate void OpenEventHandler(bool isOpened);
        public event OpenEventHandler OnOpened;

        public void Open(bool isOpened)
        {
            Console.WriteLine("open the door.");
            OnOpened(isOpened);//触发事件
        }
    }
}
