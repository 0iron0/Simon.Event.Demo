using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simon.Event.Demo
{
    //*********************************//
    //System.EventHandler是.net预定义的一个特殊委托
    //System.EventArgs是创建.net控件事件的参数类型，可以继承它封装自定义事件参数
    //*********************************//
    public class EventHandlerDemo
    {
        public string Name { get; set; }

        public event EventHandler OnOpen;

        public void Open(bool isOpened)
        {
            OnOpen(this, new EventHandlerArgs { IsOpened = isOpened });
        }
    }

    public class EventHandlerArgs : EventArgs
    {
        public bool IsOpened { get; set; } 
    }
}
