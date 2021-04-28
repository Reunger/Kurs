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
        List<string> inf_text = new List<string>();
        List<string> inf_text1 = new List<string>();
        string Path_inf;
        public string text;
        int nomer = 0;
        string chislo;
        public int numer_;

        public TaskWindow()
        {
            InitializeComponent();

        }
        private void Sravnit(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = "0";
            for (int i = 0, valid = 0; i < Otvet_list.Items.Count; i++)
            {
                if (Otveti.Items.Count > i && Otveti.Items[i].ToString() == Otvet_list.Items[i].ToString())
                    TextBlock.Text = (++valid).ToString();
            }

            //int i = 0;
            //{
            //    {
            //        i = i + 1;
            //        chislo = "pat";
            //        TextBlock.Text = chislo;
            //    }
            //}
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
                    inf_text1.Clear();
                    string line, _line, temp = String.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        _line = line;
                        while ((_line.IndexOf(":") > -1))
                        {
                            if (numer >= 0)
                            {
                                temp = _line.Substring(0, _line.IndexOf(":"));
                                ++numer;
                                _line = _line.Remove(0, (_line.IndexOf(":")) + 1);
                                _line = " ";
                            }
                            if (numer != 0)
                                _line = _line.Remove(0, (_line.IndexOf(":")) + 1);

                        }
                        if (!string.IsNullOrEmpty(temp)) inf_text1.Add(temp);

                        ++numer_;
                    }
                    Otvet_list.ItemsSource = inf_text1;

                }

            }
            catch { };

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;
            inf_text.Add(str);
            Otveti.Items.Add(inf_text.Last());
            ++nomer;
        }
    }
}