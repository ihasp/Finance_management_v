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
        public DataTable EarningsTable { get; set; }    

        public MainWindowViewModel()
        {
            DataModel dataModel = new DataModel();
            MainDataTable = dataModel.GetTableData("SELECT  Z.DataZamówienia AS Data_Zamówienia, Z.IDzamówienia AS ID_Zamówienia, K.IDklienta AS Klient, K.NazwaFirmy AS Nazwa_Firmy, PZ.IDproduktu AS ID_Produktu,\r\nPR.NazwaProduktu AS Nazwa_Produtku, PZ.Ilość,SUM(PZ.CenaJednostkowa*Ilość) AS Cena_Całkowita\r\nFROM Klienci AS K INNER JOIN Zamówienia AS Z ON Z.IDklienta = K.IDklienta INNER JOIN PozycjeZamówienia AS PZ ON Z.IDzamówienia = PZ.IDzamówienia\r\nINNER JOIN mg.Produkty AS PR ON PR.IDproduktu = PZ.IDproduktu\r\nGROUP BY PZ.Ilość, K.IDklienta, K.NazwaFirmy, Z.IDzamówienia, PZ.IDproduktu, PR.NazwaProduktu, Z.DataZamówienia\r\nORDER BY Z.DataZamówienia DESC");
            SummaryTable = dataModel.GetTableData("SELECT K.NazwaFirmy AS Nazwa_Firmy, CONCAT(SUM(PZ.CenaJednostkowa * PZ.Ilość), ' PLN') AS Zarobki_Całkowite\r\nFROM Klienci AS K INNER JOIN Zamówienia AS Z ON Z.IDklienta = K.IDklienta INNER JOIN PozycjeZamówienia AS PZ ON Z.IDzamówienia = PZ.IDzamówienia\r\nINNER JOIN mg.Produkty AS PR ON PR.IDproduktu = PZ.IDproduktu\r\nGROUP BY K.NazwaFirmy");
            EarningsTable = dataModel.GetTableData("SELECT CONCAT(SUM(Zarobek_Całkowity), ' PLN') AS Zarobek_Całkowity\r\nFROM (\r\n    SELECT K.NazwaFirmy AS Nazwa_Firmy, SUM(PZ.CenaJednostkowa * PZ.Ilość) AS Zarobek_Całkowity\r\n    FROM Klienci AS K INNER JOIN Zamówienia AS Z ON Z.IDklienta = K.IDklienta INNER JOIN PozycjeZamówienia AS PZ ON Z.IDzamówienia = PZ.IDzamówienia \r\n    INNER JOIN mg.Produkty AS PR ON PR.IDproduktu = PZ.IDproduktu\r\n    GROUP BY K.NazwaFirmy\r\n) AS PodsumowanieZarobków\r\n");
        }
    }
}
