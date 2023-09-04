using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_1.Model;

namespace WPF_1.ViewModel
{
    internal class MainWindowViewModel
    {
        public DataTable MainDataTable { get; set; }
        public DataTable SummaryTable { get; set; } 
        public MainWindowViewModel()
        {
            DataModel dataModel = new DataModel();
            MainDataTable = dataModel.GetTableData("SELECT K.IDklienta AS Klient, K.NazwaFirmy AS Nazwa_Firmy, Z.IDzamówienia AS ID_Zamówienia, PZ.IDproduktu AS ID_Produktu,\r\nPR.NazwaProduktu AS Nazwa_Produtku, SUM(PZ.CenaJednostkowa*Ilość) AS Cena_Całkowita, Z.DataZamówienia AS Data_Zamówienia\r\nFROM Klienci AS K INNER JOIN Zamówienia AS Z ON Z.IDklienta = K.IDklienta\r\nINNER JOIN PozycjeZamówienia AS PZ ON Z.IDzamówienia = PZ.IDzamówienia\r\nINNER JOIN mg.Produkty AS PR ON PR.IDproduktu = PZ.IDproduktu\r\nGROUP BY K.IDklienta, K.NazwaFirmy, Z.IDzamówienia, PZ.IDproduktu, PR.NazwaProduktu, Z.DataZamówienia\r\nORDER BY Z.DataZamówienia DESC");
            SummaryTable = dataModel.GetTableData("SELECT *\r\nFROM Zamówienia\r\nWHERE DataZamówienia >= DATEADD(WEEK, -1, '1998-05-06')                    ");
            
        }
    }
}
