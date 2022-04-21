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

        public MainWindow()
        {
            InitializeComponent();
            switched();
        }
        private void IsEnable(object sender, RoutedEventArgs e)
        {
            switched();
        }

        private void switched()
        {
            if (dec != null && hex != null && bin != null)
                switch (from.SelectedIndex)
                {
                    case 0:
                        dec.IsEnabled = true;
                        hex.IsEnabled = false;
                        bin.IsEnabled = false;
                        break;

                    case 1:
                        dec.IsEnabled = false;
                        hex.IsEnabled = true;
                        bin.IsEnabled = false;
                        break;

                    case 2:
                        dec.IsEnabled = false;
                        hex.IsEnabled = false;
                        bin.IsEnabled = true;
                        break;
                }
        }

        private void Exchange(object sender, RoutedEventArgs e)
        {
            int f = from.SelectedIndex;
            int t = to.SelectedIndex;
            if (f == t)
            {
                MessageBox.Show("Hai hệ cơ số phải khác nhau.");
                bin.Text = hex.Text = dec.Text = "";
            }
            else if (f == 0 && t == 1)
            {
                int tmp;
                while (true)
                {
                    try
                    {
                        tmp = Int32.Parse(dec.Text);
                        hex.Text = tmp.ToString("X");
                        break;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Số hệ 10 phải là số thực.");
                        break;
                    }
                    
                }
                
            }
            else if (f == 0 && t == 2)
            {
                int tmp;
                while (true)
                {
                    try
                    {
                        tmp = Int32.Parse(dec.Text);
                        bin.Text = Convert.ToString(tmp, 2);
                        break;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sai dữ liệu.");
                        break;
                    }
                }
            }
            else if (f == 1 && t == 0)
            {
                while (true)
                {
                    try
                    {
                        dec.Text = int.Parse(hex.Text, System.Globalization.NumberStyles.HexNumber).ToString();
                        break;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sai dữ liệu.");
                        break;
                    }
                }
            }
            else if (f == 1 && t == 2)
            {
                while (true)
                {
                    try
                    {
                        bin.Text = Convert.ToString(Convert.ToInt32(hex.Text, 16), 2);
                        break;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sai dữ liệu.");
                        break;
                    }
                }
            }
            else if (f == 2 && t == 0)
            {
                while (true)
                {
                    try
                    {
                        dec.Text = Convert.ToInt32(bin.Text, 2).ToString();
                        break;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sai dữ liệu.");
                        break;
                    }
                }
            }
            else
            {
                while (true)
                {
                    int tmp;
                    try
                    {
                        tmp = Convert.ToUInt16(bin.Text, 2);
                        hex.Text = tmp.ToString("X");
                        break;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sai dữ liệu.");
                        break;
                    }
                }
            }
        }

        private void ClearAll(object sender, RoutedEventArgs e)
        {
            bin.Text = hex.Text = dec.Text = "";
        }

        private void Swap(object sender, RoutedEventArgs e)
        {
            if(dec.Text != null && hex.Text != null && bin.Text != null)
            {
                bin.Text = hex.Text = dec.Text = "";
            }
            
            int tmp1 = from.SelectedIndex;
            from.SelectedIndex = to.SelectedIndex;
            to.SelectedIndex = tmp1;
        }
    }
}
