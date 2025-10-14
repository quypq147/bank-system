// Program.cs
using System;
using System.Windows.Forms;

namespace BankClient
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm()); // LoginForm tự mở MainForm/UserForm
        }
    }
}

