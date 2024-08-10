using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElegantOTAClient
{
    public partial class FormDialog : Form
    {
        private OTAConfig config;

        public FormDialog(OTAConfig cfg)
        {
            InitializeComponent();

            config = cfg;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
