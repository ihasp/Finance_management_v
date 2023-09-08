using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_1.Model;

namespace WPF_1.ViewModel
{
    internal class ModifyDatabaseViewModel
    {
        public DataTable Klienci { get; set; }
        public DataTable PozycjeZamówienia { get; set; }
        public DataTable Pracownicy { get; set; }
        public DataTable Spedytorzy { get; set; }
        public DataTable Zamówienia { get; set; }
        public DataTable Dostawcy { get; set; }
        public DataTable Kategorie { get; set; }
        public DataTable Produkty { get; set; }


        DataModel dataModel = new DataModel();

        public ModifyDatabaseViewModel()
        {
            Klienci = dataModel.GetTableData("SELECT * FROM dbo.Klienci");
            PozycjeZamówienia = dataModel.GetTableData("SELECT * FROM dbo.PozycjeZamówienia");
            Pracownicy = dataModel.GetTableData("SELECT * FROM dbo.Pracownicy");
            Spedytorzy = dataModel.GetTableData("SELECT * FROM dbo.Spedytorzy");
            Zamówienia = dataModel.GetTableData("SELECT * FROM dbo.Zamówienia");
            Dostawcy = dataModel.GetTableData("SELECT * FROM mg.Dostawcy");
            Kategorie = dataModel.GetTableData("SELECT * FROM mg.Kategorie");
            Produkty = dataModel.GetTableData("SELECT * FROM mg.Produkty");
        }

    }
}
