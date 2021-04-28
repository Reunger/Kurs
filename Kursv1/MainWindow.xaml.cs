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
using System.IO;
using Kursv1.Class;

namespace Kursv1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public int numer_;
        _Inf_struct _Inf_data = new _Inf_struct();
        List<Inf_class> Inf_data = new List<Inf_class>();

        public struct StrVar
        {
            public string _strvar { get; set; }
        }
        public struct _Inf_struct
        {

            public string _inf_vopros { get; set; }
            public string _inf_va { get; set; }
            public string _inf_vb { get; set; }
            public string _inf_vc { get; set; }
            public string _inf_vd { get; set; }
        }
        string Path_inf;
        public MainWindow()
        {
            InitializeComponent();

        }
        private void But(object sender, RoutedEventArgs e)
        {
            TaskWindow taskWindow = new TaskWindow();
            taskWindow.Show();
        }
        
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Vopros_List.ItemsSource = null;
                Vopros_List.Items.Clear();
                Inf_data.Clear();
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.DefaultExt = ".txt";
               
                dlg.Filter = "txt files (*.txt)|*.txt";
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    Path_inf = dlg.FileName;
                }
                
                int numer = 0;
                using (StreamReader sr = new StreamReader(Path_inf, System.Text.Encoding.Default))
                {
                    string line, _line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        _line = line;
                        while ((_line.IndexOf(":") > -1))
                        {
                            if (numer == 0)
                            {
                                _Inf_data._inf_vopros = _line.Substring(0, _line.IndexOf(":"));
                                ++numer;
                            }
                            else if (numer == 1)
                            {
                                _Inf_data._inf_va = _line.Substring(0, _line.IndexOf(":"));
                                ++numer;
                            }
                            else if (numer == 2)
                            {
                               
                                _Inf_data._inf_vb = _line.Substring(0, _line.IndexOf(":"));
                                ++numer;

                            }
                            else if (numer == 3 ^numer == 4)
                            {
                                
                                _Inf_data._inf_vc = _line.Substring(0, _line.IndexOf(":"));
                                ++numer;

                                
                                _line = _line.Remove(0, (_line.IndexOf(":")) + 1);
                                _Inf_data._inf_vd = _line.Substring(0, _line.IndexOf(":"));
                                
                                numer = 0;
                                _line = " ";
                            }
                            if (numer != 0)
                                _line = _line.Remove(0, (_line.IndexOf(":")) + 1);
                        }
                        Inf_data.Add(item: new Inf_class() { vopros = _Inf_data._inf_vopros, va=_Inf_data._inf_va, vb = _Inf_data._inf_vb, vc = _Inf_data._inf_vc, vd = _Inf_data._inf_vd }) ;
                        ++numer_;
                    }
                    Vopros_List.ItemsSource = Inf_data;
                    
                }
            }
            catch {
                if (Vopros_List.ItemsSource == null) MessageBox.Show("Укажите текстовый файл");
                else MessageBox.Show("Введите корректно числа");
            }
        }

       
    }
}
