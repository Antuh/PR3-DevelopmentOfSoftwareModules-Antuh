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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR.M.Antuh
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_authorization_Click(object sender, RoutedEventArgs e)
        {
            string login = tb_login.Text;
            string password = tb_password.Password;

            using (SqlConnection con = new SqlConnection(@"Data Source=10.111.105.2,1433\SQLEXPRESS;Initial Catalog=20.101-02-Metallurgia; User ID=20.101-02;Password =Antuh01122003"))
            {
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dt = new DataTable();

                string query = $"SELECT Login, Password FROM Authorizations WHERE Login = '{login}' AND Password = '{password}'";


                SqlCommand command = new SqlCommand(query, con);
                adapter.SelectCommand = command;
                adapter.Fill(dt);


                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Успешный вход");
                    if (login == "s.antuh")
                    {
                        Window1 f = new Window1(login);
                        f.Show();
                    }
                }

                else MessageBox.Show("Неправильно введен логин ли пароль");

                con.Close();
            }
        }
    }
}
