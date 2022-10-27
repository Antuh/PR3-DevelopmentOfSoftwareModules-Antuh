using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace PR.M.Antuh
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1(string login)
        {
            InitializeComponent();
        }
        public static class ArrExtension
        {
            public static DataTable ToDataTable(int[,] array)
            {
                var res = new DataTable();

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    res.Columns.Add("col" + j);
                }

                for (int i = 0; i < array.GetLength(0); i++)
                {
                    var row = res.NewRow();

                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        row[j] = array[i, j];
                    }

                    res.Rows.Add(row);
                }

                return res;
            }
        }

        private void btn_spisok_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection Con = new SqlConnection(@"Data Source=10.111.105.2,1433\SQLEXPRESS;Initial Catalog=20.101-02-Metallurgia; User ID=20.101-02;Password =Antuh01122003"))
            {
                Con.Open();
                string query = " SELECT FROM [Minerals] ";
                SqlCommand command = new SqlCommand(query, Con);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Con.Close();

                if (dt.Rows.Count != 0)
                {
  
                }
                else
                {

                }
            }
        }
    }

}



