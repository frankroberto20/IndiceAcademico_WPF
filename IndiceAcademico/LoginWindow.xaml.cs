using System;
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
using System.IO;

namespace IndiceAcademico
{
	/// <summary>
	/// Interaction logic for LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		public static string filepathUser = "BaseUsuario.data";

		public LoginWindow()
		{
			InitializeComponent();

			if (!File.Exists(filepathUser))
			{
				string[] admin = { "A,admin,0000" };
				File.AppendAllLines(filepathUser, admin);
			}
				
		}

		private void Login_Click(object sender, RoutedEventArgs e)
		{
			if (inputUsuario.Text != "" && inputContrasena.Password != "")
			{
				foreach (var line in File.ReadAllLines(filepathUser))
				{
					string[] data = line.Split(',');
					if (data.Length == 3)
					{
						if (data[0] == "P" && inputUsuario.Text == data[1] && inputContrasena.Password == data[2])
						{
							Window window = new MainWindow();
							window.Show();
							window.
							Close();
						}

						if (data[0] == "E" && inputUsuario.Text == data[1] && inputContrasena.Password == data[2])
						{
							Window window = new EstudianteMainWindow();
							window.Show();
							Close();
						}

						if (data[0] == "A" && inputUsuario.Text == data[1] && inputContrasena.Password == data[2])
						{
							Window window = new MainWindow();
							window.Show();
							Close();
						}
					}
				}
			}
		}
	}
}
