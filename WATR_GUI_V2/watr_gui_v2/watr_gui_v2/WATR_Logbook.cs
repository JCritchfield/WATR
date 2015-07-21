using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace watr_gui_v2
{
    public partial class WATR_Logbook : Form
    {
        public WATR_Logbook()
        {
            InitializeComponent();
        }

        public void SetDataSource(DataTable table)
        {
            this.logbookRecordView.DataSource = table;
        }
    }
}
