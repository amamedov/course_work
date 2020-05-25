using Core;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Login
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        Repository repository;
        public SettingsWindow(Repository repository)
        {
            InitializeComponent( );
            this.repository = repository;
            TextBoxInstanceName.Text = "SQLEXPRESS";
            TextBoxServerName.Text = "DESKTOP-1OJ7R9S";
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var conn_string = !(bool)IsSql.IsChecked?
                $"Server={TextBoxServerName.Text}\\{TextBoxInstanceName.Text};Initial Catalog = master;Integrated Security =true" 
                : $"Server={TextBoxServerName.Text}\\{TextBoxInstanceName.Text};Initial Catalog = master;User ID = { TextBoxUser.Text }; Password ={ PasswordBox.Password}";
            var connString_1 = !(bool)IsSql.IsChecked ?
                $"Server={TextBoxServerName.Text}\\{TextBoxInstanceName.Text};Initial Catalog = Course_work_Mamedov;Integrated Security =true"
                : $"Server={TextBoxServerName.Text}\\{TextBoxInstanceName.Text};Initial Catalog = Course_work_Mamedov;User ID = { TextBoxUser.Text }; Password ={ PasswordBox.Password}";
            SqlConnection connection = new SqlConnection(conn_string);
            try
            {
                connection.Open();
                connection.Close();
                if ((bool)CreateDB.IsChecked)
                {
                    using (connection)
                    {
                        var command = new SqlCommand("create database [Course_work_Mamedov];", connection);
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                    }
                    using (var conn = new SqlConnection(connString_1))
                    {
                        using (StreamReader sr = new StreamReader("../../../../Core/Scripts/whole_script.sql"))
                        {
                            var query = sr.ReadToEnd();
                            var server = new Server(new ServerConnection(sqlConnection: conn));
                            server.ConnectionContext.ExecuteNonQuery(query);
                        }
                    }
                }
                repository.ConnString = connString_1;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void IsSql_Checked(object sender, RoutedEventArgs e)
        {
            TextBoxUser.IsEnabled = true;
            PasswordBox.IsEnabled = true;
        }

        private void IsSql_Unchecked(object sender, RoutedEventArgs e)
        {
            TextBoxUser.IsEnabled = false;
            PasswordBox.IsEnabled = false;
        }
    }
}
