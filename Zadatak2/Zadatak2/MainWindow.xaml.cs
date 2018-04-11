using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Zadatak2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool edited = false;
        public MainWindow()
        {
            InitializeComponent();
            textBox.IsEnabled = false;
            EditXML.IsEnabled = false;
            SaveXML.IsEnabled = false;
        }

        private void LoadXML_Click(object sender, RoutedEventArgs e)
        {
            EditXML.IsEnabled = true;
            SaveXML.IsEnabled = true;

            if (edited == true)
            {
                DialogResult dr1 = System.Windows.Forms.MessageBox.Show("Izmena neće biti sačuvana. Da li ste sigurni da želite da izbrišete sve izmene?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr1 == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Focus();
                }
                else
                {
                    this.Focus();
                }
                string xml = File.ReadAllText("test.xml");
                var parsed = new XmlDocument();
                parsed.LoadXml(xml);
                textBox.Text = xml;
            }
            else
            {
                string xml = File.ReadAllText("test.xml");
                var parsed = new XmlDocument();
                parsed.LoadXml(xml);
                textBox.Text = xml;
            }
        }

        private void EditXML_Click(object sender, RoutedEventArgs e)
        {
            textBox.IsEnabled = true;
            edited = true;
            LoadXML.IsEnabled = false;
        }

        private void SaveXML_Click(object sender, RoutedEventArgs e)
        {
            string ss = textBox.Text;
            File.WriteAllText("test1.xml", ss);
            string xml = File.ReadAllText("test1.xml");
            var parsed = new XmlDocument();


            try
            {
                parsed.LoadXml(xml);
                File.WriteAllText("test.xml", ss);
                LoadXML.IsEnabled = true;
                edited = false;

            }
            catch (XmlException ex)
            {
                DialogResult dr = System.Windows.Forms.MessageBox.Show("Dogodila se greška prilikom editovanja fajla. Da li želite da je ispravite?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {

                    System.Windows.MessageBox.Show("-->" + ex.Message + "", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Focus();
                }
                else
                {
                    DialogResult dr1 = System.Windows.Forms.MessageBox.Show("Izmena neće biti sačuvana. Da li ste sigurni da želite da izađete iz aplikacije?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr1 == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.Close();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("-->" + ex.Message + "", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        this.Focus();
                    }
                }

            }
        }
    }
}