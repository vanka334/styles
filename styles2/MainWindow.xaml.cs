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
using FuncLib_ser_deser_;

namespace styles2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Theme = "BLM";

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.Theme = "WPB";

        }
    }
    public partial class App : Application
    {
        private static string theme;
        public static string Theme
        {
            get { return theme; }
            set {
                if (value != null)
                {
                    theme = value;
                    var dict = new ResourceDictionary { Source = new Uri($"pack://application:,,,/WpfCustomControlLibrary1;component/Themes/{value}.xaml", UriKind.Absolute) };

                    Current.Resources.MergedDictionaries.RemoveAt(0);
                    Current.Resources.MergedDictionaries.Insert(0, dict);
                    SerDeser.serialize(Theme);
                }

            }

        }
        public App() { 
            InitializeComponent();
            Theme = SerDeser.Deserialize<string>();
        }

    }
}
