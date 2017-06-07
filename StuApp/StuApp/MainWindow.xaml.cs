using StuApp.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
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

namespace StuApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Student> Students;
        ObservableCollection<Student> RandomStudents;
        public MainWindow()
        {
            InitializeComponent();
            Students = new ObservableCollection<Student>();
            RandomStudents = new ObservableCollection<Student>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Task.Run(() =>
            //{
            //    LoadData();
            //});
            //this.Dispatcher.BeginInvoke((Action)(() =>
            //{
            //    allstudent.ItemsSource = Students;

            //}));
            LoadData();
            allstudent.ItemsSource = Students;
            random.ItemsSource = RandomStudents;
        }
        void LoadData()
        {
            try
            {
                string sql = "SELECT * FROM student";
                {
                    string currentpath = Environment.CurrentDirectory+"\\student.db";
                    using (SQLiteConnection conn = new SQLiteConnection($"Data Source={currentpath}"))
                    {
                        using (SQLiteDataAdapter ap = new SQLiteDataAdapter(sql, conn))
                        {
                            DataSet ds = new DataSet();
                            ap.Fill(ds);
                            DataTable da = ds.Tables[0];
                            for (int i = 0; i < da.Rows.Count; i++)
                            {
                                var row = da.Rows[i].ItemArray;
                                var st = new Student()
                                {
                                    Number = Convert.ToInt32(row[0].ToString()),
                                    Name = row[1].ToString(),
                                    ClassNum = row[2].ToString(),
                                    Subject = row[3].ToString(),
                                    Sex = row[4].ToString()
                                };
                                Students.Add(st);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("读取数据库发生错误\n" + e.Message);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            RandomStudents.Clear();
            if (Students.Count > 0)
            {
                List<int> rannum = GeneRan((int)slider.Maximum, (int)slider.Value);
                for (int i = 0; i < rannum.Count; i++)
                {

                    RandomStudents.Add(Students[rannum[i]]);
                }

            }
        }
        List<int> GeneRan(int max, int sum)
        {
            List<int> r = new List<int>();
            for (int i = 0; i < sum; i++)
            {
                Random ran = new Random();
                int x = ran.Next(max);
                while (r.Contains(x))
                {
                    x = ran.Next(max);
                }
                r.Add(x);
            }
            return r;
        }
    }
}
