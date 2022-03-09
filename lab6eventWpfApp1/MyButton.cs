using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace lab6eventWpfApp1
{
    public class MyButton : Button
    {
        public static RoutedEvent MyButtonClickEvent;

        static MyButton()
        {
            MyButtonClickEvent = EventManager.RegisterRoutedEvent("MyButtonClick",
                RoutingStrategy.Tunnel, //Bubble, Direct
                typeof(RoutedEventHandler),
                typeof(MyButton));
        }
        public event RoutedEventHandler MyButtonClick
        {
            add { AddHandler(MyButtonClickEvent, value); }
            remove { RemoveHandler(MyButtonClickEvent, value); }
        }
        protected override void OnClick()
        {
            base.OnClick();
            //Аргумент, кот будет передан обработчику события
            RoutedEventArgs args = new RoutedEventArgs(MyButton.MyButtonClickEvent, this);
            //Вызов событияю Событие, котодолжно быть вызвано, определяется по параметрам объекта типа RoutedEventsArgs
            RaiseEvent(args);
        }
    }
}
