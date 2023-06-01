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
        private DataModel datamodel;
        public DataTable TableData { get; set; }

        public MainWindowViewModel()
        {
            datamodel = new DataModel();
            TableData = datamodel.GetTableData();
        }
    }
}
