using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Drawing;

namespace Wpf_Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btn2.Click += btn1_Click;
            btn3.Click += btn1_Click;
            btn4.Click += btn1_Click;
            btn5.Click += btn1_Click;
            btn6.Click += btn1_Click;

            btn2.MouseRightButtonDown += btn1_MouseRightButtonDown;
            btn3.MouseRightButtonDown += btn1_MouseRightButtonDown;
            btn4.MouseRightButtonDown += btn1_MouseRightButtonDown;
            btn5.MouseRightButtonDown += btn1_MouseRightButtonDown;
            btn6.MouseRightButtonDown += btn1_MouseRightButtonDown;
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            var btn = sender as Button;
            Color randomColor = Color.FromArgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));

            SolidColorBrush brush = new SolidColorBrush(randomColor);
            btn.Background = brush;

            MessageBox.Show($"I am Button {btn.Content}");
        }

        private void btn1_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var buttonToDelete = sender as Button;
            string buttonName = buttonToDelete.Name;
            foreach (var stackPanel in ColorButtons.Children)
            {
                var childStackPanel = stackPanel as StackPanel;
                foreach (var item in childStackPanel.Children)
                {
                    if (item is Button btn)
                    {
                        if (btn.Name == buttonName)
                        {
                            this.Title = $"{btn.Name} deleted";
                            childStackPanel.Children.Remove(btn);
                            break;
                        }
                    }
                }
            }
        }
    }
}
