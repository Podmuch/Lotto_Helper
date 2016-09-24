using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace Lotto_Helper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[] results;
        private List<Record> allRecords;
        public ObservableCollection<NumberAndProcentage> ListOfNumsWithProc { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            results = new int[6];
            allRecords = new List<Record>();
            ListOfNumsWithProc = new ObservableCollection<NumberAndProcentage>();
            for(int i = 0; i < 49; i++)
            {
                ListOfNumsWithProc.Add(new NumberAndProcentage(i, 0));
            }
            string archivePath = Environment.CurrentDirectory + "\\Lotto_archive.csv";
            string archiveData = File.ReadAllText(archivePath);
            string[] archiveRows = archiveData.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            //omit first line
            for(int i = 1; i < archiveRows.Length;i++)
            {
                string[] archiveColumns = archiveRows[i].Split(';');
                string[] numbers = archiveColumns[2].Split(' ');
                allRecords.Add(new Record(numbers));
            }
            NumberChanged(null, null);
        }

        private void NumberChanged(object sender, TextChangedEventArgs e)
        {
            MultipleResultsBy(0);
            List<Record> recordsCopy = new List<Record>(allRecords);
            if(int.TryParse(number1.Text, out results[0]))
            {
                recordsCopy = recordsCopy.FindAll((r) => r.numbersList.Contains(results[0]));
            }
            if(int.TryParse(number2.Text, out results[1]))
            {
                recordsCopy = recordsCopy.FindAll((r) => r.numbersList.Contains(results[1]));
            }
            if(int.TryParse(number3.Text, out results[2]))
            {
                recordsCopy = recordsCopy.FindAll((r) => r.numbersList.Contains(results[2]));
            }
            if (int.TryParse(number4.Text, out results[3]))
            {
                recordsCopy = recordsCopy.FindAll((r) => r.numbersList.Contains(results[3]));
            }
            if (int.TryParse(number5.Text, out results[4]))
            {
                recordsCopy = recordsCopy.FindAll((r) => r.numbersList.Contains(results[4]));
            }
            if (int.TryParse(number6.Text, out results[5]))
            {
                recordsCopy = recordsCopy.FindAll((r) => r.numbersList.Contains(results[5]));
            }
            for (int i = 0; i < recordsCopy.Count;i++)
            {
                for(int j = 0; j < recordsCopy[i].numbersList.Count; j++)
                {
                    ListOfNumsWithProc[recordsCopy[i].numbersList[j] - 1].Procentage++;
                }
            }
            if (recordsCopy.Count != 0)
            {
                MultipleResultsBy(100.0f / (float)recordsCopy.Count);
            }
            DynamicGrid.ItemsSource = null;
            DynamicGrid.ItemsSource = ListOfNumsWithProc;
            foundedResults.Content = String.Format("Znaleziono {0}/{1} rezultatów", recordsCopy.Count, allRecords.Count);
        }

        private void MultipleResultsBy(float multiplicator)
        {
            for(int i = 0; i < ListOfNumsWithProc.Count;i++)
            {
                ListOfNumsWithProc[i].Procentage *= multiplicator;
            }
        }
    }
}
