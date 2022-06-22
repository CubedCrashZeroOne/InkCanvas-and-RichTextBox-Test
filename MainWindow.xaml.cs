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

namespace VP3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int current = 1;
        private List<Page> pages = new List<Page>();

        public MainWindow()
        {
            InitializeComponent();
            pages.Add(new TextPage());
            docFrame.Content = pages[0];
            CheckEnable();
        }

        private void CheckEnable()
        {
            if(current == 1)
            {
                backButton.IsEnabled = false;
            }
            else
            {
                backButton.IsEnabled = true;
            }

            if (current == pages.Count)
            {
                forwardButton.IsEnabled = false;
            }
            else
            {
                forwardButton.IsEnabled = true;
            }
            if( pages.Count == 1)
            {
                removeButton.IsEnabled = false;
            }
            else
            {
                removeButton.IsEnabled = true;
            }
            counter.Text = $"{current}/{pages.Count}";
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if(current == 1)
            {
                docFrame.Content = pages[1];
                pages.RemoveAt(0);
            }
            else
            {
                docFrame.Content = pages[current-2];
                pages.RemoveAt(current - 1);
                current--;
            }
            CheckEnable();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            docFrame.Content = pages[current - 2];
            current--;
            CheckEnable();
        }

        private void forwardButton_Click(object sender, RoutedEventArgs e)
        {
            docFrame.Content = pages[current];
            current++;
            CheckEnable();
        }

        private void createDrawButton_Click(object sender, RoutedEventArgs e)
        {
            pages.Add(new DrawPage());
            docFrame.Content = pages[pages.Count - 1];
            current = pages.Count;
            CheckEnable();
        }

        private void createTextButton_Click(object sender, RoutedEventArgs e)
        {
            pages.Add(new TextPage());
            docFrame.Content = pages[pages.Count - 1];
            current = pages.Count;
            CheckEnable();
        }
    }
}
