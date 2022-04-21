using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace ChuyenDoiCoSo_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private bool _dec = false;
        public bool Dec { get { return _dec; } set { _dec = value; OnPropertyChanged(); } }

        private bool _bin = false;
        public bool Bin { get { return _bin; } set { _bin = value; OnPropertyChanged(); } }

        private bool _hex = false;
        public bool Hex { get { return _hex; } set { _hex = value; OnPropertyChanged(); } }

        public MainWindow()
        {
            InitializeComponent();
        }
        private void IsEnable(object sender, RoutedEventArgs e)
        {
            switched();
        }

        private void switched()
        {
            switch (from.Text)
            {
                case "Thập phân":
                    dec.IsEnabled = true;
                    hex.IsEnabled = false;
                    bin.IsEnabled = false;
                    break;

                case "Thập lục phân":
                    dec.IsEnabled = false;
                    hex.IsEnabled = true;
                    bin.IsEnabled = false;
                    break;

                case "Nhị phân":
                    dec.IsEnabled = false;
                    hex.IsEnabled = false;
                    bin.IsEnabled = true;
                    break;
            }
        }

    }
}
