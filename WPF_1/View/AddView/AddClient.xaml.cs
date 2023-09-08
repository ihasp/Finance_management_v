using Microsoft.Data.SqlClient;
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
using WPF_1.ViewModel;

namespace WPF_1.View.AddView
{
    /// <summary>
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();
            DataContext = new ModifyDatabaseViewModel();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DBConnection.Connection))
                {
                    connection.Open();
                    string idKlienta = idKlientaTextBox.Text;
                    string nazwaFirmy = nazwaFirmyTextBox.Text;
                    string przedstawiciel = przedstawicielTextBox.Text;
                    string miasto = miastoTextBox.Text;
                    string region = regionTextBox.Text;
                    string telefon = telefonTextBox.Text;
      
                    string insertSql = "INSERT INTO dbo.Klienci (IDklienta, NazwaFirmy, Przedstawiciel, Miasto, Region, Telefon) VALUES (@IDklienta, @NazwaFirmy, @Przedstawiciel, @Miasto, @Region, @Telefon)";

                    using (SqlCommand command = new SqlCommand(insertSql, connection))
                    {
                        command.Parameters.AddWithValue("@IDklienta", idKlienta);
                        command.Parameters.AddWithValue("@NazwaFirmy", nazwaFirmy);
                        command.Parameters.AddWithValue("@Przedstawiciel", przedstawiciel);
                        command.Parameters.AddWithValue("@Miasto", miasto);
                        command.Parameters.AddWithValue("@Region", region);
                        command.Parameters.AddWithValue("@Telefon", telefon);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Klient został dodany!");
                        }
                        else
                        {
                            MessageBox.Show("Nie udało się dodać klienta.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}");
            }
        }
    }
}
