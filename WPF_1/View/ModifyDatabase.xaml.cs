using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using WPF_1.Model;
using WPF_1.View.AddView;
using WPF_1.ViewModel;

namespace WPF_1.View
{
    /// <summary>
    /// Interaction logic for ModifyDatabase.xaml
    /// </summary>
    public partial class ModifyDatabase : Window
    {
        public ModifyDatabase()
        {
            InitializeComponent();
            DataContext = new ModifyDatabaseViewModel();
            
        }

        private bool isWindowOpen=false;    
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isWindowOpen)
            {

                AddClient addClient = new AddClient();
                addClient.Show();
                isWindowOpen = true;
                addClient.Closed += (s, args) => { isWindowOpen = false; };

            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
              
                if (dataGrid.SelectedItem != null)
                {
                    DataRowView selectedRow = (DataRowView)dataGrid.SelectedItem;
                    string idToDelete = selectedRow["IDklienta"].ToString();
                    string deleteSql = "DELETE FROM Klienci WHERE IDklienta = @IDklienta";

                    using (SqlConnection connection = new SqlConnection(DBConnection.Connection))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(deleteSql, connection))
                        {
                            command.Parameters.AddWithValue("@IDklienta", idToDelete);
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Wiersz został usunięty!");
                            }
                            else
                            {
                                MessageBox.Show("Nie można usunąć wiersza!");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wybierz wiersz do usunięcia");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}");
            }
        }

    }
}
