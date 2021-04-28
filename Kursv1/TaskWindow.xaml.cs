using System;
using System.IO;
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
using System.Windows.Shapes;
using Kursv1.Class;
using Kursv1;


namespace Kursv1
{
    /// <summary>
    /// Логика взаимодействия для TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        _Inf_struct _Inf_data = new _Inf_struct();
        List<ClassList> inf_text = new List<ClassList>();
        _Inf_struct _Inf_data1 = new _Inf_struct();
        List<ClassList> inf_text1 = new List<ClassList>();
        string Path_inf;
        public string text;
        int nomer = 0;
        string chislo;
        public int numer_;
        public struct _Inf_struct
        {

            public string inf_text { get; set; }
        }
            public TaskWindow()
        {
            InitializeComponent();
          
        }
        private void Sravnit(object sender, RoutedEventArgs e)
        {
            int i = 0;
            {
                    {
                         i = i + 1;
                        chislo = "pat";
                        TextBlock.Text = chislo;
                    }
             }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Otvet_list.ItemsSource = null;
                Otvet_list.Items.Clear();
                inf_text1.Clear();
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
                            if (numer >= 0)
                            {

                                _Inf_data1.inf_text = _line.Substring(0, _line.IndexOf(":"));
                                ++numer;
                                _line = _line.Remove(0, (_line.IndexOf(":")) + 1);
                                _line = " ";
                            }
                            if (numer != 0)
                                _line = _line.Remove(0, (_line.IndexOf(":")) + 1);

                        }
                        inf_text1.Add(item: new ClassList() { text = _Inf_data1.inf_text });
                        ++numer_;
                    }
                    Otvet_list.ItemsSource = inf_text1;

                }

            }
            catch { };

        }
        private void But_A(object sender, RoutedEventArgs e)
        {
            /*Otveti.ItemsSource = null;
            Otveti.Items.Clear();*/
            
            string str = (string)((Button)e.OriginalSource).Content;
            _Inf_data.inf_text = str;
            inf_text.Add(item: new ClassList() { text = _Inf_data.inf_text });
            Otveti.Items.Add(inf_text.ElementAt(nomer));
            ++nomer;

        }
        private void But_B(object sender, RoutedEventArgs e)
        {
            
            string str = (string)((Button)e.OriginalSource).Content;
            _Inf_data.inf_text = str;
            inf_text.Add(item: new ClassList() { text = _Inf_data.inf_text });
            Otveti.Items.Add(inf_text.ElementAt(nomer));
            ++nomer;
        }
        private void But_C(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            _Inf_data.inf_text = str;
            inf_text.Add(item: new ClassList() { text = _Inf_data.inf_text });
            Otveti.Items.Add(inf_text.ElementAt(nomer));
            ++nomer;
        }
        private void But_D(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            _Inf_data.inf_text = str;
            inf_text.Add(item: new ClassList() { text = _Inf_data.inf_text });
            Otveti.Items.Add(inf_text.ElementAt(nomer));
            ++nomer;
        }
    }
}
