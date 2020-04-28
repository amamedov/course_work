using Models;
using System;
using System.Collections;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.IO;
using System.Reflection.Metadata;
using Core;
using ManagerApp;
using System.Diagnostics;

namespace Startup
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter server name: ");
            var server_name = Console.ReadLine();
            Console.WriteLine("Enter instance name:");
            var instance = Console.ReadLine();
            Console.WriteLine("Is sql authentication? (y/n)");
            var conn_string = $"Server={server_name}\\{instance};Initial Catalog = master;";
            var sql_auth = Console.ReadLine().ToLower() == "y" ? true : false;
            string connString_1;
            if (sql_auth)
            {
                Console.WriteLine("Enter user name:");
                var user = Console.ReadLine();
                Console.WriteLine("Enter password:");
                var password = Console.ReadLine();
                conn_string += $"User ID = {user};Password={password}";
                connString_1 = $"Server ={server_name}\\{instance}; Initial Catalog = Course_work_Mamedov;User ID={user};Password={password}";
            }
            else
            {
                conn_string += $"Integrated Security =true";
                connString_1 = $"Server ={server_name}\\{instance}; Initial Catalog = Course_work_Mamedov;Integrated Security=true";
            }
            SqlConnection connection = new SqlConnection(conn_string);
            try
            {
                connection.Open();
                connection.Close();
            }
            catch
            {
                Console.WriteLine("Wrong connection string");
                Environment.Exit(-1);
            }
            Console.WriteLine("Do you need to create database? (y/n)");
            var answer = Console.ReadLine().ToLower();
            if (answer == "y")
            {
                using (connection)
                {
                    var command = new SqlCommand("create database [Course_work_Mamedov];", connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                using (var conn = new SqlConnection(connString_1))
                {
                    using (StreamReader sr = new StreamReader("../../../Scripts/whole_script.sql"))
                    {
                        var query = sr.ReadToEnd();
                        var server = new Server(new ServerConnection(sqlConnection: conn));
                        server.ConnectionContext.ExecuteNonQuery(query);
                    }
                }
            }
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = "../../../../ManagerApp/bin/Debug/netcoreapp3.1/ManagerApp.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.Arguments = $"\"{connString_1}\"";
            startInfo.ErrorDialog = true;
            startInfo.CreateNoWindow = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            using (var process = Process.Start(startInfo).StandardOutput)
            {

                Environment.Exit(0);
            }
        }
    }
}
