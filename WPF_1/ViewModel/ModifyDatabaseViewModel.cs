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

        public ModifyDatabaseViewModel()
        {
            DataModel dataModel = new DataModel();
            Klienci = dataModel.GetTableData("SELECT * FROM dbo.Klienci");
        }
    }
}
