using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace sysProg_hw2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Numbers numbers;
        Thread thread1;
        Thread thread2;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            numbers.a = int.Parse(tbFrom.Text);
            numbers.b = int.Parse(tbTo.Text);
            ParameterizedThreadStart threadstart = new ParameterizedThreadStart(FromTo);
            thread1 = new Thread(threadstart);
            thread1.Start((object)numbers);
        }

      
        private void FromTo(object n)
        {
            Numbers a = (Numbers)n;
           
            if (a.a == null)
            {
                a.a = 2;
            }
            if (a.b == null)
            {
                a.b = 1000_000_00;
            }
            else
            {
               
            }

            for (int i = (int)a.a; i <= a.b; i++)
            {
                Thread.Sleep(1000);
                this.Dispatcher.Invoke((Action)(() =>
                {
                    Numb.Content = i;
                }));

            }
        }
        private void FibonacciFill(object x)
        {
            int number = (int)x;
            int num1 = 0;
            int num2 = 1;

            for (int i = 0; i < number; i++)
            {
                int temp = num1;
                num1 = num2;
                num2 = temp + num2;
                Thread.Sleep(1000);
                this.Dispatcher.Invoke((Action)(() =>
                {
                    lbFibNumber.Content = num1;
                }));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(tbFibNumb.Text);
            ParameterizedThreadStart threadstart = new ParameterizedThreadStart(FibonacciFill);
            thread2 = new Thread(threadstart);
            thread2.Start((object)n);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            thread1.Abort();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            thread2.Abort();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            thread2.Resume();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            thread1.Suspend();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            thread1.Resume();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            thread2.Suspend();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            thread1.Abort();
            numbers.a = int.Parse(tbFrom.Text);
            numbers.b = int.Parse(tbTo.Text);
            ParameterizedThreadStart threadstart = new ParameterizedThreadStart(FromTo);
            thread1 = new Thread(threadstart);
            thread1.Start((object)numbers);
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            thread2.Abort();
            int n = int.Parse(tbFibNumb.Text);
            ParameterizedThreadStart threadstart = new ParameterizedThreadStart(FibonacciFill);
            thread2 = new Thread(threadstart);
            thread2.Start((object)n);
        }
    }

    public struct Numbers
    {
        public int? a;
        public int? b;
    }
}
